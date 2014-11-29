var mongoose = require("mongoose");

var regionSchema = mongoose.Schema({
    name: { type: String, require: "{PATH} is required", unique: true }
});

var Region = mongoose.model("Region", regionSchema);

var seedInitialRegions = function() {
    Region.find({}).exec(function(err, collection) {
        if (collection.length === 0) {
            Region.create({ name: "Sofia" });
            Region.create({ name: "Plovdiv" });
            Region.create({ name: "Blagoevgrad" });
            Region.create({ name: "Pazardzhik" });
            Region.create({ name: "Yambol" });
            Region.create({ name: "Smolyan" });
            Region.create({ name: "Bourgas" });
            Region.create({ name: "Varna" });

            console.log("Regions added to the database.");
        }
    });
};

module.exports.seedInitialRegions = seedInitialRegions;