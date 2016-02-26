/// <reference path="../../Scripts/angular.js" />

(function (angular) {
    "use strict";

    var module = angular.module("contactsApp.data.people", ["ngResource"]);

    module.factory("peopleLoader", function ($resource) {
        return $resource('/api/people/:id', {
            id: '@id'
        }, {
            update: {
                method: 'PUT'
            }
        });
    });
}(angular));
