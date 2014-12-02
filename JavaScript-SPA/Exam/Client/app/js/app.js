/* global angular, toastr */
var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function ($routeProvider) {
        'use strict';
        $routeProvider
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/drivers', {
                templateUrl: 'views/partials/last-registered-drivers.html',
                controller: 'LastRegisteredDriversCtrl'
            })
            .when('/trips', {
                templateUrl: 'views/partials/trips.html',
                controller: 'TripsCtrl'
            })
            .when('/trips/create', {
                templateUrl: 'views/partials/create-trip.html',
                controller: 'CreateTripCtrl'
            })
            .when('/trips/:id', {
                templateUrl: 'views/partials/trip-info.html',
                controller: 'TripInfoCtrl'
            })
            .when('/drivers/:id', {
                templateUrl: 'views/partials/driver-info.html',
                controller: 'DriverInfoCtrl'
            })
            .when('/unauthorized', {
                templateUrl: 'views/partials/unauthorized.html',
            })
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'HomeCtrl'
            })
            .otherwise({ redirectTo: '/' });
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com/');