module.exports = function (io) {
    io.on('connection', function (socket) {
        socket.on('make added', function (data) {
            io.emit('make added', data);
        });

        socket.on('model added', function (data) {
            io.emit('model added', data);
        });

        socket.on('category added', function (data) {
            io.emit('category added', data);
        });
    });
};