
let telegram = require('../../Models/Telegram');

module.exports = function (bot, id) {
	telegram.findOne({ 'form': id }, 'phone', function (err, data) {
		if (data) {
			console.log(data)
			let opts = {
				parse_mode: 'markdown',
				reply_markup: {
					keyboard: [
						[{ text: 'CHIA SẺ SỐ ĐIỆN THOẠI', request_contact: true }],
						[{ text: 'OTP' }],
						[{ text: 'GIFTCODE' }],
					],
					resize_keyboard: true,
				}
			};
			let ChatText = `*🎯 လမ်းညွှန်ချက်များ🎯 * \n 👉 *လုံခြုံရေး- * ✅\n 👉 *ဖုန်း- *${data.phone}📱\n 👉 OTP ကုဒ်အသစ်များရရှိရန် *OTP* ကို ရိုက်ထည့်ပါ\n 👉 *လက်ဆောင်ကုဒ်ကို ထည့်ပါ* ယခု စတင်လိုက်ပါ -Up GiftCode`
			bot.sendMessage(id, ChatText, opts);
		} else {
			let opts = {
				parse_mode: 'markdown',
				reply_markup: {
					keyboard: [
						[{ text: 'CHIA SẺ SỐ ĐIỆN THOẠI', request_contact: true }],
						[{ text: 'OTP' }],
						[{ text: 'GIFTCODE' }],
					],
					resize_keyboard: true,
				}
			};
			bot.sendMessage(id, '🎲*Q36.VIN*🎲 ဤသည်မှာ OTP အက်ပ်ကို သင်ပထမဆုံးအသုံးပြုခြင်းဖြစ်သည်။\n 👉 အခမဲ့ OTP ကုဒ်တစ်ခုရရှိရန် ☎️*SHARE PHONE NUMBER* ကိုနှိပ်ပါ။', opts);
		}
	});
}
