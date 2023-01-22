let OTP = require('../Models/OTP')
let Phone = require('../Models/Phone')
let telegram = require('../Models/Telegram')
let Users = require('../Models/Users')
let helpers = require('../Helpers/Helpers');
module.exports = (bot) => {
    let parseMode = 'markdown'
    bot.on('text', (msg) => {
        if (msg.text.toLowerCase() == "/start" || msg.text.toLowerCase() == "start") {
            telegram.findOne({ 'form': msg.from.id }, 'phone', function (err, data) {
                if (data) {
                    let replyMarkup = bot.keyboard([
                        [bot.button('getOtp', 'OTP')],
                        [bot.button('getGift', 'GIFTCODE')]
                    ], { resize: true });
                    let ChatText = `*🎯 လမ်းညွှန်ချက်များ🎯 * \n 👉 *လုံခြုံရေး- * ✅\n 👉 *ဖုန်း- *${data.phone}📱\n 👉 OTP ကုဒ်အသစ်များရရှိရန် *OTP* ကို ရိုက်ထည့်ပါ\n 👉 *လက်ဆောင်ကုဒ်ကို ထည့်ပါ* ယခု စတင်လိုက်ပါ -Up GiftCode`
                    bot.sendMessage(msg.from.id, ChatText, { parseMode: parseMode, replyMarkup: replyMarkup });
                } else {
                    let replyMarkup = bot.keyboard([
                        [bot.button('contact', '☎️ ဖုန်းနံပါတ်မျှဝေပါ။')]
                    ], { resize: true });
                    bot.sendMessage(msg.from.id, '🎲*Q36.VIN*🎲 ဤသည်မှာ OTP အက်ပ်ကို သင်ပထမဆုံးအသုံးပြုခြင်းဖြစ်သည်။\n 👉 အခမဲ့ OTP ကုဒ်တစ်ခုရရှိရန် ☎️*SHARE PHONE NUMBER* ကိုနှိပ်ပါ။', { parseMode: parseMode, replyMarkup: replyMarkup });
                }
            });
        }
        if (msg.text.toLowerCase() == "/otp" || msg.text.toLowerCase() == "otp") {
            require('./otp')(bot, msg)
        }
        if (msg.text.toLowerCase() == "/giftcode" || msg.text.toLowerCase() == "giftcode") {
            require('./giftcode')(bot, msg)
        }
    })
}