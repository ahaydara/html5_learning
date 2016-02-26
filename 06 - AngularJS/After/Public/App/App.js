/// <reference path="../../Scripts/angular.js" />

(function(angular) {
    "use strict";
    var app = angular.module("moviesApp", []);

    app.controller("MoviesCtrl", ["$scope",
        function($scope) {
            $scope.movies = movies;
            $scope.directors = directors;
            $scope.countries = countries;

            $scope.selectedMovie = null;

            $scope.select = function(movie) {
                $scope.selectedMovie = movie;
            };

            $scope.save = function() {
                $scope.selectedMovie = null;
            };
        }
    ]);

}(angular));