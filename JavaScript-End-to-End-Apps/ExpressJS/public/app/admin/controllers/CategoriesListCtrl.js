"use strict";

app.controller("CategoriesListCtrl",
    function CategoriesListCtrl($scope, CategoryResource, sort) {
        var queryParams = { desc: true };

        updateCategoryData();

        $scope.sortBy = function(param) {
            sort.by(param, queryParams, updateCategoryData);
        };

        function updateCategoryData() {
            $scope.categories = CategoryResource.getAll.query(queryParams);
        }
    }
);