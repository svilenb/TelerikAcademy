app.controller('GameStatusController', function ($scope, $location, authorization, identity, ticTacToeData, notifier) {
    'use strict';
    $scope.getStatus = function (gameId) {
        if (identity.isAuthenticated() === true) {
            ticTacToeData.getGameStatus(authorization.getAuthorizationHeader(), gameId)
                .then(function (data) {
                    $scope.firstRowFirstCol = data.Board[0];
                    $scope.firstRowSecondCol = data.Board[1];
                    $scope.firstRowThirdCol = data.Board[2];
                    $scope.secondRowFirstCol = data.Board[3];
                    $scope.secondRowSecondCol = data.Board[4];
                    $scope.secondRowThirdCol = data.Board[5];
                    $scope.thirdRowFirstCol = data.Board[6];
                    $scope.thirdRowSecondCol = data.Board[7];
                    $scope.thirdRowThirdCol = data.Board[8];
                    $scope.firstPlayerName = data.FirstPlayerName;
                    $scope.secondPlayerName = data.SecondPlayerName;
                    $scope.state = data.State;
                }, function () {
                    notifier.error('Invalid data!');
                });
        } else {
            notifier.error('Please login!');
        }
    };
});