"use strict";

app.controller("AddMakeCtrl",
    function AddMakeCtrl($scope, MakeResource, $location, notifier, socket) {
        $scope.manipName = "Add new";
        $scope.buttonName = "ADD";        

        $scope.manipulateMake = function (name) {
            MakeResource.getAll.save({ name: name },
                function (data) {
                    socket.emit('make added', data);                   
                    $location.path("/admin/makes");
                },
                function (response) {
                    notifier.error("An error occurred.");
                }
            );
        };
    }
);