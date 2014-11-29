"use strict";

app.directive("carModelsSelect", function(ModelResource) {
    return {
        restrict: "A",
        templateUrl: "/partials/cars/car-models-select",
        link: function(scope, element, attrs) {
            scope.getMakeModels = function(makeName) {
                scope.makes.forEach(function(item) {
                    if (item.name === makeName) {
                        scope.models = ModelResource.getByMake.query({ make: item._id });
                        return;
                    }
                });
            };
        },
        replace: true
    }
});