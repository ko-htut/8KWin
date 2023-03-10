let OTP = require('../Models/OTP')
let Phone = require('../Models/Phone')
let telegram = require('../Models/Telegram')
let Users = require('../Models/Users')
let helpers = require('../Helpers/Helpers');
module.exports = (bot) => {
    bot.on('contact', (msg) => {
        let phoneCrack = helpers.phoneCrack2(msg.contact.phone_number)
        if (phoneCrack) {
            Phone.findOne({ 'phone': phoneCrack }, {}, (err, checkPhone) => {
                if (!!checkPhone) {
                    telegram.findOne({ 'phone': phoneCrack }, 'form uid', function (err3, teleCheck) {
                        if (!!teleCheck) {
                            if (teleCheck.gift) {
                                let replyMarkup = bot.keyboard([
                                    [bot.button('getOtp', 'OTP')]
                                ], { resize: true });
                                bot.sendMessage(msg.from.id, `ð áááºáááº *Phone*- ${phoneCrack} áá­á¯ áá»á¾áá±áá¬á¸áááºá *OTP* áá­á¯ áá½á±á¸áá« áá­á¯á·ááá¯ááº OTP á¡áááºáááºáá¯ ááá°áááº *OTP* áá¯ áá­á¯ááºááá·áºáá«á`, { parseMode: 'markdown', replyMarkup: replyMarkup });
                            } else {
                                let replyMarkup = bot.keyboard([
                                    [bot.button('getOtp', 'OTP')],
                                    [bot.button('getGift', 'GIFTCODE')]
                                ], { resize: true });
                                bot.sendMessage(msg.from.id, `ð Báº¡n ÄÃ£ chia sáº» *SÄT*: ${phoneCrack}. Chá»n *OTP* hoáº·c nháº­p *OTP* Äá» láº¥y mÃ£ OTP má»i`, { parseMode: 'markdown', replyMarkup: replyMarkup });
                            }
                        } else {
                            let replyMarkup = bot.keyboard([
                                [bot.button('getOtp', 'OTP')],
                                [bot.button('getGift', 'GIFTCODE')]
                            ], { resize: true });
                            telegram.create({ 'gift': false, 'form': msg.from.id, 'phone': phoneCrack, 'uid': checkPhone.uid })
                            bot.sendMessage(msg.from.id, `ð ááá·áºáá¯ááºá¸áá¶áá«ááº âï¸*${phoneCrack}ð±* áá»á¾áá±áá±á¸ááá·áºá¡áá½ááº áá»á±á¸áá°á¸áááºáá«áááºá`, { parseMode: 'markdown', replyMarkup: replyMarkup });
                        }
                    });
                } else {
                    bot.sendMessage(msg.from.id, `áá¯ááºá¸áá¶áá«ááº- âï¸*${phoneCrack.substring(2,phoneCrack.length)}ð±*\n ð áá»á±á¸áá°á¸áá¼á¯á áá­ááºá¸áá­á¯á· áá¼ááºáá½á¬á¸áá¼á®á¸ á¡áááºáá½ááºá¸áááº á¤áá¾ááºáááºáá±á¬áá¶áá«ááºáá­á¯ ááá·áºáá«á`, { parseMode: 'markdown' });
                }
            })
        }
    })
}