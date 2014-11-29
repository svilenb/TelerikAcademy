"use strict";

app.factory('CarResource', function($resource) {
    return {
        paramBased: $resource('/api/cars/:id', {id:'@id'}, { update: {method: 'PUT', isArray: false}}),
        queryBased: $resource("/api/cars")
    };
});