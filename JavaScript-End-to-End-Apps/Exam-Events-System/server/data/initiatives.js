var Initiative = require('mongoose').model('Initiative');

module.exports = {
  create: function(initiative, callback) {
    Initiative.create(initiative, callback);
  },
  seedInitialInitiatives: function() {
    Initiative.find({}).exec(function(err, collection) {
      if (collection.length === 0) {
        Initiative.create({
          name: "Software Academy"
        });
        Initiative.create({
          name: "Algo Academy"
        });
        Initiative.create({
          name: "School Academy"
        });
        Initiative.create({
          name: "Kids Academy"
        });

        console.log("Initiatives added to the database.");
      }
    });
  }
};
