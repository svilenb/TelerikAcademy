"use strict";

app.factory("EngineTypeResource", function($resource) {
    return $resource("/api/engines");
});