
const HU            = require('../../../Models/HU');

let VuongQuocRed_red   = require('../../../Models/VuongQuocRed/VuongQuocRed_red');
let VuongQuocRed_xu    = require('../../../Models/VuongQuocRed/VuongQuocRed_xu');
let VuongQuocRed_users = require('../../../Models/VuongQuocRed/VuongQuocRed_users');

const UserInfo   = require('../../../Models/UserInfo');

function onSelectBox(client, box){
	box = box>>0;
	if (void 0 !== client.VuongQuocRed &&
		client.VuongQuocRed.bonus !== null &&
		client.VuongQuocRed.bonusL > 0)
	{
		var index = box-1;
		if (void 0 !== client.VuongQuocRed.bonus[index]) {
			if (!client.VuongQuocRed.bonus[index].isOpen) {
				client.VuongQuocRed.bonusL -= 1;
				client.VuongQuocRed.bonus[index].isOpen = true;

				var bet = client.VuongQuocRed.bonus[index].bet;
				client.VuongQuocRed.bonusWin += bet;
				client.red({VuongQuocRed:{bonus:{bonus: client.VuongQuocRed.bonusL, box: index, bet: bet}}});
				if (!client.VuongQuocRed.bonusL) {
					var betWin = client.VuongQuocRed.bonusWin;

					var uInfo    = {};
					var gInfo    = {};
					var huUpdate = {};

					if (client.VuongQuocRed.red) {
						huUpdate.redWin = betWin;
						uInfo.red       = betWin;
						uInfo.redWin    = betWin;
						gInfo.win       = betWin;
						VuongQuocRed_red.updateOne({'_id': client.VuongQuocRed.id}, {$inc:{win:betWin}}).exec();
					}else{
						huUpdate.xuWin = betWin;
						uInfo.xu       = betWin;
						uInfo.xuWin    = betWin;
						gInfo.winXu    = betWin;

						var thuong = (betWin*0.039589)>>0;
						uInfo.red      = thuong;
						uInfo.thuong   = thuong;
						gInfo.thuong   = thuong;

						VuongQuocRed_xu.updateOne({'_id': client.VuongQuocRed.id}, {$inc:{win:betWin}}).exec();
					}

					client.VuongQuocRed.bonus    = null;
					client.VuongQuocRed.bonusWin = 0;

					UserInfo.findOneAndUpdate({id:client.UID}, {$inc:uInfo}, function(err, user){
						setTimeout(function(){
							if (client.VuongQuocRed.red) {
								client.red({VuongQuocRed:{bonus:{win: betWin}}, user:{red:user.red*1+betWin}});
							}else{
								client.red({VuongQuocRed:{bonus:{win: betWin}}, user:{xu:user.xu*1+betWin}});
							}
						}, 700);
					});
					HU.updateOne({game:'long', type:client.VuongQuocRed.bet, red:client.VuongQuocRed.red}, {$inc:huUpdate}).exec();
					VuongQuocRed_users.updateOne({'uid':client.UID}, {$inc:gInfo}).exec();
				}
			}
		}
	}
}

module.exports = function(client, data){
	if (void 0 !== data.box) {
		onSelectBox(client, data.box);
	}
};
