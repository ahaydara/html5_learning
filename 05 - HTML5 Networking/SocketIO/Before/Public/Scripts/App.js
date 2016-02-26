$(function () {
    'use strict';
    var msg = $('#msg');
    var msgs = $('#msgs');
    
    // ToDo: Create a connection to the server
    var socket = null;

    // ToDo: Tell the server about the user name stored in localStorage.username when connecting

    $('#user').val(localStorage.username)
        .blur(function () {
            var username = $(this).val();

            // ToDo: Tell the server about the updated user name when connecting

            localStorage.username = username;
        });

    $('#send').click(function () {
        var text = msg.val();

        // ToDo: Notify the server of the message the users wants to send

        $('<li>').text('I said: ' + text)
            .addClass('sendMessage')
            .prependTo(msgs);

        msg.val('').focus();
    });

    // ToDo: Subscribe to update notifications from the server and display the at the top of the list 
});
