/* global app */
app.controller('HomeCtrl', function ($scope, StatsResource, TripsResource, DriversResource, identity) {
    'use strict';
    $scope.stats = StatsResource.get();
    $scope.trips = TripsResource.public();
    $scope.drivers = DriversResource.public();
    $scope.hideIsMine = true;
});