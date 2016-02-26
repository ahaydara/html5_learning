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
        $scope.people = peopleLoader.load();
    });

    app.controller("ContactsEditorCtrl", function ($scope, $routeParams, $location, peopleLoader, countryLoader) {
        var originalPerson = peopleLoader.get($routeParams.id);
        $scope.person = angular.copy(originalPerson);
        $scope.countries = countryLoader.load();

        $scope.save = function (frm) {
            if (frm.$valid) {
                alert("Saving person");
                angular.copy($scope.person, originalPerson);
                $location.path("/people");
            }
        };

        $scope.cancel = function () {
            $location.path("/people");
        };
    });
}(angular));
