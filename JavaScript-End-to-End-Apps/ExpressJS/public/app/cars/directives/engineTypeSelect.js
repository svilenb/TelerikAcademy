"use strict";

app.directive("engineTypeSelect", function(EngineTypeResource) {
    return {
        restrict: "A",
        templateUrl: "/partials/cars/engine-type-select",
        link: function(scope, element, attrs) {
            scope.engines = EngineTypeResource.query();
        },
        replace: true
    }
});