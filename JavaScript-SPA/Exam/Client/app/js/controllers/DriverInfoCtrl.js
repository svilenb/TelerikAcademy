app.controller('DriverInfoCtrl', function ($scope, $routeParams, identity, authorization, tripData, notifier, $location) {
    var driverId = parseInt($routeParams.id);
    $scope.details = identity.isAuthenticated();

    if (identity.isAuthenticated() === true) {
        tripData.getPrivateDriverInfo(authorization.getAuthorizationHeader(), $routeParams.id)
        .then(function (driver) {
            $scope.driver = driver;
        })
    } else {
        notifier.error("Please login!");
        $location.path('/unauthorized');
    }
});