var Season = require('mongoose').model('Season');

module.exports = {
  create: function(season, callback) {
    Season.create(season, callback);
  },
  seedInitialSeasons: function() {
    Season.find({}).exec(function(err, collection) {
      if (collection.length === 0) {
        Season.create({
          name: "Started 2010"
        });
        Season.create({
          name: "Started 2011"
        });
        Season.create({
          name: "Started 2012"
        });
        Season.create({
          name: "Started 2013"
        });

        console.log("Seasons added to the database.");
      }
    });
  }
};
