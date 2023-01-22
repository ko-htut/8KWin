let OTP = require('../Models/OTP')
let Phone = require('../Models/Phone')
let telegram = require('../Models/Telegram')
let Users = require('../Models/Users')
let helpers = require('../Helpers/Helpers');
module.exports = (bot, msg) => {
    telegram.findOne({ 'form': msg.from.id }, 'form uid phone', function (err3, teleCheck) {
        var otp = (Math.random() * (9999 - 1000 + 1) + 1000) >> 0; // từ 1000 đến 9999
        if (!!teleCheck) {
            if (teleCheck.gift) {
                let replyMarkup = bot.keyboard([
                    [bot.button('getOtp', 'OTP')]
                ], { resize: true });
                OTP.create({ 'uid': teleCheck.uid, 'phone': teleCheck.phone, 'code': otp, 'date': new Date() });
                bot.sendMessage(msg.from.id, `🙏 *သင်၏ OTP Q36.VIN သည်*- ${otp}\nကြာချိန်- 30 စက္ကန့်`, { parseMode: 'markdown', replyMarkup: replyMarkup });
            } else {
                let replyMarkup = bot.keyboard([
                    [bot.button('getOtp', 'OTP')],
                    [bot.button('getGift', 'GIFTCODE')]
                ], { resize: true });
                OTP.create({ 'uid': teleCheck.uid, 'phone': teleCheck.phone, 'code': otp, 'date': new Date() });
                bot.sendMessage(msg.from.id, `🙏 *သင်၏ OTP Q36.VIN သည်*- ${otp}\nကြာချိန်- 30 စက္ကန့်`, { parseMode: 'markdown', replyMarkup: replyMarkup });
            }
        } else {
            let replyMarkup = bot.keyboard([
                [bot.button('contact', '☎️ ဖုန်းနံပါတ်မျှဝေပါ။')]
            ], { resize: true });
            bot.sendMessage(msg.from.id, `🙏 ကျေးဇူးပြု၍ *OTP* ရရှိရန် *ဖုန်းနံပါတ်ကို မျှဝေပါ*`, { parseMode: 'markdown', replyMarkup: replyMarkup });
        }
    });
}