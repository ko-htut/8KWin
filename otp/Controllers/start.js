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
                    let ChatText = `*π― αααΊαΈαα½αΎααΊαα»ααΊαα»α¬αΈπ― * \n π *αα―αΆααΌα―αΆαα±αΈ- * β\n π *αα―ααΊαΈ- *${data.phone}π±\n π OTP αα―ααΊα‘αααΊαα»α¬αΈαααΎα­αααΊ *OTP* αα­α― αα­α―ααΊααα·αΊαα«\n π *αααΊαα±α¬ααΊαα―ααΊαα­α― ααα·αΊαα«* ααα― ααααΊαα­α―ααΊαα« -Up GiftCode`
                    bot.sendMessage(msg.from.id, ChatText, { parseMode: parseMode, replyMarkup: replyMarkup });
                } else {
                    let replyMarkup = bot.keyboard([
                        [bot.button('contact', 'βοΈ αα―ααΊαΈααΆαα«ααΊαα»αΎαα±αα«α')]
                    ], { resize: true });
                    bot.sendMessage(msg.from.id, 'π²*Q36.VIN*π² α€αααΊααΎα¬ OTP α‘ααΊααΊαα­α― αααΊααααα―αΆαΈα‘αα―αΆαΈααΌα―ααΌααΊαΈααΌααΊαααΊα\n π α‘ααα²α· OTP αα―ααΊαααΊαα―αααΎα­αααΊ βοΈ*SHARE PHONE NUMBER* αα­α―ααΎα­ααΊαα«α', { parseMode: parseMode, replyMarkup: replyMarkup });
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