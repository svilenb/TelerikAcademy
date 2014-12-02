/* global app */
app.factory('CitiesResource', function($resource, baseServiceUrl) {
    'use strict';
    var CitiesResource = $resource(baseServiceUrl + '/api/cities');

    return {
        all: function() {
            return CitiesResource.query();
        }
    };
});