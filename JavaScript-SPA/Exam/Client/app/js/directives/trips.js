/* global app */
app.directive('trips', function () {
    'use strict';
  return {
     restrict: 'A', 
     templateUrl: 'views/directives/trips.html',
        scope: true,
        replace: true
  };
});
