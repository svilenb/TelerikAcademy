"use strict";

app.controller("AddCategoryCtrl",
    function AddCategoryCtrl($scope, $location, CategoryResource, notifier, socket) {
        $scope.manipName = "Add new";
        $scope.buttonName = "ADD";

        $scope.manipulateCategory = function(name) {
            CategoryResource.getAll.save({ name: name },
                function (data) {
                    socket.emit('category added', data);                       
                    $location.path("/admin/categories");
                },
                function (response) {
                    notifier.error("An error occurred.");
                }
            );
        };
    }
);