var mongoose = require("mongoose");

var engineTypeSchema = mongoose.Schema({
    name: { type: String, require: "{PATH} is required", unique: true }
});

var EngineType = mongoose.model("EngineType", engineTypeSchema);

var seedInitialEngineTypes = function() {
    EngineType.find({}).exec(function(err, collection) {
        if (collection.length === 0) {
            EngineType.create({ name: "Gasoline" });
            EngineType.create({ name: "Diesel" });

            console.log("Engine types added to the database.");
        }
    });
};

module.exports.seedInitialEngineTypes = seedInitialEngineTypes;