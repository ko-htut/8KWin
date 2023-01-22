
let shortid = require('shortid');
let telegram = require('../../Models/Telegram');
let Phone = require('../../Models/Phone');
let GiftCode = require('../../Models/GiftCode');
let Message = require('../../Models/Message');

module.exports = function (bot, id) {
	telegram.findOne({ 'form': id }, {}, function (err1, check) {
		if (check) {
			Phone.findOne({ 'phone': check.phone }, {}, function (err2, checkPhone) {
				if (checkPhone) {
					if (!check.gift) {
						// Gift khởi nghiệp
						let get_gift = shortid.generate();

						get_gift = get_gift.toLowerCase();
						try {
							GiftCode.create({ 'code': get_gift, 'red': 5000, 'xu': 0, 'type': 'tanthu', 'date': new Date(), 'todate': new Date(new Date() * 1 + 86400000), 'to': checkPhone.uid }, function (err3, gift) {
								if (!!gift) {
									if (!check.gift) {
										check.gift = true;
										check.save();
										bot.sendMessage(id, 'Start-up Giftcode ကိုလက်ခံရရှိသည့်အတွက် ဂုဏ်ယူပါသည်၊ သင်၏လက်ဆောင်ကုဒ်မှာ-' + get_gift, { reply_markup: { remove_keyboard: true } });
										Message.create({ 'uid': checkPhone.uid, 'title': 'စတင်ခြင်းလက်ဆောင်ကုဒ်', 'text': 'Start-up Giftcode ကိုလက်ခံရရှိသည့်အတွက် ဂုဏ်ယူပါသည်၊ သင်၏လက်ဆောင်ကုဒ်မှာ-' + get_gift, 'time': new Date() });
									} else {
										bot.sendMessage(id, 'Chúc mừng bạn đã nhận Giftcode điểm danh đăng nhập hằng ngày, mã Giftcode của bạn là: ' + get_gift, { reply_markup: { remove_keyboard: true } });
										Message.create({ 'uid': checkPhone.uid, 'title': 'စတင်ခြင်းလက်ဆောင်ကုဒ်', 'text': 'Start-up Giftcode ကိုလက်ခံရရှိသည့်အတွက် ဂုဏ်ယူပါသည်၊ သင်၏လက်ဆောင်ကုဒ်မှာ-' + get_gift, 'time': new Date() });
									}
								} else {
									bot.sendMessage(id, '_နောက်နေ့ ပြန်လာကြရအောင်_', { parse_mode: 'markdown', reply_markup: { remove_keyboard: true } });
								}
							});
						} catch (error) {
							bot.sendMessage(id, '_နောက်နေ့ ပြန်လာကြရအောင်_', { parse_mode: 'markdown', reply_markup: { remove_keyboard: true } });
						}
					} else {
						bot.sendMessage(id, '_နောက်နေ့ ပြန်လာကြရအောင်_', { parse_mode: 'markdown', reply_markup: { remove_keyboard: true } });
					}
				} else {
					bot.sendMessage(id, 'လုပ်ဆောင်ချက် မအောင်မြင်ပါ၊ ဖုန်းနံပါတ်ကို ဖတ်၍မရပါ။', { parse_mode: 'markdown', reply_markup: { remove_keyboard: true } });
				}
			});
		} else {
			bot.sendMessage(id, 'လုပ်ဆောင်ချက် မအောင်မြင်ပါ၊ ဖုန်းနံပါတ်ကို ဖတ်၍မရပါ။', { parse_mode: 'markdown', reply_markup: { remove_keyboard: true } });
		}
	});
}
