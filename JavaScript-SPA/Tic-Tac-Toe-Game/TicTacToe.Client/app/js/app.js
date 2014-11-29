'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/create-game', {
                templateUrl: 'views/partials/create-game.html',
                controller: 'CreateGameController'
            })
            .when('/available-games/:page', {
                templateUrl: 'views/partials/available-games.html',
                controller: 'AvailableGamesController'
            })
            .when('/my-games/:page', {
                templateUrl: 'views/partials/my-games.html',
                controller: 'MyGamesController'
            })
            .when('/join-game', {
                templateUrl: 'views/partials/join-game.html',
                controller: 'JoinGameController'
            })
            .when('/play-game', {
                templateUrl: 'views/partials/play-game.html',
                controller: 'PlayGameController'
            })
            .when('/leaderboard', {
                templateUrl: 'views/partials/leaderboard.html',
                controller: 'LeaderboardController'
            })
            .when('/game-status', {
                templateUrl: 'views/partials/game-status.html',
                controller: 'GameStatusController'
            })
            .when('/', {
                templateUrl: 'views/partials/home.html',
            })
            .otherwise({ redirectTo: '/' });
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:33257');