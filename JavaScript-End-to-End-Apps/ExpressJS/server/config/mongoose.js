var mongoose = require('mongoose'),
    user = require('../models/User'),
    car = require('../models/Car'),
    make = require("../models/Make"),
    model = require("../models/Model"),
    gearboxType = require("../models/GearboxType"),
    engineType = require("../models/EngineType"),
    category = require("../models/Category"),
    color = require("../models/Color"),
    region = require("../models/Region");

module.exports = function(config) {
    mongoose.connect(config.db);

    var db = mongoose.connection;

    db.once('open', function(err) {
        if (err) {
            console.log('Database could not be opened ' + err);
            return;
        }

        console.log('Database running...')
    });

    db.on('error', function(err) {
        console.log('Database error ' + err);
    });

    user.seedInitialUsers();
    make.seedInitialMakes();
    setTimeout(model.seedInitialModels, 2000);
    gearboxType.seedInitialGearboxTypes();
    engineType.seedInitialEngineTypes();
    category.seedInitialCategories();
    color.seedInitialColors();
    region.seedInitialRegions();
    setTimeout(car.seedInitialCars, 5000);
};