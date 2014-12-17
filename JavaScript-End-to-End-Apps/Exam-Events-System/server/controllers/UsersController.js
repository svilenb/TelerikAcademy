var encryption = require('../utilities/encryption');
var users = require('../data/users');
var config = require('../config/config');
var fs = require('fs');
var eventsData = require('../data/events');

var env = process.env.NODE_ENV || 'development';

var CONTROLLER_NAME = 'users';

module.exports = {
  getRegister: function(req, res, next) {
    res.render(CONTROLLER_NAME + '/register');
  },
  postRegister: function(req, res, next) {
    var fstream;
    var newUserData = {};

    req.pipe(req.busboy);

    req.busboy.on('file', function(fieldname, file, filename) {
      if (!fs.existsSync(config[env].rootPath + 'public\\img\\users\\' + newUserData.username)) {
        fs.mkdirSync(config[env].rootPath + 'public\\img\\users\\' + newUserData.username);
      }

      var filePath = config[env].rootPath + 'public\\img\\users\\' + newUserData.username + '\\' + filename;
      fstream = fs.createWriteStream(filePath);
      file.pipe(fstream);
      newUserData.avatar = '\\img\\users\\' + newUserData.username + '\\' + filename;
    });

    req.busboy.on('field', function(fieldname, val) {
      newUserData[fieldname] = val;
    });

    req.busboy.on('finish', function() {
      if (newUserData.password != newUserData.confirmPassword) {
        req.session.error = 'Passwords do not match!';
        res.redirect('/register');
      } else {
        newUserData.salt = encryption.generateSalt();
        newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
        users.create(newUserData, function(err, user) {
          if (err) {
            console.log('Failed to register new user: ' + err);
            return;
          }

          req.logIn(user, function(err) {
            if (err) {
              res.status(400);
              return res.send({
                reason: err.toString()
              }); // TODO
            } else {
              res.redirect('/');
            }
          });
        });
      }
    });
  },
  changeProfile: function(req, res, next) {
    var fstream;
    var newUserData = {};
    var userId = req.user._id;
    var username = req.user.username;
    req.pipe(req.busboy);

    req.busboy.on('file', function(fieldname, file, filename) {
      var filePath = config[env].rootPath + 'public\\img\\users\\' + username + '\\' + filename;
      fstream = fs.createWriteStream(filePath);
      file.pipe(fstream);
      newUserData.avatar = '\\img\\users\\' + username + '\\' + filename;
    });

    req.busboy.on('field', function(fieldname, val) {
      newUserData[fieldname] = val;
    });

    req.busboy.on('finish', function() {
      var cb = function(err, user) {
        res.redirect('/profile');
      };

      users.updateById(userId, newUserData, cb);
    });
  },
  getLogin: function(req, res, next) {
    res.render(CONTROLLER_NAME + '/login');
  },
  getProfile: function(req, res, next) {
    var userId = req.user._id;
    var cb = function(err, resultEvents) {
      if (err) {
        console.log('Failed to get events: ' + err);
        return;
      }

      res.render(CONTROLLER_NAME + '/profile', {
        user: req.user,
        myEvents: resultEvents
      });
    };

    eventsData.getActiveEvents(userId, cb);
  },
};
