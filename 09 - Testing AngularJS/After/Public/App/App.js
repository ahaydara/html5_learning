/// <reference path="../../Scripts/angular.js" />
/// <reference path="../../Scripts/angular-route.js" />

(function () {
    "use strict";
    var app = angular.module("myApp", ["ngRoute", "ngAnimate", "myData"]);

    app.config(["$routeProvider",
        function ($routeProvider) {
            $routeProvider.when("/people", {
                templateUrl: "/Templates/PeopleList.html",
                controller: "PeopleListCtrl",
                resolve: {
                    people: ["Person", function (Person) {
                        return Person.query();
                    }]
                }
            });
            $routeProvider.when("/person/:id", {
                templateUrl: "/Templates/PersonEditor.html",
                controller: "PersonEditorCtrl",
                resolve: {
                    person: ["Person", "$route", function (Person, $route) {
                        return Person.get({
                            id: $route.current.params.id
                        });
                    }]
                }
            });
            $routeProvider.otherwise({
                redirectTo: "/people"
            });
        }
    ]);

    app.controller("PeopleListCtrl", ["$scope", "$location", "people",
        function ($scope, $location, people) {
            $scope.people = people;

            $scope.select = function (p) {
                $location.path("/person/" + p.id);
            };
        }
    ]);

    app.controller("PersonEditorCtrl", ["$scope", "$location", "person",
        function ($scope, $location, person) {

            $scope.currentPerson = person;

            $scope.cancel = function () {
                $location.path("/people");
            };

            $scope.save = function () {
                person.$save(function () {
                    $location.path("/people");
                });
            };
        }
    ]);
}());
