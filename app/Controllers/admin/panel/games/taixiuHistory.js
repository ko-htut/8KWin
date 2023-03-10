var TXCuoc = require('../../../../Models/TaiXiu_cuoc');
var UserInfo = require('../../../../Models/UserInfo');
var User = require('../../../../Models/Users');
module.exports = function(req, res) {
    var { userAuth, body } = req || {};
    var { Data } = body || {};
    var { fromDate, toDate, nickname } = Data || {};
    var filter = {
        thanhtoan: true,
        taixiu: true,
        red: true
    };
    if (fromDate || toDate) {
        if (!!fromDate) {
            filter.time = {
                $gte: new Date(fromDate)
            }
        }
        if (!!toDate) {
            if (filter.time) {
                filter.time.$lte = new Date(toDate)
            } else {
                filter.time = {
                    $lte: new Date(toDate)
                }
            }
        }
    }
    if (nickname) {
        filter.name = nickname;
    }
    UserInfo.find({
        type: false
    }, function(err, us) {
        us = us.map(function(item, index) {
            return item.name;
        });
        if (us && us.length > 0) {
            filter.name = { $in: us };
        }
        TXCuoc.countDocuments(filter).exec(function(err, totals) {
            TXCuoc.find(filter, {}, { sort: { '_id': -1 }, skip: Data.offset, limit: Data.limit }, async function(error, result) {
                
                for(var i = 0; i< result.length; i++){
                    
                    let dataUser = await UserInfo.findOne({id:result[i].uid});
                    let dataUserIp = await User.findOne({_id:result[i].uid});
                    result[i] = result[i]._doc;
                    result[i].ip = dataUserIp.local.ip;
                    result[i].money = dataUser.red;
                }
                res.json({
                    status: 200,
                    success: true,
                    totals: totals,
                    data: result ? result : []
                });
            });
        });
    });
};