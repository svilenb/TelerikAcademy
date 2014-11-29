"use strict";

app.directive("gearboxTypeSelect", function(GearboxTypeResource) {
    return {
        restrict: "A",
        templateUrl: "/partials/cars/gearbox-type-select",
        link: function(scope, element, attrs) {
            scope.gearboxes = GearboxTypeResource.query();
        },
        replace: true
    }
});