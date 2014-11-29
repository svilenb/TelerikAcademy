var mongoose = require("mongoose");
var Region = mongoose.model("Region");

module.exports = {
    getAllRegions: function(req, res) {
        Region.find({}).select('_id name').exec(function (err, collection) {
            if (err) {
                res.status('500');
                res.send({ message: 'Regions could not be loaded' });
                return;
            }

            res.send(collection);
        })
    }
};