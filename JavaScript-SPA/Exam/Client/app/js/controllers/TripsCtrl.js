/* global app */
app.controller('TripsCtrl', function ($scope, identity, TripsResource, CitiesResource) {
    'use strict';
    $scope.cities = CitiesResource.all();

    $scope.identity = identity;
    if (identity.isAuthenticated()) {
        $scope.request = {
            page: 1
        };

        $scope.trips = TripsResource.all($scope.request);

        $scope.filter = function (request) {
            TripsResource.all(request)
                .$promise
                .then(function (trips) {
                    $scope.trips = trips;
                });
        };
    } else {
        $scope.trips = TripsResource.public();
    }
});