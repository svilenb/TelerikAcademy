"use strict";

app.controller("MakesListCtrl",
    function MakesListCtrl($scope, MakeResource, sort) {
        var queryParams = { desc: true };

        updateMakeData();

        $scope.sortBy = function(param) {
            sort.by(param, queryParams, updateMakeData);
        };

        function updateMakeData() {
            $scope.makes = MakeResource.getAll.query(queryParams);
        }
    }
);