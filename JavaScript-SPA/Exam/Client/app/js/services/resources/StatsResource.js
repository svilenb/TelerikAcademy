/* global app */
app.factory('StatsResource', function ($resource, baseServiceUrl) {
    'use strict';
    var StatsResource = $resource(baseServiceUrl + '/api/stats');
    var cachedStatistics;

    return {
        get: function () {
            if (!cachedStatistics) {
                cachedStatistics = StatsResource.get();
            }

            return cachedStatistics;
        }
    };
});