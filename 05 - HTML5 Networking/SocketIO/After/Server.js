'use strict';
var express = require('express');
var app = express();
var server = require('http').createServer(app);
var io = require('socket.io').listen(server);
var util = require('util');

io.set('log level', 2);

app.use(express.static('public'));

app.get('/', function (req, res) {
    res.redirect('/default.html');
});

io.sockets.on('connection', function (socket) {

    socket.on('setUser', function (user) {
        user = user || 'Someone';
        var msg = util.format('%s is connected using the "%s" transport protocol', user, socket.transport);
        io.log.info(msg);

        socket.set('user', user);
        socket.broadcast.emit('broadcast', {
            msg: msg
        });
    });

    socket.on('send', function (data) {
        socket.get('user', function (err, user) {
            var msg = util.format('%s said: %s', user, data.msg);

            io.log.info(msg);

            socket.broadcast.emit('broadcast', {
                msg: msg
            });
        });
    });

    socket.on('disconnect', function () {
        socket.get('user', function (err, user) {
            var msg = util.format('%s is disconnecting.', user);

            io.log.info(msg);

            socket.broadcast.emit('broadcast', {
                msg: msg
            });
        });
    });
});

server.listen(8080, function () {
    io.log.info('The server is listening at port 8080');
});
