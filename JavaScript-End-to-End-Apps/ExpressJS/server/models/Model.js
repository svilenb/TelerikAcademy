var mongoose = require("mongoose"),
    Make = mongoose.model("Make"),
    Schema = mongoose.Schema;

var modelSchema = mongoose.Schema({
    name: { type: String, require: "{PATH} is required" },
    make: {
        type: Schema.Types.ObjectId,
        require: "{PATH} is required",
        ref: "Make"
    }
});

var Model = mongoose.model("Model", modelSchema);
console.log();

var seedInitialModels = function() {
    Model.find({}).exec(function(err, collection) {
        if (collection.length === 0) {
            Make.findOne({ name: "Subaru" }).exec(function(err, make) {
                Model.create({ name: "Impreza", make: make });
                Model.create({ name: "Legacy", make: make });
                Model.create({ name: "Outback", make: make });
            });

            Make.findOne({ name: "Mitsubishi" }).exec(function(err, make) {
                Model.create({ name: "Lancer", make: make });
                Model.create({ name: "Eclipse", make: make });
                Model.create({ name: "Colt", make: make });
            });

            Make.findOne({ name: "Nissan" }).exec(function(err, make) {
                Model.create({ name: "GT-R", make: make });
                Model.create({ name: "Skyline GT-R R33", make: make });
                Model.create({ name: "Skyline GT-R R34", make: make });
            });

            console.log("Models added to the database.");
        }
    });
};

module.exports.seedInitialModels = seedInitialModels;