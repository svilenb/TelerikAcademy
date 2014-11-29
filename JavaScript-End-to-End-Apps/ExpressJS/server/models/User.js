var mongoose = require('mongoose'),
    encryption = require('../utilities/encryption');

var userSchema = mongoose.Schema({
    username: { type: String, require: '{PATH} is required', unique: true },
    email: { type: String, require: "{PATH} is required", unique: true },
    representativeName: String,
    phoneNumber: String,
    salt: String,
    hashPass: String,
    roles: [String]
});

userSchema.method({
    authenticate: function(password) {
        return encryption.generateHashedPassword(this.salt, password) === this.hashPass;
    }
});

var User = mongoose.model('User', userSchema);

module.exports.seedInitialUsers = function() {
    User.find({}).exec(function(err, collection) {
        var salt,
            hashedPwd;

        if (err) {
            console.log('Cannot find users ' + err);
            return;
        }

        if (collection.length === 0) {
            salt = encryption.generateSalt();
            hashedPwd = encryption.generateHashedPassword(salt, "password");

            User.create({username: 'gosho', email: "zzz@z.c", phoneNumber: "+1888 332 544", salt: salt, hashPass: hashedPwd, roles: ['admin']});
            User.create({username: 'misho', email: "noemail@gmail.no", representativeName: "Seller", salt: salt, hashPass: hashedPwd, roles: ['standard']});
            User.create({username: 'pesho', email: "pesho@guzara.com", salt: salt, hashPass: hashedPwd});

            console.log('Users added to database...');
        }
    });
};