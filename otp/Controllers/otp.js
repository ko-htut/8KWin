let OTP = require('../Models/OTP')
let Phone = require('../Models/Phone')
let telegram = require('../Models/Telegram')
let Users = require('../Models/Users')
let helpers = require('../Helpers/Helpers');
module.exports = (bot, msg) => {
    telegram.findOne({ 'form': msg.from.id }, 'form uid phone', function (err3, teleCheck) {
        var otp = (Math.random() * (9999 - 1000 + 1) + 1000) >> 0; // tα»« 1000 ΔαΊΏn 9999
        if (!!teleCheck) {
            if (teleCheck.gift) {
                let replyMarkup = bot.keyboard([
                    [bot.button('getOtp', 'OTP')]
                ], { resize: true });
                OTP.create({ 'uid': teleCheck.uid, 'phone': teleCheck.phone, 'code': otp, 'date': new Date() });
                bot.sendMessage(msg.from.id, `π *αααΊα OTP Q36.VIN αααΊ*- ${otp}\nααΌα¬αα»α­ααΊ- 30 αααΉααα·αΊ`, { parseMode: 'markdown', replyMarkup: replyMarkup });
            } else {
                let replyMarkup = bot.keyboard([
                    [bot.button('getOtp', 'OTP')],
                    [bot.button('getGift', 'GIFTCODE')]
                ], { resize: true });
                OTP.create({ 'uid': teleCheck.uid, 'phone': teleCheck.phone, 'code': otp, 'date': new Date() });
                bot.sendMessage(msg.from.id, `π *αααΊα OTP Q36.VIN αααΊ*- ${otp}\nααΌα¬αα»α­ααΊ- 30 αααΉααα·αΊ`, { parseMode: 'markdown', replyMarkup: replyMarkup });
            }
        } else {
            let replyMarkup = bot.keyboard([
                [bot.button('contact', 'βοΈ αα―ααΊαΈααΆαα«ααΊαα»αΎαα±αα«α')]
            ], { resize: true });
            bot.sendMessage(msg.from.id, `π αα»α±αΈαα°αΈααΌα―α *OTP* αααΎα­αααΊ *αα―ααΊαΈααΆαα«ααΊαα­α― αα»αΎαα±αα«*`, { parseMode: 'markdown', replyMarkup: replyMarkup });
        }
    });
}