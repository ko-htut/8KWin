var Min3cayRed = require('../../../../Models/Mini3Cay/Mini3Cay_red');
var UserInfo = require('../../../../Models/UserInfo');
module.exports = function(req, res) {
    var { userAuth, body } = req || {};
    var { Data } = body || {};
    var { fromDate, toDate, nickname } = Data || {};
    var filter = {};
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
        Min3cayRed.countDocuments(filter).exec(function(err, totals) {
        Min3cayRed.find(filter, {}, { sort: { '_id': -1 }, skip: Data.offset, limit: Data.limit }, function(error, result) {
            res.json({
                status: 200,
                success: true,
                totals: totals,
                data: result
            });
        });
    });
    });
    
};