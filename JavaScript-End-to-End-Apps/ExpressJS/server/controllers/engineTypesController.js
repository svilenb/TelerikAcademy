var mongoose = require("mongoose");
var EngineType = mongoose.model("EngineType");

module.exports = {
    getAllEngineTypes: function(req, res) {
        EngineType.find({}).select('_id name').exec(function (err, collection) {
            if (err) {
                res.status('500');
                res.send({ message: 'Engine types could not be loaded' });
                return;
            }

            res.send(collection);
        })
    }
};