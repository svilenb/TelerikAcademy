app.controller('CreateGameController', function ($scope, $location, identity, authorization, ticTacToeData, notifier) {
    'use strict';
    $scope.createGame = function () {
        if (identity.isAuthenticated() === true) {
            ticTacToeData.createGame(authorization.getAuthorizationHeader())
                .then(function () {
                    notifier.success('Game created!');
                });
        } else {
            notifier.error('Please login!');
            $location.path('/');
        }
    };
});