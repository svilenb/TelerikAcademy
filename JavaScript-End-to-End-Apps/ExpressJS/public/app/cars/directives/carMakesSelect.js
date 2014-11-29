"use strict";

app.directive("carMakesSelect", function(MakeResource) {
    return {
        restrict: "A",
        templateUrl: "/partials/cars/car-makes-select",
        link: function(scope, element, attrs) {
            scope.makes = MakeResource.getAll.query();
        },
        replace: true
    }
});