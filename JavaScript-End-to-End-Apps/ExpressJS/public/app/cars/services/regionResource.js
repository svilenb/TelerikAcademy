"use strict";

app.factory("RegionResource", function($resource) {
    return $resource("/api/regions");
});