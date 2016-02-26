/// <reference path="../../Scripts/angular.js" />

(function (angular) {
    "use strict";

    var app = angular.module("contactsApp", ["contactsApp.data.people", "contactsApp.data.countries"]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/people", {
                templateUrl: "/Templates/Contacts/ContactsList.html",
                controller: 'ContactsListCtrl'
            })
            .when("/person/:id", {
                templateUrl: "/Templates/Contacts/ContactsEditor.html",
                controller: 'ContactsEditorCtrl'
            })
            .otherwise({ redirectTo: '/people' });
    });

    app.controller("ContactsListCtrl", function ($scope, peopleLoader) {
        $scope.people = peopleLoader.query();
    });

    app.controller("ContactsEditorCtrl", function ($scope, $routeParams, $location, peopleLoader, countryLoader) {
        $scope.person = peopleLoader.get({ id: $routeParams.id });
        $scope.countries = countryLoader.load();

        $scope.save = function () {
            alert("Saving person");
            $scope.person.$update(function () {
                $location.path("/people");
            }, function (err) {
                alert(JSON.stringify(err.data));
            });
        };

        $scope.cancel = function () {
            $location.path("/people");
        };
    });
}(angular));
