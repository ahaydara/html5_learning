'use strict';
// Load RESTify and underscore
var restify = require('restify');
var _ = require('underscore');

// routing used
var path = {
    movies: /^\/api\/movies$/,
    movie: /^\/api\/movies\/(\d+)$/
};

// Get movie data
var movies = require('./movies');
// Get response formatters
var formatters = require('./formatters');

// Create REST server
var server = restify.createServer({
    formatters: formatters
});

// Return a 406 for non supported content types
server.use(restify.acceptParser(server.acceptable));

// GET /api/movies
server.get(path.movies, function (req, res, next) {
    res.xmlElementName = "movie";
    res.send(movies);
});

// GET /api/movies/123
server.get(path.movie, function(req, res, next) {
    var id = +req.params[0];

    var movie = _.find(movies, function (m) {
        return m.id === id;
    });

    if (movie) {
        res.xmlElementName = "movie";
        res.send(movie);
    } else {
        res.status(404);
        res.end();
    }
});

server.listen(8080, function () {
    console.log('%s listening at %s', server.name, server.url);
});

