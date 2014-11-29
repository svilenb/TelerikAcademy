app.controller('CarsListCtrl', function ($scope, $location, identity, CarResource, sort, paging) {
    $scope.listTitle = "Search results";
    $scope.page = 1;
    $scope.identity = identity;

    var queryParams = $location.search();
    queryParams.page = 1;
    updateCarData();

    $scope.sortBy = function(param) { sort.by(param, queryParams, updateCarData); };
    $scope.prevPage = function() { paging.prev($scope, queryParams, updateCarData); };
    $scope.setPage = function() { paging.set($scope, queryParams, updateCarData); };
    $scope.nextPage = function() { paging.next($scope, queryParams, updateCarData); };

    function updateCarData() {
        $scope.cars = CarResource.queryBased.query(queryParams, function() {
            $scope.cars.forEach(function (item) {
                if (!item.photoUrl) {
                    item.photoUrl = "img/no_photo.png";
                }
            });
        });
    }
});