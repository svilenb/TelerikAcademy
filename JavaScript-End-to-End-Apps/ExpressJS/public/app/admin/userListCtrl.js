app.controller('UserListCtrl', function($scope, UsersResource) {
    var users = UsersResource.query();
    $scope.users = users;
});