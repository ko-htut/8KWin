var UserInfo = require('../../../../Models/UserInfo');
var Phone = require('../../../../Models/Phone');
var Users = require('../../../../Models/Users');
var TXCuoc = require('../../../../Models/TaiXiu_cuoc');

var RongHoCuoc = require('../../../../Models/RongHo/RongHo_cuoc');
var BauCuaCuoc = require('../../../../Models/BauCua/BauCua_cuoc');
var BanCa = require('../../../../Models/BanCa_Cash');

var XocDiaCuoc = require('../../../../Models/XocXoc/XocXoc_cuoc');
var MinipokerRed = require('../../../../Models/miniPoker/miniPokerRed');
var Min3cayRed = require('../../../../Models/Mini3Cay/Mini3Cay_red');
var BigBabolRed = require('../../../../Models/BigBabol/BigBabol_red');
var AngryBirds = require('../../../../Models/AngryBirds/AngryBirds_red');
var VuongQuocRedRed = require('../../../../Models/VuongQuocRed/VuongQuocRed_red');
var LongLanRed = require('../../../../Models/LongLan/LongLan_red');
var ZeusRed = require('../../../../Models/Zeus/Zeus_red');
var TamHungRed = require('../../../../Models/TamHung/TamHung_red');
var CandyRed = require('../../../../Models/Candy/Candy_red');
var XoSoCuoc = require('../../../../Models/XoSo/mb/xsmb_cuoc');
var MuaThe = require('../../../../Models/MuaThe');
var NapThe = require('../../../../Models/NapThe');
var Bank_history = require('../../../../Models/Bank/Bank_history');
var ChuyenRed = require('../../../../Models/ChuyenRed');
var GiftCode = require('../../../../Models/GiftCode');
var MenhGia = require('../../../../Models/MenhGia');
var _ = require('lodash');
var moment = require('moment');
var Helpers = require('../../../../Helpers/Helpers');

module.exports = function(req, res) {
    var { query } = req || {};
    console.log('query', query);
    var { id, type } = query || {};
    var filter = {};
    Promise.all([
            Phone.findOne({
                uid: id
            }),
            UserInfo.findOne({
                id: id
            }),
            Users.findOne({
                _id: id
            }),
            MenhGia.find({})
        ])
        .then(function(response) {
            var fone = response[0];
            var userInfo = response[1];
            var user = response[2];
            var menhgia = response[3];
            fone = fone || {};
            userInfo = userInfo || {};
            user = user || {};
            filter.name = userInfo.name;
            var userFinal = {
                joinedOn: userInfo.joinedOn,
                email: userInfo.email,
                cmt: userInfo.cmt,
                red: userInfo.red,
                ketSat: userInfo.ketSat,
                redWin: userInfo.redWin,
                redLost: userInfo.redLost,
                redPlay: userInfo.redPlay,
                thuong: userInfo.thuong,
                vip: userInfo.vip,
                lastVip: userInfo.lastVip,
                hu: userInfo.hu,
                name: userInfo.name,
                username: user ? user.local.username : '',
                phone: fone ? fone.phone : '',
                uid: userInfo.UID,
                timeRegister: user ? user.local.regDate : null,
            };
            switch (parseInt(type)) {
                case 1: //chuyen khoan
                    Promise.all([
                            ChuyenRed.find({
                                $or: [{
                                    from: userInfo.name
                                }, {
                                    to: userInfo.name
                                }]
                            })
                        ])
                        .then(function(response) {

                            var ck = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };

                            if (ck) {
                                ck.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Chuy???n Kho???n',
                                        type: `${item.from==userInfo.name ? `Chuy???n kho???n ?????n: $${item.to}` : `Nh???n t???: ${item.from}`}`,
                                        red: item.red,
                                        red_c: item.red_c,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 2: //the cao
                    Promise.all([
                            NapThe.find({ uid: userInfo.id }), //11
                            MuaThe.find({ uid: userInfo.id }), //12
                        ])
                        .then(function(response) {

                            var napthe = response[0];
                            var muathe = response[1];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (napthe) {
                                napthe.map(function(item, index) {
                                    var mgIndex = _.findIndex(menhgia, function(m) {
                                        return m.nap == true && m.name == item.menhGia;
                                    });
                                    var mg = 0;
                                    if (mgIndex >= 0) {
                                        mg = menhgia[mgIndex].values;
                                    }
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Th??? C??o',
                                        type: `N???p Th??? ${item.nhaMang}, Serial: ${item.seri}, Code: ${item.maThe}, Tr???ng Th??i: ${item.status == 0 ? '??ang Ch???' : item.status ==1 ? 'Th??nh C??ng' : 'Th???t B???i'}`,
                                        red: item.menhGia,
                                        red_c: mg,
                                        time: item.time
                                    });
                                });
                            }
                            if (muathe) {
                                muathe.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Th??? C??o',
                                        type: `Mua Th??? ${item.nhaMang}, S??? l?????ng: ${item.soLuong}`,
                                        red: item.menhGia,
                                        red_c: item.Cost,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 3: //giftcode
                    Promise.all([
                            GiftCode.find({
                                uid: id
                            }), //15
                        ])
                        .then(function(response) {

                            var giftcode = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (giftcode) {
                                giftcode.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'GiftCode',
                                        type: `N???p GiftCode: ${item.code}  Time: ${moment(item.timeUse).format('DD/MM/YYYY HH:ss:ss')}`,
                                        red: item.red,
                                        red_c: item.red,
                                        time: item.timeUse
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 4: //nghan hang
                    Promise.all([
                            Bank_history.find({
                                uid: userInfo.id,
                                type: 0
                            }), //13
                            Bank_history.find({
                                type: 1,
                                uid: userInfo.id
                            }), //14
                        ])
                        .then(function(response) {

                            var bankNap = response[0];
                            var bankRut = response[1];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (bankNap) {
                                bankNap.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Ng??n H??ng',
                                        type: `N???p qua Ng??n h??ng ${item.bank}, CTK: ${item.name}, STK: ${item.number}, Tr???ng Th??i: ${item.status==0 ? '??ang Ch???' : item.status==1 ? 'Th??nh C??ng' : 'Th???t B???i'}`,
                                        red: item.money,
                                        red_c: item.money,
                                        time: item.time
                                    });
                                });
                            }
                            if (bankRut) {
                                bankRut.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Ng??n H??ng',
                                        type: `R??t qua Ng??n h??ng ${item.bank}, CTK: ${item.name}, STK: ${item.number}, Tr???ng Th??i: ${item.status==0 ? '??ang Ch???' : item.status==1 ? 'Th??nh C??ng' : 'Th???t B???i'}`,
                                        red: item.money,
                                        red_c: item.money,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 5: //tai xiu
                    Promise.all([
                            TXCuoc.find(filter),
                        ])
                        .then(function(response) {

                            var taixiu = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (taixiu) {
                                taixiu.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'T??i X???u',
                                        type: `C?????c ${item.select ? 'T??i' : 'X???u'}`,
                                        red: item.bet,
                                        red_c: item.betwin,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 6: //bau cua
                    Promise.all([
                            BauCuaCuoc.find(filter),
                        ])
                        .then(function(response) {

                            var baucua = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (baucua) {
                                baucua.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'B???u Cua',
                                        type: `C?????c H??u: ${Helpers._formatMoneyVND(item[0])}, B???u: ${Helpers._formatMoneyVND(item[1])}, G??: ${Helpers._formatMoneyVND(item[2])}, C??: ${Helpers._formatMoneyVND(item[3])}, Cua: ${Helpers._formatMoneyVND(item[4])}, T??m: ${Helpers._formatMoneyVND(item[5])}`,
                                        red: item[0] + item[1] + item[2] + item[3] + item[4] + item[5],
                                        red_c: item.betwin,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 7: //xoc dia
                    Promise.all([
                            XocDiaCuoc.find(filter),
                        ])
                        .then(function(response) {

                            var xocdia = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (xocdia) {
                                xocdia.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'X??c ????a',
                                        type: `C?????c Ch???n: ${Helpers._formatMoneyVND(item.chan)}, C?????c L???: ${Helpers._formatMoneyVND(item.le)}, C?????c 3 ?????: ${Helpers._formatMoneyVND(item.red3)}, C?????c 4 ?????: ${Helpers._formatMoneyVND(item.red4)}, C?????c 3 Tr???ng: ${Helpers._formatMoneyVND(item.white3)}, C?????c 4 Tr???ng: ${Helpers._formatMoneyVND(item.white4)}`,
                                        red: item.chan + item.le + item.red3 + item.red4 + item.white3 + item.white4,
                                        red_c: item.betwin,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 8:
                    Promise.all([
                            MinipokerRed.find(filter),
                        ])
                        .then(function(response) {

                            var minipoker = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (minipoker) {
                                minipoker.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'MiniPoker',
                                        type: `C?????c`,
                                        red: item.bet,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 9: //mini 3 cay
                    Promise.all([
                            Min3cayRed.find(filter),
                        ])
                        .then(function(response) {

                            var mini3cay = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (mini3cay) {
                                mini3cay.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Mini 3 C??y',
                                        type: `C?????c`,
                                        red: item.bet,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 10: //bigbabol
                    Promise.all([
                            BigBabolRed.find(filter),
                        ])
                        .then(function(response) {

                            var bigbabol = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (bigbabol) {
                                bigbabol.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Bigbabol',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 11: //Angrybirds
                    Promise.all([
                            AngryBirds.find(filter),
                        ])
                        .then(function(response) {

                            var angrybirds = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (angrybirds) {
                                angrybirds.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'AngryBirds',
                                        type: `C?????c`,
                                        red: item.bet,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 12: //vuong quoc red
                    Promise.all([
                            VuongQuocRedRed.find(filter),
                        ])
                        .then(function(response) {

                            var vuongquocred = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (vuongquocred) {
                                vuongquocred.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'V????ng Qu???c Red',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 13: //Candy
                    Promise.all([
                            CandyRed.find(filter),
                        ])
                        .then(function(response) {

                            var candy = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (candy) {
                                candy.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Candy',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 14: //14 long lan
                    Promise.all([
                            LongLanRed.find(filter),
                        ])
                        .then(function(response) {

                            var longlan = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (longlan) {
                                longlan.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Long L??n',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 15: //xoso
                    Promise.all([
                            XoSoCuoc.find(filter),
                        ])
                        .then(function(response) {
                            var xoso = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (xoso) {
                                xoso.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'X??? S???',
                                        type: `C?????c ${item.so.join()}`,
                                        red: item.cuoc,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 16: //16 Zeus
                    Promise.all([
                        ZeusRed.find(filter),
                    ])
                        .then(function(response) {

                            var zeus = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (zeus) {
                                zeus.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Zeus',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 17: //16 Tam Hung
                    Promise.all([
                        TamHungRed.find(filter),
                    ])
                        .then(function(response) {

                            var tamhung = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (tamhung) {
                                tamhung.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Tam H??ng',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 18: //Rong Ho
                    Promise.all([
                            RongHoCuoc.find(filter),
                        ])
                        .then(function(response) {

                            var rongho = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (rongho) {
                                rongho.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'R???ng H???',
                                        type: `C?????c R???ng: ${Helpers._formatMoneyVND(item.rong)}, C?????c H???: ${Helpers._formatMoneyVND(item.ho)},C?????c Ho??: ${Helpers._formatMoneyVND(item.hoa)}, C?????c R??: ${Helpers._formatMoneyVND(item.ro)}, C?????c C??: ${Helpers._formatMoneyVND(item.co)}, C?????c t??p: ${Helpers._formatMoneyVND(item.tep)}, C?????c B??ch: ${Helpers._formatMoneyVND(item.bich)}`,
                                        red: item.rong + item.ho + item.hoa + item.ro + item.co + item.tep + item.bich,
                                        red_c: item.betwin,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                case 19: //Ban ca
                    Promise.all([
                        BanCa.find(filter),
                        ])
                        .then(function(response) {

                            var banca = response[0];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            if (banca) {
                                banca.map(function(item, index) {
                                    let text;
                                    if (item.type == "CashOut") {
                                        text = `?????i X??ng: `;
                                    }else{
                                        text = `?????i XU: `;
                                    }
                                    logs.push({
                                        name: item.name,
                                        game: 'B???n C??',
                                        
                                        type: `${text + Helpers._formatMoneyVND(item.cash)}`,
                                        red:  item.cash,
                                        red_c: item.cash,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break;
                default:
                    Promise.all([
                            TXCuoc.find(filter), //0
                            BauCuaCuoc.find(filter), //1
                            XocDiaCuoc.find(filter), //2
                            MinipokerRed.find(filter), //3
                            Min3cayRed.find(filter), //4
                            BigBabolRed.find(filter), //5
                            AngryBirds.find(filter), //6
                            VuongQuocRedRed.find(filter), //7
                            CandyRed.find(filter), //8
                            LongLanRed.find(filter), //9
                            XoSoCuoc.find(filter), //10
                            NapThe.find({ uid: userInfo.id }), //11
                            MuaThe.find({ uid: userInfo.id }), //12

                            Bank_history.find({
                                uid: userInfo.id,
                                type: 0
                            }), //13
                            Bank_history.find({
                                type: 1,
                                uid: userInfo.id
                            }), //14
                            GiftCode.find({
                                uid: userInfo.id
                            }), //15
                            ChuyenRed.find({
                                $or: [{
                                    from: userInfo.name
                                }, {
                                    to: userInfo.name
                                }]
                            }),
                            ZeusRed.find(filter), //16
                            TamHungRed.find(filter), //17
                            RongHoCuoc.find(filter), //18
                            BanCa.find(filter), //19
                        ])
                        .then(function(response) {
                            var taixiu = response[0];
                            var baucua = response[1];
                            var xocdia = response[2];
                            var minipoker = response[3];
                            var mini3cay = response[4];
                            var bigbabol = response[5];
                            var angrybirds = response[6];
                            var vuongquocred = response[7];
                            var candy = response[8];
                            var longlan = response[9];
                            var xoso = response[10];
                            var napthe = response[11];
                            var muathe = response[12];
                            var bankNap = response[13];
                            var bankRut = response[14];
                            var giftcode = response[15];
                            var ck = response[16];
                            var zeus = response[17];
                            var tamhung = response[18];
                            var rongho = response[19];
                            var banca = response[20];
                            var logs = [];
                            var finalResult = {
                                userInfo: userFinal,
                                logs: []
                            };
                            
                            if (taixiu) {
                                taixiu.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'T??i X???u',
                                        type: `C?????c ${item.select ? 'T??i' : 'X???u'}`,
                                        red: item.bet,
                                        red_c: item.betwin,
                                        time: item.time
                                    });
                                });
                            }
                            if (rongho) {
                                rongho.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'R???ng H???',
                                        type: `C?????c R???ng: ${Helpers._formatMoneyVND(item.rong)}, C?????c H???: ${Helpers._formatMoneyVND(item.ho)},C?????c Ho??: ${Helpers._formatMoneyVND(item.hoa)}, C?????c R??: ${Helpers._formatMoneyVND(item.ro)}, C?????c C??: ${Helpers._formatMoneyVND(item.co)}, C?????c t??p: ${Helpers._formatMoneyVND(item.tep)}, C?????c B??ch: ${Helpers._formatMoneyVND(item.bich)}`,
                                        red: item.rong + item.ho + item.hoa + item.ro + item.co + item.tep + item.bich,
                                        red_c: item.betwin,
                                        time: item.time
                                    });
                                });
                            }
                            if (banca) {
                                banca.map(function(item, index) {
                                    let text;
                                    if (item.type == "CashOut") {
                                        text = `?????i X??ng: `;
                                    }else{
                                        text = `?????i XU: `;
                                    }
                                    logs.push({
                                        name: item.name,
                                        game: 'B???n C??',
                                        
                                        type: `${text + Helpers._formatMoneyVND(item.cash)}`,
                                        red:  item.cash,
                                        red_c: item.cash,
                                        time: item.time
                                    });
                                });
                            }
                            if (baucua) {
                                baucua.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'B???u Cua',
                                        type: `C?????c H??u: ${Helpers._formatMoneyVND(item[0])}, B???u: ${Helpers._formatMoneyVND(item[1])}, G??: ${Helpers._formatMoneyVND(item[2])}, C??: ${Helpers._formatMoneyVND(item[3])}, Cua: ${Helpers._formatMoneyVND(item[4])}, T??m: ${Helpers._formatMoneyVND(item[5])}`,
                                        red: item[0] + item[1] + item[2] + item[3] + item[4] + item[5],
                                        red_c: item.betwin,
                                        time: item.time
                                    });
                                });
                            }
                            if (xocdia) {
                                xocdia.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'X??c ????a',
                                        type: `C?????c Ch???n: ${Helpers._formatMoneyVND(item.chan)}, C?????c L???: ${Helpers._formatMoneyVND(item.le)}, C?????c 3 ?????: ${Helpers._formatMoneyVND(item.red3)}, C?????c 4 ?????: ${Helpers._formatMoneyVND(item.red4)}, C?????c 3 Tr???ng: ${Helpers._formatMoneyVND(item.white3)}, C?????c 4 Tr???ng: ${Helpers._formatMoneyVND(item.white4)}`,
                                        red: item.chan + item.le + item.red3 + item.red4 + item.white3 + item.white4,
                                        red_c: item.betwin,
                                        time: item.time
                                    });
                                });
                            }
                            if (minipoker) {
                                minipoker.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'MiniPoker',
                                        type: `C?????c`,
                                        red: item.bet,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (mini3cay) {
                                mini3cay.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Mini 3 C??y',
                                        type: `C?????c`,
                                        red: item.bet,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (bigbabol) {
                                bigbabol.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Bigbabol',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (angrybirds) {
                                angrybirds.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'AngryBirds',
                                        type: `C?????c`,
                                        red: item.bet,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (vuongquocred) {
                                vuongquocred.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'V????ng Qu???c Red',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (candy) {
                                candy.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Candy',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (longlan) {
                                longlan.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Long L??n',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (tamhung) {
                                tamhung.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Tam Hung',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (zeus) {
                                zeus.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'Zeus',
                                        type: `C?????c`,
                                        red: item.bet * item.line,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (xoso) {
                                xoso.map(function(item, index) {
                                    logs.push({
                                        name: item.name,
                                        game: 'X??? S???',
                                        type: `C?????c ${item.so.join()}`,
                                        red: item.cuoc,
                                        red_c: item.win,
                                        time: item.time
                                    });
                                });
                            }
                            if (napthe) {
                                napthe.map(function(item, index) {
                                    var mgIndex = _.findIndex(menhgia, function(m) {
                                        return m.nap == true && m.name == item.menhGia;
                                    });
                                    var mg = 0;
                                    if (mgIndex >= 0) {
                                        mg = menhgia[mgIndex].values;
                                    }
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Th??? C??o',
                                        type: `N???p Th??? ${item.nhaMang}, Serial: ${item.seri}, Code: ${item.maThe}, Tr???ng Th??i: ${item.status == 0 ? '??ang Ch???' : item.status ==1 ? 'Th??nh C??ng' : 'Th???t B???i'}`,
                                        red: item.menhGia,
                                        red_c: mg,
                                        time: item.time
                                    });
                                });
                            }
                            if (muathe) {
                                muathe.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Th??? C??o',
                                        type: `Mua Th??? ${item.nhaMang}, S??? l?????ng: ${item.soLuong}`,
                                        red: item.menhGia,
                                        red_c: item.Cost,
                                        time: item.time
                                    });
                                });
                            }
                            if (bankNap) {
                                bankNap.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Ng??n H??ng',
                                        type: `N???p qua Ng??n h??ng ${item.bank}, CTK: ${item.name}, STK: ${item.number}, Tr???ng Th??i: ${item.status==0 ? '??ang Ch???' : item.status==1 ? 'Th??nh C??ng' : 'Th???t B???i'}`,
                                        red: item.money,
                                        red_c: item.money,
                                        time: item.time
                                    });
                                });
                            }
                            if (bankRut) {
                                bankRut.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Ng??n H??ng',
                                        type: `R??t qua Ng??n h??ng ${item.bank}, CTK: ${item.name}, STK: ${item.number}, Tr???ng Th??i: ${item.status==0 ? '??ang Ch???' : item.status==1 ? 'Th??nh C??ng' : 'Th???t B???i'}`,
                                        red: item.money,
                                        red_c: item.money,
                                        time: item.time
                                    });
                                });
                            }
                            if (giftcode) {
                                giftcode.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'GiftCode',
                                        type: `N???p GiftCode: ${item.code}  Time: ${moment(item.timeUse).format('DD/MM/YYYY HH:ss:ss')}`,
                                        red: item.red,
                                        red_c: item.red,
                                        time: item.timeUse
                                    });
                                });
                            }
                            if (ck) {
                                ck.map(function(item, index) {
                                    logs.push({
                                        name: userInfo.name,
                                        game: 'Chuy???n Kho???n',
                                        type: `${item.from==userInfo.name ? `Chuy???n kho???n ?????n: ${item.to}` : `Nh???n t???: ${item.from}`}`,
                                        red: item.red,
                                        red_c: item.red_c,
                                        time: item.time
                                    });
                                });
                            }
                            finalResult.logs = _.sortBy(logs, 'time').reverse();
                            res.json({
                                status: 200,
                                success: true,
                                data: finalResult
                            });
                        }, function(err) {
                            res.json({
                                status: 200,
                                success: true
                            });
                        });
                    break
            }
        });
};