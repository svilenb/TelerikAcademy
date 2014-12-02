/* global app */
app.directive('statistics', [function() {
    'use strict';
    return {
        restrict: 'A',
        templateUrl: 'views/directives/statistics.html',
        scope: {
            stats: '='
        },
        replace: true
    };
}]);