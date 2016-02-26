/// <reference path="../Scripts/angular.js" />

$(function () {
    "use strict";
    
    var module = angular.module("dmJQueryUI", []);

    module.directive("dmAutoComplete", function () {
        return {
            restrict: "A",
            require: "ngModel",
            scope: {
                source: "=dmAutoComplete"
            },
            link: function (scope, element, attrs, ctrl) {

                function setValue(event, ui) {
                    scope.$apply(function () {
                        ctrl.$setViewValue(ui.item.value);
                    });
                }

                scope.$watch("source", function (newValue) {
                    element.autocomplete({
                        source: newValue,
                        select: setValue,
                        focus: setValue
                    });
                }, true);
            }
        };
    });
}());