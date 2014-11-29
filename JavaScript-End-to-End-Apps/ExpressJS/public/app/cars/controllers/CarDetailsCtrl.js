app.controller('CarDetailsCtrl', function ($scope, identity, $routeParams, CarResource) {
    $scope.idenity = identity;

    CarResource.paramBased.get({ id: $routeParams.id }).$promise.then(function (car) {
        $scope.carData = car;
        if (!$scope.carData.photoUrl) {
            $scope.carData.photoUrl = "img/no_photo.png";
        }
    });
});