var mongoose = require("mongoose");

var makeSchema = mongoose.Schema({
    name: { type: String, require: "{PATH} is required", unique: true }
});

var Make = mongoose.model("Make", makeSchema);

var seedInitialMakes = function() {
    Make.find({}).exec(function(err, collection) {
        if (collection.length === 0) {
            Make.create({ name: "Honda" });
            Make.create({ name: "Nissan" });
            Make.create({ name: "Subaru" });
            Make.create({ name: "Toyota" });
            Make.create({ name: "Mazda" });
            Make.create({ name: "Mitsubishi" });
            Make.create({ name: "BMW" });
            Make.create({ name: "Mercedes-Benz" });
            Make.create({ name: "McLaren" });
            Make.create({ name: "Aston Martin" });
            Make.create({ name: "Jaguar" });
            Make.create({ name: "Ford" });

            console.log("Makes added to the database.");
        }
    });
};

module.exports.seedInitialMakes = seedInitialMakes;