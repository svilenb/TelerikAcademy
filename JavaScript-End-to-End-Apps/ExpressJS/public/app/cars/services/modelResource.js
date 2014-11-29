"use strict";

app.factory("ModelResource", function($resource) {
    return {
        getAll: $resource("/api/models"),
        getByMake: $resource("/api/models/make")
    };
});