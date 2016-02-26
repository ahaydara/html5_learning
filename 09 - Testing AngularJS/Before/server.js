'use strict';

var express = require('express');
var app = express();
var people = require('./people');

app.use(express.static('public'));
app.use(express.json());

app.get('/api/people', function (req, res) {
    res.send(people.getAll());
});

app.get('/api/people/:id', function (req, res) {
    res.send(people.get(req.params.id));
});

app.put('/api/people/:id', function (req, res) {
    res.send(people.save(req.params.id, req.body));
});

app.listen(process.env.PORT || 8080, function () {
    console.info('The server is listening at port ' + (process.env.PORT || 8080));
});
