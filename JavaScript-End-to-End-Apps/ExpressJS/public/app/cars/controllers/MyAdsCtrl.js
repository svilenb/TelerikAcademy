app.controller('MyAdsCtrl', function ($scope, identity, CarResource) {
    $scope.listTitle = "My ads";
    $scope.identity = identity;

    $scope.cars = CarResource.queryBased.query({ page: 1, sortBy: "published", desc: true, isMine: true }, function () {
        $scope.cars.forEach(function (item) {
            if (!item.photoUrl) {
                item.photoUrl = "img/no_photo.png";
            }
        });
    });
});