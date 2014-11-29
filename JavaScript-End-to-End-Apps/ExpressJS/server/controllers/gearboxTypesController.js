var mongoose = require("mongoose");
var GearboxType = mongoose.model("GearboxType");

module.exports = {
    getAllGearboxTypes: function(req, res) {
        GearboxType.find({}).select('_id name').exec(function (err, collection) {
            if (err) {
                res.status('500');
                res.send({ message: 'Gearbox types could not be loaded' });
                return;
            }

            res.send(collection);
        })
    }
};