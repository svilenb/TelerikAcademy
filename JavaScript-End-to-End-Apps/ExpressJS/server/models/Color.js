var mongoose = require("mongoose");

var colorScheme = mongoose.Schema({
    name: { type: String, require: "{PATH} is required", unique: true }
});

var Color = mongoose.model("Color", colorScheme);

var seedInitialColors = function() {
    Color.find({}).exec(function(err, collection) {
        if (collection.length === 0) {
            Color.create({ name: "Red" });
            Color.create({ name: "Blue" });
            Color.create({ name: "Green" });
            Color.create({ name: "White" });
            Color.create({ name: "Black" });

            console.log("Colors added to the database.");
        }
    });
};

module.exports.seedInitialColors = seedInitialColors;