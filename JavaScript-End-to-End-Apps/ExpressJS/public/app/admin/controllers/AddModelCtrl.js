"use strict";

app.controller("AddModelCtrl",
    function AddModelCtrl($scope, $location, ModelResource, notifier, socket) {
        $scope.manipName = "Add new";
        $scope.buttonName = "ADD";

        $scope.manipulateModel = function(model) {
            ModelResource.getAll.save(model,
                function (data) {
                    socket.emit('model added', data);                      
                    $location.path("/admin/models");
                },
                function(response) {
                    console.log(response);
                    notifier.error("An error occurred.");
                }
            );
        }
    }
);