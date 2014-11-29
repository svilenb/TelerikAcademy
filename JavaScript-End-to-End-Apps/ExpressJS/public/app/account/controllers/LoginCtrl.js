app.controller('LoginCtrl', function($scope, notifier, identity, auth, $location) {
    $scope.identity = identity;

    $scope.login = function(user) {
        auth.login(user).then(function(success) {
            if (success) {
                notifier.success('Successful login!');
                $location.path("/");
                $(".slide-menu").hide(); // << I know this shouldn't be here
            }
            else {
                notifier.error('Username or password are not correct!');
            }
        },
        function(response) {
            notifier.error(response.reason);
        });
    };

    $scope.logout = function() {
        auth.logout().then(function() {
            notifier.success('Successful logout!');
            $scope.user.username = '';
            $scope.user.password = '';
            $location.path('/');
        })
    }
});
