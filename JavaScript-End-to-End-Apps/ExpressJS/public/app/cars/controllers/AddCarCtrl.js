"use strict";

app.controller("AddCarCtrl",
    function AddCarCtrl($scope) {
        $scope.carAdFormTitle = "Add new car ad";
        $scope.carAdFormButton = "ADD";

        $scope.sendData = function(adData) {
            console.log(adData);
        };
    }
);