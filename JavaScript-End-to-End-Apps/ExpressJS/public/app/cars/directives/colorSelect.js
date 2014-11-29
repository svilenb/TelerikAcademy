"use strict";

app.directive("colorSelect", function(ColorResource) {
    return {
        restrict: "A",
        templateUrl: "/partials/cars/color-select",
        link: function(scope, element, attrs) {
            scope.colors = ColorResource.query();
        },
        replace: true
    }
});