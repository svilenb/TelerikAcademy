var mongoose = require('mongoose');
var fs = require('fs');
var path = require('path');
var auth = require('../config/auth');
var config = require('../config/config');

//var Car = require('../models/Car'),
//    Car = require('mongoose').model('Car');
var PAGE_SIZE = 10;

var Car = mongoose.model("Car");

function filterBetween(from, to) {
    var filter;

    if (from && to) {
        filter = { $gte: from, $lte: to };
    } else if (from) {
        filter = { $gte: from };
    } else if (to) {
        filter = { $lte: to };
    }

    return filter;
}

function addCar(data, res) {
    var create,
        Model = mongoose.model("Model"),
        User = mongoose.model("User"),
        EngineType = mongoose.model("EngineType"),
        GearboxType = mongoose.model("GearboxType"),
        Category = mongoose.model("Category"),
        Region = mongoose.model("Region"),
        Color = mongoose.model("Color");

    create = {
        data: function (filters) {
            Model.findOne({ name: filters.model }).populate("make")
                .exec(function (err, model) {
                    var obj = {};
                    obj.model = model;

                    create._getUsers(filters, obj);
                });
        },
        _getUsers: function (filters, dataObject) {
            User.findOne({ username: filters.username }).exec(function (err, user) {
                dataObject.user = user;

                create._getEngineTypes(filters, dataObject);
            });
        },
        _getEngineTypes: function (filters, dataObject) {
            EngineType.findOne({ name: filters.engineType }).exec(function (err, engine) {
                dataObject.engineType = engine;

                create._getGearboxType(filters, dataObject);
            });
        },
        _getGearboxType: function (filters, dataObject) {
            GearboxType.findOne({ name: filters.gearboxType }).exec(function (err, gearbox) {
                dataObject.gearboxType = gearbox;

                create._getCategory(filters, dataObject);
            });
        },
        _getCategory: function (filters, dataObject) {
            Category.findOne({ name: filters.category }).exec(function (err, category) {
                dataObject.category = category;

                create._getColor(filters, dataObject);
            });
        },
        _getColor: function (filters, dataObject) {
            Color.findOne({ name: filters.color }).exec(function (err, color) {
                dataObject.color = color;

                create._getRegion(filters, dataObject);
            });
        },
        _getRegion: function(filters, dataObject) {
            Region.findOne({ name: filters.region }).exec(function(err, region) {
                dataObject.region = region;

                create._finish(filters, dataObject);
            });
        },
        _finish: function (filters, data) {
            Car.create({
                make: data.model.make,
                model: data.model,
                user: data.user,
                engineType: data.engineType,
                gearboxType: data.gearboxType,
                category: data.category,
                color: data.color,
                price: filters.price,
                yearOfProduction: filters.yearOfProduction,
                mileage: filters.mileage,
                horsepower: filters.horsepower,
                engineDisplacement: filters.engineDisplacement,
                region: data.region,
                photoUrl: filters.photoUrl,
                description: filters.description,
                published: new Date()
            }, function (err, car) {
                if (err) {
                    console.log('Failed to create new car: ' + err);
                    return;
                }

                if (res !== null && res !== "seed") {
                    res.redirect("http://localhost:3030/#/cars/my-ads"); // WARNING: VERY BAD; FIND ALTERNATIVE
                    //res.send(car);
                }
            });
        }
    };

    create.data(data);
}

module.exports = {
    getAllCars: function (req, res) {

        var page = req.query.page || 0;
        var sortCarsBy = req.query.sortBy;
        var isAscending = !!req.query.asc;
        var sortValue = 1;

        if (!isAscending) {
            sortValue = -1;
        }

        Car.find({})
            .populate('user gearboxType engineType make model')
            .skip(page * PAGE_SIZE)
            .limit(PAGE_SIZE)
            .sort({ sortCarsBy: 1 })
            .exec(function (err, collection) {
                if (err) {
                    console.log('Cars could not be loaded: ' + err);
                }

                res.send(collection);
            })
    },
    getCarById: function (req, res, next) {
        Car.findOne({ _id: req.params.id })
            .populate('make model engineType gearboxType color category user region')
            .exec(function (err, car) {
                if (err) {
                    console.log('Car could not be loaded: ' + err);
                    res.status('400');
                    return res.send('Car could not be loaded');
                }

                res.send(car);
            });
    },
    searchCar: function (req, res) {
        var conditions = {},
            Make = mongoose.model("Make"),
            Model = mongoose.model("Model"),
            GearboxType = mongoose.model("GearboxType"),
            EngineType = mongoose.model("EngineType");

        for (var key in req.query) {
            if (req.query.hasOwnProperty(key)) {
                conditions[key] = req.query[key];
            }
        }

        var searchQuery = {
            init: function(cond) {
                Make.findOne({ name: cond.make }).exec(function(err, make) {
                    var filter = {};
                    if (make) {
                        filter.make = make._id;
                    }

                    searchQuery._filterModel(cond, filter);
                });
            },
            _filterModel: function(cond, filter) {
                Model.findOne({ name: cond.model }).exec(function(err, model) {
                    if (model) {
                        filter.model = model._id;
                    }
                    // TODO Something
                    searchQuery._filterGearbox(cond, filter);
                });
            },
            _filterGearbox: function(cond, filter) {
                GearboxType.findOne({ name: cond.gearboxType }).exec(function(err, gearbox) {
                    if (gearbox) {
                        filter.gearboxType = gearbox._id;
                    }

                    searchQuery._filterEngine(cond, filter);
                });
            },
            _filterEngine: function(cond, filter) {
                EngineType.findOne({ name: cond.engineType }).exec(function(err, engine) {
                    if (engine) {
                        filter.engineType = engine._id;
                    }

                    searchQuery._filterCar(cond, filter);
                });
            },
            _filterCar: function(cond, filter) {
                var year = filterBetween(cond.yearFrom, cond.yearTo);
                var price = filterBetween(cond.fromPrice, cond.toPrice);
                var page = cond.page - 1;
                var sortObject = {};
                var sortCriteria;
                var ascDesc;

                if (cond.sortBy) {
                    sortCriteria = cond.sortBy;
                    ascDesc = 1;

                    if (cond.desc == "true") {
                        ascDesc = -1;
                    }

                    sortObject[sortCriteria] = ascDesc;
                }

                if (cond.isMine) {
                    filter.user = req.user._id;
                }

                if (year) {
                    filter.yearOfProduction = year;
                }

                if (price) {
                    filter.price = price;
                }

                Car.find(filter)
                    .select("make model engineType gearboxType price yearOfProduction photoUrl")
                    .populate("make", "name -_id")
                    .populate("model", "name -_id")
                    .populate("engineType", "name -_id")
                    .populate("gearboxType", "name -_id")
                    .sort(sortObject)
                    .skip(page * PAGE_SIZE)
                    .limit(PAGE_SIZE)
                    .exec(function(err, cars) {
                        if (err) {
                            console.log("An error occurred while fetching cars: " + err);
                        }

                        res.send(cars);
                    });
            }
        };

        searchQuery.init(conditions);
    },
    createCar: function (req, res, next) {
        var fstream;
        var car = {};

        req.pipe(req.busboy);

        req.busboy.on('file', function (fieldname, file, filename) {
            var filePath = config.rootPath + 'public\\img\\cars\\' + filename;
            fstream = fs.createWriteStream(filePath);
            file.pipe(fstream);
            car.photoUrl = '\\img\\cars\\' + filename;
        });

        req.busboy.on('field', function (fieldname, val) {
            car[fieldname] = val;
        });

        req.busboy.on('finish', function () {
            mongoose.model("User").findOne({ _id: req.user._id }).exec(function(err, user) {
                car.published = new Date();
                car.username = user.username;
                console.log(car);

                addCar(car, res);
            });
        });
    },
    addCar: addCar,
    getPicture: function (req, res) {
        Car.findOne({ _id: req.params.id }).exec(function (err, car) {
            if (err) {
                res.status('400');
                return res.send("There no such car");
            }

            if (req.query.attachment === 'true') {
                res.download(car.photoUrl);
            } else {
                res.sendFile(path.resolve(car.photoUrl));
            }
        });
    }
};