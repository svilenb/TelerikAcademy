"use strict";

app.factory("MakeResource", function($resource) {
    return {
        getAll: $resource("/api/makes")
    }
});