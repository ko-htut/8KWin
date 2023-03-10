
let mongoose = require('mongoose');

let Schema = new mongoose.Schema({
	uid:    {type: String, required: true, unique: true}, // ID Người chơi

	hu:     {type: Number, default: 0},                     // Số lần Nổ Hũ REd
	bet:    {type: mongoose.Schema.Types.Long, default: 0}, // Số tiền đã chơi
	win:    {type: mongoose.Schema.Types.Long, default: 0}, // Số tiền đã thắng
	lost:   {type: mongoose.Schema.Types.Long, default: 0}, // Số Red đã thua

	huXu:   {type: Number, default: 0},                     // Số lần Nổ Hũ Xu
	betXu:  {type: mongoose.Schema.Types.Long, default: 0}, // Số Xu đã chơi
	winXu:  {type: mongoose.Schema.Types.Long, default: 0}, // Số Xu đã thắng
	lostXu: {type: mongoose.Schema.Types.Long, default: 0}, // Số Xu đã thua
	thuong: {type: Number, default: 0},                     // Số Red Thưởng
	time:   {type: Date},                                   // quay gần đây
});
//Schema.index({uid: 1}, {unique: true, background: true});

module.exports = mongoose.model('Zeus_users', Schema);
