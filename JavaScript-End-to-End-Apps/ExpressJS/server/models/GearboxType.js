var mongoose = require("mongoose");

var gearboxTypeSchema = mongoose.Schema({
    name: { type: String, require: "{PATH} is required", unique: true }
});

var GearboxType = mongoose.model("GearboxType", gearboxTypeSchema);

var seedInitialGearboxTypes = function() {
    GearboxType.find({}).exec(function(err, collection) {
        if (collection.length === 0) {
            GearboxType.create({ name: "Manual" });
            GearboxType.create({ name: "Sequential" });
            GearboxType.create({ name: "Semi-auto" });
            GearboxType.create({ name: "Automatic" });

            console.log("Gearbox types added to the database.");
        }
    });
};

module.exports.seedInitialGearboxTypes = seedInitialGearboxTypes;