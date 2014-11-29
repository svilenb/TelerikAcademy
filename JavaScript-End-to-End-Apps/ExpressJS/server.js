var express = require('express');
var env = process.env.NODE_ENV || 'development';
var app = express(),
    config = require('./server/config/config')[env];

require('./server/config/express')(app, config);
require('./server/config/mongoose')(config);
require('./server/config/passport')();
require('./server/config/routes')(app);

var io = require('socket.io')(app.listen(config.port));
require('./server/config/socket')(io);

console.log('Server running on port: ' + config.port);
console.log(env);