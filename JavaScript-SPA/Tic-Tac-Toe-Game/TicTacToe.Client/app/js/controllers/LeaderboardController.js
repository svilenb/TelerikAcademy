app.controller('LeaderboardController', function ($scope, $location, authorization, identity, ticTacToeData, notifier) {
    'use strict';
    if (identity.isAuthenticated() === true) {
        ticTacToeData.getLeaderboard(authorization.getAuthorizationHeader())
        .then(function (data) {
            $scope.users = data;
        });
    } else {
        notifier.error('Please login!');
        $location.path('/');
    }
});