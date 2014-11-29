"use strict";

app.factory("CategoryResource", function($resource) {
    return {
        getAll: $resource("/api/categories")
    }
});