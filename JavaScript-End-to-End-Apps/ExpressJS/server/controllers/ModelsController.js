var mongoose = require('mongoose');
var Model = mongoose.model("Model");
var Make = mongoose.model("Make");
var PAGE_SIZE = 10;

module.exports = {
    createModel: function (req, res) {
        var isAdmin = req.user.roles.indexOf('admin') > -1;
        var newModel = req.body;

        if (!isAdmin) {
            res.status(400);
            return res.send({ reason: 'You do not have permissions!' });
        }

        if (!newModel.name) {
            res.status(400);
            res.send({ reason: "Model name is required!" });
            return;
        }

        if(!newModel.make) {
            res.status(400);
            res.send({ reason: "Make name is required!" })
        }

        Make.findOne({ name: newModel.make }).exec(function(err, make) {
            if (err) {
                res.status(500);
                return res.send({ reason: "Internal server error" });
            }

            Model.findOne({ name: newModel.name }).exec(function(err, model) {
                var outputModel;

                if (err) {
                    res.status(500);
                    return res.send({ reason: "Internal server error" });
                }

                if (model) {
                    res.status(400);
                    return res.send({ reason: "Make with this model already exists!" });
                }
                else {
                    outputModel = new Model({
                        name: newModel.name,
                        make: make
                    });

                    outputModel.save(function(err) {
                        res.send(outputModel);
                    });
                }
            });
        });

//        Model.find({ name: newModel.name }).exec(function (err, models) {
//            if (err) {
//                console.log('Model could not be loaded: ' + err);
//                res.status('500');
//                return res.send('Model could not be loaded');
//            }
//
//            if (models.length !== 0) {
//                res.status('400');
//                res.send('Model already exists');
//                return;
//            }
//
//            Model.create(newModel, function (err, model) {
//                if (err) {
//                    console.log('Failed to create new model: ' + err);
//                    res.status(400);
//                    res.send({ reason: "Failed to add model!" });
//                    return;
//                }
//
//                res.status(201);
//                res.location('/models/'+model._id);
//                res.send({
//                    id: newModel._id,
//                    name: newModel.name,
//                    make: newModel.make
//                });
//            });
//        });
    },

    updateModel: function (req, res) {
        var isAdmin = req.user.roles.indexOf('admin') > -1;
        var updatedModel = req.body;

        if (!isAdmin) {
            res.status(400);
            return res.send({ reason: 'You do not have permissions!' });
        }

        if (!updatedModel.name) {
            res.status(400);
            return res.send({ reason: "Name is missing!" });
        }

        Model.update({ _id: req.params.id }, updatedModel, function (err) {
            if (err) {
                console.log('Models could not be updated: ' + err);
                res.status('500');
                return res.send('Models could not be updated');
            }

            res.end();
        })
    },

    getAllModels: function (req, res) {
        var ascDesc = 1;
        var page = req.query.page - 1;

        if (req.query.desc == "true") {
            ascDesc = -1;
        }

        Model.find({})
            .select("make name _id")
            .populate("make", "name -_id")
            .sort({ "name": ascDesc })
            .skip(page * PAGE_SIZE)
            .limit(PAGE_SIZE)
            .exec(function (err, collection) {
                if (err) {
                    console.log('Models could not be loaded: ' + err);
                    res.status('500');
                    res.send('Models could not be loaded');
                    return;
                }

                res.send(collection);
            })
    },

    getModelByMake: function (req, res) {
        Make.findOne({ _id: req.query.make })
            .exec(function(err, make) {
                if (err) {
                    console.log('Model could not be loaded: ' + err);
                    res.status('500');
                    res.send('Model could not be loaded');
                    return;
                }

                if (make === null) {
                    res.status('400');
                    res.send("There no such model");
                    return;
                }

                Model.find({ make: make._id })
                    .select("name")
                    .exec(function(err, collection) {
                        if (err) {
                            console.log('Model could not be loaded: ' + err);
                            res.status('500');
                            res.send('Model could not be loaded');
                            return;
                        }

                        res.send(collection);
                    });
            });
    },

    getModelById: function (req, res) {
        Model.findOne({ _id: req.params.id })
            .select('name')
            .exec(function (err, model) {
                if (err) {
                    console.log('Model could not be loaded: ' + err);
                    res.status('500');
                    res.send('Model could not be loaded');
                    return;
                }

                if (model === null) {
                    res.status('400');
                    res.send("There no such model");
                    return;
                }

                res.send(model);
            })
    }
};