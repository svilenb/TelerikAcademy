/* global app */
app.directive('drivers', function () {
    'use strict';
    return {
        restrict: 'A',
        templateUrl: 'views/directives/drivers.html',
        scope: true,
        replace: true
    };
});