$(function () {
    'use strict';
    var msg = $('#msg');
    var msgs = $('#msgs');
    var socket = io.connect('http://localhost:8080');

    socket.on('connect', function () {
        socket.emit("setUser", localStorage.username);
    });

    $('#user').val(localStorage.username)
        .blur(function () {
            var username = $(this).val();
            socket.emit("setUser", username);
            localStorage.username = username;
        });

    $('#send').click(function () {
        var text = msg.val();
        socket.emit("send", { msg: text });

        $('<li>').text('I said: ' + text)
            .addClass('sendMessage')
            .prependTo(msgs);

        msg.val('').focus();
    });

    socket.on('broadcast', function (data) {
        $('<li>').text(data.msg)
            .addClass('receivedMessage')
            .prependTo(msgs);
    });
});
