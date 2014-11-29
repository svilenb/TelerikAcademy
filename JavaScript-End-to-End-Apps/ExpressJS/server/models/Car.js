var mongoose = require('mongoose'),
    REQUIRED = "{PATH} is required",
    config = require('../config/config'),
    picturesPath = '\\img\\cars\\',
    Schema = mongoose.Schema;

var carSchema = mongoose.Schema({
    make: {
        type: Schema.Types.ObjectId, require: REQUIRED,
        ref: "Make"
    },
    model: {
        type: Schema.Types.ObjectId, require: REQUIRED,
        ref: "Model"
    },
    user: {
        type: Schema.Types.ObjectId, require: REQUIRED,
        ref: "User"
    },
    engineType: {
        type: Schema.Types.ObjectId, require: REQUIRED,
        ref: "EngineType"
    },
    gearboxType: {
        type: Schema.Types.ObjectId, require: REQUIRED,
        ref: "GearboxType"
    },
    category: {
        type: Schema.Types.ObjectId, require: REQUIRED,
        ref: "Category"
    },
    region: {
        type: Schema.Types.ObjectId,
        ref: "Region"
    },
    color: {
        type: Schema.Types.ObjectId,
        ref: "Color"
    },
    price: { type: Number, require: REQUIRED },
    yearOfProduction: { type: Number, require: REQUIRED },
    mileage: { type: Number, require: REQUIRED },
    horsepower: Number,
    engineDisplacement: Number,
    description: String,
    photoUrl: String,
    published: Date
});

var Car = mongoose.model('Car', carSchema);

module.exports.seedInitialCars = function() {
    Car.find({}).exec(function(err, collection) {
        var carsController = require("../controllers/carsController");

        if (err) {
            console.log('Cannot find cars: ' + err);
            return;
        }

        if (collection.length === 0) {
            carsController.addCar({
                make: "Subaru",
                model: "Impreza",
                username: "misho",
                engineType: "Gasoline",
                gearboxType: "Sequential",
                category: "Sedan",
                color: "Blue",
                price: 24500,
                yearOfProduction: 2004,
                mileage: 54000,
                horsepower: 275,
                engineDisplacement: 2000,
                region: "Sofia",
                photoUrl: picturesPath + "Subaru-Impreza-22b-sti-bright.jpg",
                description: "Random description"
            }, "seed");

            carsController.addCar({
                make: "Nissan",
                model: "Skyline GT-R R34",
                username: "gosho",
                engineType: "Gasoline",
                gearboxType: "Manual",
                category: "Coupe",
                color: "Red",
                price: 55000,
                yearOfProduction: 1998,
                mileage: 25000,
                horsepower: 550,
                engineDisplacement: 2962,
                region: "Varna",
                photoUrl: picturesPath + "skylinegtr.jpg",
                description: "Asen"
            }, "seed");

            carsController.addCar({
                make: "Mitsubishi",
                model: "Eclipse",
                username: "pesho",
                engineType: "Gasoline",
                gearboxType: "Automatic",
                category: "Coupe",
                color: "Green",
                price: 10000,
                yearOfProduction: 1998,
                mileage: 120000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Plovdiv",
                photoUrl: picturesPath + "Mitsubishi_Eclipse_front_20080801.jpg",
                description: "New brake pads and flywheel."
            }, "seed");

            carsController.addCar({
                make: "Mitsubishi",
                model: "Lancer",
                username: "pesho",
                engineType: "Gasoline",
                gearboxType: "Manual",
                category: "Sedan",
                color: "White",
                price: 15000,
                yearOfProduction: 2005,
                mileage: 120000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Bourgas",
                photoUrl: picturesPath + "2002-2003_Mitsubishi_Lancer_(CG)_LS_sedan_(2011-10-25).jpg",
                description: "Very cool car!"
            }, "seed");

             carsController.addCar({
                make: "Subaru",
                model: "Legacy",
                username: "gosho",
                engineType: "Gasoline",
                gearboxType: "Manual",
                category: "Sedan",
                color: "Black",
                price: 20000,
                yearOfProduction: 1992,
                mileage: 130000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Bourgas",
                photoUrl: picturesPath + "08-Subaru-Legacy-SpecB.jpg",
                description: "Very cool car!"
             }, "seed");

            carsController.addCar({
                make: "Subaru",
                model: "Outback",
                username: "pesho",
                engineType: "Diesel",
                gearboxType: "Manual",
                category: "Hatchback",
                color: "White",
                price: 30000,
                yearOfProduction: 2008,
                mileage: 130000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Varna",
                photoUrl: picturesPath + "2014_subaru_outback_upgrade_web.jpg",
                description: "Very cool car!"
            }, "seed");

             carsController.addCar({
                make: "Nissan",
                model: "GT-R",
                username: "pesho",
                engineType: "Diesel",
                gearboxType: "Manual",
                category: "Coupe",
                color: "White",
                price: 150000,
                yearOfProduction: 2010,
                mileage: 10000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Varna",
                photoUrl: picturesPath + "Nissan_GT-R_01.JPG",
                description: "Very cool car!"
             }, "seed");

            carsController.addCar({
                make: "Subaru",
                model: "Impreza",
                username: "misho",
                engineType: "Gasoline",
                gearboxType: "Sequential",
                category: "Sedan",
                color: "Blue",
                price: 30500,
                yearOfProduction: 2003,
                mileage: 54000,
                horsepower: 275,
                engineDisplacement: 2000,
                region: "Sofia",
                photoUrl: picturesPath + "Subaru-Impreza-22b-sti-bright.jpg",
                description: "Random description"
            }, "seed");

            carsController.addCar({
                make: "Nissan",
                model: "Skyline GT-R R34",
                username: "gosho",
                engineType: "Gasoline",
                gearboxType: "Manual",
                category: "Coupe",
                color: "Red",
                price: 65000,
                yearOfProduction: 200,
                mileage: 25000,
                horsepower: 550,
                engineDisplacement: 2962,
                region: "Varna",
                photoUrl: picturesPath + "skylinegtr.jpg",
                description: "Asen"
            }, "seed");

            carsController.addCar({
                make: "Mitsubishi",
                model: "Eclipse",
                username: "pesho",
                engineType: "Gasoline",
                gearboxType: "Automatic",
                category: "Coupe",
                color: "Green",
                price: 12000,
                yearOfProduction: 1996,
                mileage: 120000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Plovdiv",
                photoUrl: picturesPath + "Mitsubishi_Eclipse_front_20080801.jpg",
                description: "New brake pads and flywheel."
            }, "seed");

            carsController.addCar({
                make: "Mitsubishi",
                model: "Lancer",
                username: "pesho",
                engineType: "Gasoline",
                gearboxType: "Manual",
                category: "Sedan",
                color: "White",
                price: 25000,
                yearOfProduction: 2003,
                mileage: 120000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Bourgas",
                photoUrl: picturesPath + "2002-2003_Mitsubishi_Lancer_(CG)_LS_sedan_(2011-10-25).jpg",
                description: "Very cool car!"
            }, "seed");

             carsController.addCar({
                make: "Subaru",
                model: "Legacy",
                username: "gosho",
                engineType: "Gasoline",
                gearboxType: "Manual",
                category: "Sedan",
                color: "Black",
                price: 24000,
                yearOfProduction: 1994,
                mileage: 130000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Bourgas",
                photoUrl: picturesPath + "08-Subaru-Legacy-SpecB.jpg",
                description: "Very cool car!"
             }, "seed");

            carsController.addCar({
                make: "Subaru",
                model: "Outback",
                username: "pesho",
                engineType: "Diesel",
                gearboxType: "Manual",
                category: "Hatchback",
                color: "White",
                price: 35000,
                yearOfProduction: 2007,
                mileage: 130000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Varna",
                photoUrl: picturesPath + "2014_subaru_outback_upgrade_web.jpg",
                description: "Very cool car!"
            }, "seed");

             carsController.addCar({
                make: "Nissan",
                model: "GT-R",
                username: "pesho",
                engineType: "Diesel",
                gearboxType: "Manual",
                category: "Coupe",
                color: "White",
                price: 140000,
                yearOfProduction: 2010,
                mileage: 10000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Varna",
                photoUrl: picturesPath + "Nissan_GT-R_01.JPG",
                description: "Very cool car!"
             }, "seed");

            carsController.addCar({
                make: "Subaru",
                model: "Impreza",
                username: "misho",
                engineType: "Gasoline",
                gearboxType: "Sequential",
                category: "Sedan",
                color: "Blue",
                price: 25000,
                yearOfProduction: 2005,
                mileage: 54000,
                horsepower: 275,
                engineDisplacement: 2000,
                region: "Sofia",
                photoUrl: picturesPath + "Subaru-Impreza-22b-sti-bright.jpg",
                description: "Random description"
            }, "seed");

            carsController.addCar({
                make: "Nissan",
                model: "Skyline GT-R R34",
                username: "gosho",
                engineType: "Gasoline",
                gearboxType: "Manual",
                category: "Coupe",
                color: "Red",
                price: 52000,
                yearOfProduction: 1996,
                mileage: 25000,
                horsepower: 550,
                engineDisplacement: 2962,
                region: "Varna",
                photoUrl: picturesPath + "skylinegtr.jpg",
                description: "Asen"
            }, "seed");

            carsController.addCar({
                make: "Mitsubishi",
                model: "Eclipse",
                username: "pesho",
                engineType: "Gasoline",
                gearboxType: "Automatic",
                category: "Coupe",
                color: "Green",
                price: 13000,
                yearOfProduction: 1999,
                mileage: 120000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Plovdiv",
                photoUrl: picturesPath + "Mitsubishi_Eclipse_front_20080801.jpg",
                description: "New brake pads and flywheel."
            }, "seed");

            carsController.addCar({
                make: "Mitsubishi",
                model: "Lancer",
                username: "pesho",
                engineType: "Gasoline",
                gearboxType: "Manual",
                category: "Sedan",
                color: "White",
                price: 12000,
                yearOfProduction: 2002,
                mileage: 120000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Bourgas",
                photoUrl: picturesPath + "2002-2003_Mitsubishi_Lancer_(CG)_LS_sedan_(2011-10-25).jpg",
                description: "Very cool car!"
            }, "seed");

             carsController.addCar({
                make: "Subaru",
                model: "Legacy",
                username: "gosho",
                engineType: "Gasoline",
                gearboxType: "Manual",
                category: "Sedan",
                color: "Black",
                price: 21000,
                yearOfProduction: 1992,
                mileage: 130000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Bourgas",
                photoUrl: picturesPath + "08-Subaru-Legacy-SpecB.jpg",
                description: "Very cool car!"
             }, "seed");

            carsController.addCar({
                make: "Subaru",
                model: "Outback",
                username: "pesho",
                engineType: "Diesel",
                gearboxType: "Manual",
                category: "Hatchback",
                color: "White",
                price: 40000,
                yearOfProduction: 2009,
                mileage: 100000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Varna",
                photoUrl: picturesPath + "2014_subaru_outback_upgrade_web.jpg",
                description: "Very cool car!"
            }, "seed");

             carsController.addCar({
                make: "Nissan",
                model: "GT-R",
                username: "pesho",
                engineType: "Diesel",
                gearboxType: "Manual",
                category: "Coupe",
                color: "Black",
                price: 150000,
                yearOfProduction: 2008,
                mileage: 10000,
                horsepower: 320,
                engineDisplacement: 1997,
                region: "Varna",
                photoUrl: picturesPath + "Nissan_GT-R_01.JPG",
                description: "Very cool car!"
             }, "seed");
          

            console.log("Cars added to the database.");
        }
    });
};