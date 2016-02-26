///<reference path="../Scripts/angular.js"/>

$(function () {
    "use strict";

    var module = angular.module("dmApp", []);

    module.controller("demoCtrl", function ($scope) {

        var countries = [{ country: "Albania", capital: "Tirana" },
            { country: "Andorra", capital: "Andorrala Vella" },
            { country: "Armenia", capital: "Yerevan" },
            { country: "Austria", capital: "Vienna" },
            { country: "Azerbaijan", capital: "Baku" },
            { country: "Belarus", capital: "Minsk" },
            { country: "Belgium", capital: "Brussels" },
            { country: "Bosniaand Herzegovina", capital: "Sarajevo" },
            { country: "Bulgaria", capital: "Sofia" },
            { country: "Croatia", capital: "Zagreb" },
            { country: "Cyprus", capital: "Nicosia" },
            { country: "Czech Republic", capital: "Prague" },
            { country: "Denmark", capital: "Copenhagen" },
            { country: "Estonia", capital: "Tallinn" },
            { country: "Finland", capital: "Helsinki" },
            { country: "France", capital: "Paris" },
            { country: "Georgia", capital: "Tbilisi" },
            { country: "Germany", capital: "Berlin" },
            { country: "Greece", capital: "Athens" },
            { country: "Hungary", capital: "Budapest" },
            { country: "Iceland", capital: "Reykjavík" },
            { country: "Ireland", capital: "Dublin" },
            { country: "Italy", capital: "Rome" },
            { country: "Kazakhstan", capital: "Astana" },
            { country: "Kosovo", capital: "Pristina" },
            { country: "Latvia", capital: "Riga" },
            { country: "Liechtenstein", capital: "Vaduz" },
            { country: "Lithuaniav", capital: "Vilnius" },
            { country: "Luxembourg", capital: "Luxembourg" },
            { country: "Macedonia", capital: "Skopje" },
            { country: "Malta", capital: "Valletta" },
            { country: "Moldova", capital: "Chișinău" },
            { country: "Monaco", capital: "Monaco" },
            { country: "Montenegro", capital: "Podgorica" },
            { country: "Netherlands", capital: "Amsterdam" },
            { country: "Norway", capital: "Oslo" },
            { country: "Poland", capital: "Warsaw" },
            { country: "Portugal", capital: "Lisbon" },
            { country: "Romania", capital: "Bucharest" },
            { country: "Russia", capital: "Moscow" },
            { country: "San Marino", capital: "San Marino" },
            { country: "Serbia", capital: "Belgrade" },
            { country: "Slovakia", capital: "Bratislava" },
            { country: "Slovenia", capital: "Ljubljana" },
            { country: "Spain", capital: "Madrid" },
            { country: "Sweden", capital: "Stockholm" },
            { country: "Switzerland", capital: "Bern" },
            { country: "Turkey", capital: "Ankara" },
            { country: "Ukraine", capital: "Kiev" },
            { country: "United Kingdom", capital: "London" },
            { country: "Vatican City", capital: "Vatican City" }];

        $scope.knownCapitals = countries.map(function (c) {
            return c.capital;
        });
        $scope.knownCountries = countries.map(function (c) {
            return c.country;
        });

        $scope.selectedCountries = [];
        $scope.currentCapital = "";
        $scope.currentCountry = "";

        $scope.addCountry = function () {
            var match = countries.reduce(function (current, country) {
                if (country.country === $scope.currentCountry && country.capital === $scope.currentCapital) {
                    return country;
                }
                return current;
            }, null);

            $scope.selectedCountries.push({
                country: $scope.currentCountry,
                capital: $scope.currentCapital,
                correct: !!match
            });

            $scope.currentCapital = "";
            $scope.currentCountry = "";
        };
    });
}());
