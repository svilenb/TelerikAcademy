var mongoose = require("mongoose");
var Color = mongoose.model("Color");

module.exports = {
    getAllColors: function(req, res) {
        Color.find({}).select('_id name').exec(function (err, collection) {
            if (err) {
                res.status('500');
                res.send({ message: 'Colors could not be loaded' });
                return;
            }

            res.send(collection);
        })
    }
};