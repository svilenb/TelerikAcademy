app.controller('JoinGameController', function ($scope, $location, authorization, identity, ticTacToeData, notifier) {
    'use strict';
    $scope.joinGame = function (gameId) {
        if (identity.isAuthenticated() === true) {
            ticTacToeData.joinGame(authorization.getAuthorizationHeader(), gameId)
                .then(function () {
                    notifier.success('Game joined!');
                }, function () {
                    notifier.error('Invalid data!');
                });
        } else {
            notifier.error('Please login!');
        }
    };

    $scope.joinRandomGame = function () {
        if (identity.isAuthenticated() === true) {
            ticTacToeData.joinRandomGame(authorization.getAuthorizationHeader())
                .then(function () {
                    notifier.success('Game joined!');
                });
        } else {
            notifier.error('Please login!');
        }
    }
});