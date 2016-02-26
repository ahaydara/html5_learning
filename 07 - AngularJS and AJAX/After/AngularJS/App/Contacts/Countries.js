/// <reference path="../../Scripts/angular.js" />

(function (angular) {
    "use strict";
    var module = angular.module("contactsApp.data.countries", []);

    module.service("countryLoader", function ($http) {
        var countries = [];

        $http.get("/api/countries").success(function (data) {
            angular.forEach(data, function (country) {
                countries.push(country);
            });
        });

        this.load = function () {
            return countries;
        };
    });
}(angular));
