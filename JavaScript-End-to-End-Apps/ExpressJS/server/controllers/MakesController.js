var mongoose = require('mongoose');
var Make = mongoose.model("Make");
var PAGE_SIZE = 10;

module.exports = {
//    getAllMakes: function (req, res) {
//        Make.find({}).select('_id name').exec(function (err, collection) {
//            if (err) {
//                console.log('Makes could not be loaded: ' + err);
//                res.status('500');
//                res.send('Makes could not be loaded');
//                return;
//            }
//
//            res.send(collection);
//        })
//    },
    getAllMakes: function(req, res) {
        var ascDesc = 1;

        if (req.query.desc == "true") {
            ascDesc = -1;
        }

        Make.find({})
            .sort({ "name": ascDesc })
            .exec(function (err, collection) {
            if (err) {
                console.log('Makes could not be loaded: ' + err);
                res.status('500');
                res.send('Makes could not be loaded');
                return;
            }

            res.send(collection);
        })
    },
    getMakeById: function (req, res, next) {
        Make.findOne({ _id: req.params.id }).select('name').exec(function (err, make) {
            if (err) {
                console.log('Make could not be loaded: ' + err);
                res.status('500');
                res.send('Make could not be loaded');
                return;
            }

            if (make === null) {
                res.status('400');
                res.send("There no such make");
            }
            else {
                res.send(make);
            }
        })
    },
    createMake: function (req, res) {
        var isAdmin = req.user.roles.indexOf('admin') > -1;
        var newMake = req.body;

        if (isAdmin) {
            if (!newMake.name) {
                res.status(400);
                res.send({ reason: "Make name is missing!" });
                return;
            }

            Make.find({ name: newMake.name }).exec(function (err, makes) {
                if (err) {
                    console.log('Make could not be loaded: ' + err);
                    res.status('500');
                    res.send('Make could not be loaded');
                    return;
                }

                if (makes.length !== 0) {
                    res.status('400');
                    res.send('There is already such make');
                    return;
                }

                Make.create(newMake, function (err, make) {
                    if (err) {
                        console.log('Failed to create new make: ' + err);
                        res.status(400);
                        res.send({ reason: "Failed to add make!" });
                        return;
                    }

                    res.send({
                        id: make._id,
                        name: make.name
                    });
                });
            });
        } else {
            res.status(400);
            res.send({ reason: 'You do not have permissions!' })
        }
    },
    updateMake: function (req, res) {
        var isAdmin = req.user.roles.indexOf('admin') > -1;
        var updatedMakeData = req.body;

        if (isAdmin) {
            if (!updatedMakeData.name) {
                res.status(400);
                return res.send({ reason: "Name is missing!" });
            }

            Make.update({ _id: req.params.id }, updatedMakeData, function (err) {
                if (err) {
                    console.log('Makes could not be updated: ' + err);
                    res.status('500');
                    res.send('Makes could not be updated');
                    return;
                }

                res.end();
            })
        } else {
            res.status(400);
            res.send({ reason: 'You do not have permissions!' })
        }
    }
};