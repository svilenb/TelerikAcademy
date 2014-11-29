var mongoose = require('mongoose');
var User = require('../models/user');
var Message = require('../models/message');

function init(connectionString) {
    mongoose.connect(connectionString);
    var db = mongoose.connection;
    
    db.on('error', console.error.bind(console, 'Connection error: '));
    db.once('open', function (err) {
        if (err) {
            console.error(err.message);
        }
        
        console.log('Mongoose connected to: ' + connectionString);
    });
}

function registerUser(user) {
    var newUser = new User({
        username: user.username,
        password: user.password
    });
    
    return newUser.save(function (err) {
        if (err) {
            return err;
        }
        
        console.log('Registered user with username %s', user.username);
    });
}

function sendMessage(message) {
    User.findOne().where('username').equals(message.from)
        .exec(function (err, result) {
        if (err) {
            console.log('Cannot find the user');
        }
        
        var from = result;
        
        User.findOne().where('username').equals(message.to).exec(function (err, result) {
            if (err) {
                console.log('Cannot find the user');
            }
            
            var to = result;
            var newMessage = new Message({
                from: from._id,
                to: to._id,
                text: message.text
            });
            
            newMessage.save(function (err) {
                if (err) {
                    return err;
                }
                
                console.log('Added message from %s to %s', message.from, message.to);
            });
        });
    });
}

function getMessages(users, callback) {
    var from;
    var to;
    
    User.findOne({ username: users.with }).exec(function (err, result) {
        if (err) {
            console.log('Cannot find the user');
        }
        
        from = result;
        User.findOne({ username: users.and }).exec(function (err, result) {
            if (err) {
                console.log('Cannot find the user');
            }
            
            to = result;
            Message.find({ $or: [{ from: from, to: to }, { from: to, to: from }] }).exec(function (err, result) {
                if (err) {
                    console.log('There are no messages between the two users');
                    return;
                }
                
                callback(result);
            });
        });
    });
}

module.exports = {
    init: init,
    registerUser: registerUser,
    sendMessage: sendMessage,
    getMessages: getMessages
};