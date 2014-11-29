"use strict";

app.directive("categorySelect", function(CategoryResource) {
    return {
        restrict: "A",
        templateUrl: "/partials/cars/category-select",
        link: function(scope, element, attrs) {
            scope.categories = CategoryResource.getAll.query();
        },
        replace: true
    }
});