var mongoose = require('mongoose');
var Event = require('mongoose').model('Event');

var addEvent = function addEvent(data, res) {
  var create,
    Initiative = mongoose.model("Initiative"),
    User = mongoose.model("User"),
    Season = mongoose.model("Season"),
    Category = mongoose.model("Category");

  create = {
    data: function(filters) {
      Category.findOne({
          name: filters.category
        })
        .exec(function(err, category) {
          var obj = {};
          obj.category = category;

          create._getUsers(filters, obj);
        });
    },
    _getUsers: function(filters, dataObject) {
      User.findOne({
        username: filters.username
      }).exec(function(err, user) {
        dataObject.user = user;

        create._getInitiatives(filters, dataObject);
      });
    },
    _getInitiatives: function(filters, dataObject) {
      Initiative.findOne({
        name: filters.type.initiative
      }).exec(function(err, initiative) {
        dataObject.initiative = initiative;

        create._getSeasons(filters, dataObject);
      });
    },
    _getSeasons: function(filters, dataObject) {
      Season.findOne({
        name: filters.type.season
      }).exec(function(err, season) {
        dataObject.season = season;

        create._finish(filters, dataObject);
      });
    },
    _finish: function(filters, data) {
      Event.create({
        user: data.user,
        category: data.category,
        type: {
          season: data.season,
          initiative: data.initiative
        },
        title: filters.title,
        description: filters.description,
        location: {
          latitude: filters.latitude,
          longitude: filters.longitude
        },
        date: filters.date || new Date(),
        evaluation: filters.evaluation,
        comments: filters.comments
      }, function(err, event) {
        if (err) {
          console.log('Failed to create new event: ' + err);
          return;
        }

        if (res !== null && res !== "seed") {
          res.redirect("/");
        }
      });
    }
  };

  create.data(data);
};

module.exports = {
  create: function(event, res) {
    addEvent(event, res);
  },
  seedInitialEvents: function() {
    Event.find({}).exec(function(err, collection) {
      if (err) {
        console.log('Cannot find events: ' + err);
        return;
      }

      if (collection.length === 0) {
        addEvent({
          title: "Kupon",
          description: "Subiranie na vsi4ki ninji",
          username: "stamatov",
          latitude: 22.213,
          longitude: 32.21,
          type: {
            initiative: "Software Academy",
            season: "Started 2011"
          },
          category: "team building",
          date: new Date("October 13, 2012 11:13:00"),
          evaluation: 150,
          comments: ["can't wait", "super cool"]
        }, "seed");

        addEvent({
          title: "Kupon",
          description: "Subiranie na vsi4ki ninji",
          username: "stamatov",
          latitude: 22.213,
          longitude: 32.21,
          type: {
            initiative: "Algo Academy",
            season: "Started 2012"
          },
          category: "party",
          date: new Date("October 10, 2015 11:13:00"),
          evaluation: 100,
          comments: ["I like to party", "super cool"]
        }, "seed");

        addEvent({
          title: "Kupon",
          description: "Subiranie na vsi4ki ninji",
          username: "stamatov",
          latitude: 22.213,
          longitude: 32.21,
          type: {
            initiative: "Kids Academy",
            season: "Started 2012"
          },
          category: "party",
          date: new Date("October 10, 2014 11:13:00"),
          evaluation: 250,
          comments: ["I like to party", "super cool"]
        }, "seed");

        console.log("Events added to the database.");
      }
    });
  },
  getPassedevents: function(callback) {
    Event.find().where('date').lte(new Date()).exec(callback);
  },
  getDetails: function(id, callback) {
    Event.find({
      _id: id
    }).populate('user category initiative season').exec(callback);
  },
  getActiveEvents: function(userId, callback) {
    Event.find().where('user').equals(userId).gte(new Date()).exec(callback);
  }
};
