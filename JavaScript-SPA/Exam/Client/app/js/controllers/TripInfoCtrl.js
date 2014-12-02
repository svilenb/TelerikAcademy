app.controller('TripInfoCtrl', function ($scope, $routeParams, identity, authorization, tripData, notifier, $location) {
    $scope.tripId = $routeParams.id;
    $scope.joinTrip = function () {
        tripData.jointrip(authorization.getAuthorizationHeader(), $routeParams.id)
        .then(function (data) {
            notifier.success("Trip joined!");
        }, function (error) {
            notifier.error("Could not join");
        })
    }

    if (identity.isAuthenticated() === true) {
        tripData.getTripInfo(authorization.getAuthorizationHeader(), $routeParams.id)
        .then(function (trip) {
            $scope.trip = trip;
        })
    } else {
        notifier.error("plaese login");
        $location.path('/unauthorized');
    }
});