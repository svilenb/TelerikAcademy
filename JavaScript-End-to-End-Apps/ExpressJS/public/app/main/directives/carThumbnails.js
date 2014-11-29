"use strict";

app.directive("carThumbnails", function() {
    return {
        restrict: "A",
        templateUrl: "/partials/main/car-thumbnails",
        replace: true
    }
});