"use strict";

app.controller("ModelsListCtrl",
    function ModelsListCtrl($scope, ModelResource, sort, paging) {
        $scope.page = 1;
        var queryParams = {
            page: 1,
            desc: false
        };

        updateModelData();

        $scope.sortBy = function(param) { sort.by(param, queryParams, updateModelData); };
        $scope.prevPage = function() { paging.prev($scope, queryParams, updateModelData); };
        $scope.setPage = function() { paging.set($scope, queryParams, updateModelData); };
        $scope.nextPage = function() { paging.next($scope, queryParams, updateModelData); };

        function updateModelData() {
            $scope.models = ModelResource.getAll.query(queryParams);
        }
    }
);