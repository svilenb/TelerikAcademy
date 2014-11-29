"use strict";

app.factory("sort", function() {
    return {
        by: function(param, queryParams, updateCallback) {
            queryParams.sortBy = param;

            if (queryParams.desc) {
                queryParams.desc = false;
            } else {
                queryParams.desc = true;
            }

            updateCallback();
        }
    };
});