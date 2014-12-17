var mongoose = require('mongoose'),
  UserModel = require('../data/models/User'),
  CategoryModel = require("../data/models/Category"),
  EventModel = require("../data/models/Event"),
  SeasonModel = require("../data/models/Season"),
  InitiativeModel = require("../data/models/Initiative"),
  InitiativeData = require("../data/initiatives"),
  SeasonData = require("../data/seasons"),
  Userdata = require("../data/users"),
  EventData = require("../data/events"),
  CategoryData = require("../data/categories");

module.exports = function(config) {
  mongoose.connect(config.db);
  var db = mongoose.connection;

  db.once('open', function(err) {
    if (err) {
      console.log('Database could not be opened: ' + err);
      return;
    }

    console.log('Database up and running...');
  });

  db.on('error', function(err) {
    console.log('Database error: ' + err);
  });

  CategoryData.seedInitialCategories();
  SeasonData.seedInitialSeasons();
  InitiativeData.seedInitialInitiatives();
  Userdata.seedInitialUsers();
  setTimeout(EventData.seedInitialEvents, 500);
};
