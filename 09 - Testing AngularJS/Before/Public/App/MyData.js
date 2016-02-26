/// <reference path="../../Scripts/angular.js" />

(function () {
    "use strict";
    var app = angular.module("myData", ["ngResource"]);

    app.factory("Person", ['$resource',
      function ($resource) {
          return $resource("/api/people/:id", { id: '@id' }, {
              save: {
                  method: "PUT"
              }
          });
      }]);
}());

