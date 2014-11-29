"use strict";

app.factory("ColorResource", function($resource) {
    return $resource("/api/colors");
});