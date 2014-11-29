app.controller('PlayGameController', function ($scope, $location, authorization, identity, ticTacToeData, notifier) {
    'use strict';
    $scope.playGame = function (game) {
        if (identity.isAuthenticated() === true) {
            ticTacToeData.playGame(authorization.getAuthorizationHeader(), game)
                .then(function (data) {
                    $scope.firstRowFirstCol = data[1];
                    $scope.firstRowSecondCol = data[2];
                    $scope.firstRowThirdCol = data[3];
                    $scope.secondRowFirstCol = data[4];
                    $scope.secondRowSecondCol = data[5];
                    $scope.secondRowThirdCol = data[6];
                    $scope.thirdRowFirstCol = data[7];
                    $scope.thirdRowSecondCol = data[8];
                    $scope.thirdRowThirdCol = data[9];
                }, function () {
                    notifier.error('Invalid data!');
                });
        } else {
            notifier.error('Please login!');
            $location.path('/');
        }
    };
});