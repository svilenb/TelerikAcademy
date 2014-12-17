var User = require('mongoose').model('User');
var encryption = require('../utilities/encryption');

module.exports = {
  create: function(user, callback) {
    User.create(user, callback);
  },
  seedInitialUsers: function() {
    User.find({}).exec(function(err, collection) {
      var salt,
        hashedPwd;

      if (collection.length === 0) {
        salt = encryption.generateSalt();
        hashedPwd = encryption.generateHashedPassword(salt, '123456');

        User.create({
          username: "stamatov",
          eventPoints: 0,
          firstName: "stamatov",
          lastName: "stamatov",
          phoneNumber: "0888888888",
          email: "stamatov@stamatov.com",
          salt: salt,
          hashPass: hashedPwd,
          avatar: '\\img\\users\\stamatov\\baby-duck.jpg'
        });

        console.log("Users added to the database.");
      }
    });
  },
  updateById: function(id, data, callback) {
    User.update({
      _id: id
    }, {
      $set: data
    }, callback);
  }
};
