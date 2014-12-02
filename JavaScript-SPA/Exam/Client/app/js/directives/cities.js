/* global app */
app.directive('cities', function () {
    'use strict';
    return {
        restrict: 'A',
        templateUrl: 'views/directives/cities.html'
    };
});