/* global app */
app.controller('CreateTripCtrl',
    function TripCreateCtrl($scope, $location, auth, notifier, TripsResource, CitiesResource, identity) {
        'use strict';
        if (identity.isAuthenticated() === true) {
            auth.userInfo()
                .then(function (userInfo) {
                    $scope.userInfo = userInfo;
                    if (userInfo.isDriver) {
                        $scope.cities = CitiesResource.all();

                        $scope.createTrip = function (trip) {
                            TripsResource.create(trip)
                                .then(function () {
                                    notifier.success('Trip created successfully!!');
                                    $location.path('/trips');
                                });
                        };
                    }
                });
        } else {
            notifier.error("Please login!");
            $location.path('/unauthorized');
        }
    });