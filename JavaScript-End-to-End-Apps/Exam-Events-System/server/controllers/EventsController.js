var path = require('path');
var auth = require('../config/auth');
var config = require('../config/config');
var eventsData = require('../data/events');

var CONTROLLER_NAME = 'events';
var PAGE_SIZE = 10;

module.exports = {
  getPassedEvents: function(req, res, next) {
    var cb = function(err, resultevents) {
      if (err) {
        console.log('Failed to get events: ' + err);
        return;
      }

      res.render('shared' + '/home', {
        events: resultevents
      });
    };

    eventsData.getPassedevents(cb);
  },
  getDetails: function(req, res, next) {
    var url = req.params.id;
    var cb = function(err, resultEvent) {
      if (err) {
        console.log('Failed to get event: ' + err);
        return;
      }

      res.render(CONTROLLER_NAME + '/details', {
        event: resultEvent[0]
      });
    };

    eventsData.getDetails(url, cb);
  },
  getMyActiveEvents: function(req, res, next) {
    var userId = req.user._id;
    var cb = function(err, resultEvents) {
      if (err) {
        console.log('Failed to get event: ' + err);
        return;
      }

      resultEvents.sort(function(a, b) {
        var currentDate = new Date();
        aDifferance = Math.abs(a.date - currentDate);
        bDifferance = Math.abs(b.date - currentDate);
        return aDifferance - bDifferance;
      });

      res.render(CONTROLLER_NAME + '/myevents', {
        events: resultEvents
      });
    };

    eventsData.getActiveEvents(userId, cb);
  },
  getCreateEvent: function(req, res, next) {
    res.render(CONTROLLER_NAME + '/create-event');
  },
  postNewEvent: function(req, res, next) {
    var username = req.user.username;
    var newEventData = req.body;
    newEventData.type = {};
    newEventData.type.initiative = newEventData.initiative;
    newEventData.type.season = newEventData.season;
    newEventData.username = username;
    newEventData.evaluation = 0;

    eventsData.create(newEventData, res);
  }
};
