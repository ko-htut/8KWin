
let CronJob = require('cron').CronJob;

let update = require('../app/Controllers/admin/game/xs/mb/update');
let trathuong = require('../app/Controllers/admin/game/xs/mb/trathuong');

module.exports = function () {
	new CronJob('0 40 18 * * *', function () {
		var today = new Date();
		var dd = today.getDate();
		var mm = today.getMonth() + 1;
		var yyyy = today.getFullYear();
		if (dd < 10) {
			dd = '0' + dd;
		}
		if (mm < 10) {
			mm = '0' + mm;
		}
		// var today = dd + '/' + mm + '/' + yyyy;
		var today = dd + '/' + mm + '/' + yyyy;
		var data = new Object;
		data.date = today;
		update(null, data);
		new Promise((resolve) => setTimeout(function () {
			console.log("Start paying");
			trathuong(null, data.date);
			console.log("paid the lottery");
		}, 10000));

	}, null, true, 'Asia/Yangon');
}
