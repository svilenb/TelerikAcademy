var mongoose = require("mongoose");

var categorySchema = mongoose.Schema({
    name: { type: String, require: "{PATH} is required", unique: true }
});

var Category = mongoose.model("Category", categorySchema);

var seedInitialCategories = function() {
    Category.find({}).exec(function(err, collection) {
        if (collection.length === 0) {
            Category.create({ name: "Sedan" });
            Category.create({ name: "Coupe" });
            Category.create({ name: "Convertible" });
            Category.create({ name: "Hatchback" });
            Category.create({ name: "Estate" });
            Category.create({ name: "SUV" });
            Category.create({ name: "MPV" });

            console.log("Categories added to the database.");
        }
    });
};

module.exports.seedInitialCategories = seedInitialCategories;