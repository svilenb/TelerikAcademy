"use strict";

app.directive("regionSelect", function(RegionResource) {
    return {
        restrict: "A",
        templateUrl: "/partials/cars/region-select",
        link: function(scope, element, attrs) {
            scope.regions = RegionResource.query();
        },
        replace: true
    }
});