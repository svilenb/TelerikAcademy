app.controller('MyGamesController', function ($scope, $routeParams, identity, authorization, ticTacToeData, notifier, $location) {
    'use strict';
    $scope.page = parseInt($routeParams.page);

    if (identity.isAuthenticated() === true) {
        ticTacToeData.getMyGames(authorization.getAuthorizationHeader(), $scope.page)
        .then(function (games) {
            $scope.games = games;
        });
    } else {
        notifier.error('Please login!');
        $location.path('/');
    }
});