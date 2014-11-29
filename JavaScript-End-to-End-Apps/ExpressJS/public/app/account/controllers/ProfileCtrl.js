app.controller('ProfileCtrl', function($scope, $location, auth, identity, notifier) {
    $scope.settingsData = {
        email: identity.currentUser.email,
        representativeName: identity.currentUser.representativeName,
        phoneNumber: identity.currentUser.phoneNumber
    };

    $scope.update = function(user) {
        auth.update(user).then(function() {
            identity.currentUser.email = user.email;
            identity.currentUser.representativeName = user.representativeName;
            identity.currentUser.phoneNumber = user.phoneNumber;

            notifier.success("Update successful!");
        }, function(response) {
            notifier.error(response.data["reason"]);
        });
    }
});