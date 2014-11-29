var path = require('path');
var rootPath = path.normalize(__dirname + '/../../');

module.exports = {
    development: {
        rootPath: rootPath,
        db: 'mongodb://localhost/autotraderdb',
        port: process.env.PORT || 3030
    },
    production: {
        rootPath: rootPath,
        db: "mongodb://admin:autotraderdb@ds063909.mongolab.com:63909/autotraderdb",
        port: process.env.PORT || 3030
    },
    rootPath: rootPath
};