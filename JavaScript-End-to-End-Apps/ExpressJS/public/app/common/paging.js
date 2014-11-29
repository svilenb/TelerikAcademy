"use strict";

app.factory("paging", function() {
    return {
        prev: function(scope, queryParams, updateCallback) {
            var newPage = queryParams.page - 1;

            if (newPage > 0) {
                queryParams.page = newPage;
                scope.page = queryParams.page;
                updateCallback();
            }
        },
        set: function(scope, queryParams, updateCallback) {
            if (scope.page > 0) {
                queryParams.page = scope.page;
                updateCallback();
            }
        },
        next: function(scope, queryParams, updateCallback) {
            queryParams.page += 1;
            scope.page = queryParams.page;
            updateCallback();
        }
    };
});