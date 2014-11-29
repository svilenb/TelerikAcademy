var encryption = require('../utilities/encryption');
var User = require('mongoose').model('User');

module.exports = {
    createUser: function(req, res, next) {
        var newUserData = req.body;

        newUserData.roles = ["standard"];

        if (!newUserData.confirmPassword || !newUserData.password) {
            res.status(400);
            return res.send({ reason: "Password(s) is/are missing!" });
        }

        if (newUserData.password !== newUserData.confirmPassword) {
            res.status(400);
            return res.send({ reason: "The passwords doesn't match!" });
        }

        newUserData.salt = encryption.generateSalt();
        newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);

        User.create(newUserData, function(err, user) {
            if (err) {
                console.log('Failed to register new user: ' + err);
                return;
            }

            req.logIn(user, function(err) {
                if (err) {
                    res.status(400);
                    return res.send({reason: err.toString()});
                }

                res.send(user);
            })
        });
    },
    updateUser: function(req, res, next) {
        var isAdmin = req.user.roles.indexOf('admin') > -1;

        if (req.user._id == req.body._id || isAdmin) {
            var updatedUserData = req.body,
                currentHashPass;

            if (!isAdmin) {
                if (!updatedUserData.currentPassword) {
                    res.status(400);
                    return res.send({ reason: "Authentication is mandatory!"});
                }

                currentHashPass = encryption.generateHashedPassword(req.user.salt, updatedUserData.currentPassword);

                if (currentHashPass !== req.user.hashPass) {
                    res.status(400);
                    return res.send({ reason : "The current password is incorrect!" });
                }
            }

            if (updatedUserData.password && updatedUserData.password.length > 0) {
                updatedUserData.salt = encryption.generateSalt();
                updatedUserData.hashPass = encryption.generateHashedPassword(updatedUserData.salt, updatedUserData.password);
            }

            User.update({_id: req.body._id}, updatedUserData, function() {
                res.end();
            })
        }
        else {
            res.status(400);
            res.send({reason: 'You do not have permissions!'})
        }
    },
    getAllUsers: function(req, res) {
        User.find({}).exec(function(err, collection) {
            if (err) {
                console.log('Users cannot be loaded: ' + err);
            }

            res.send(collection);
        })
    }
};