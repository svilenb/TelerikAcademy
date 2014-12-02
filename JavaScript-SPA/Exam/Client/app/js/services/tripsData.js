app.factory('tripData', function ($http, $q, baseServiceUrl) {
    var url = baseServiceUrl;

    var getLastDriversPrivate = function (header, page) {
        var deferred = $q.defer();
        //header["Content-Type"] = "application/json";

        $http({
            method: 'GET',
            url: url + 'api/drivers?page=' + page,
            headers: header
        })
       .success(function (data) {
           deferred.resolve(data);
       })
       .error(function (data) {
           deferred.reject(data);
       });

        return deferred.promise;
    };

    var getPrivateDriverInfo = function (header, driverId) {
        var deferred = $q.defer();
        //header["Content-Type"] = "application/json";

        $http({
            method: 'GET',
            url: url + 'api/drivers/' + driverId,
            headers: header
        })
       .success(function (data) {
           deferred.resolve(data);
       })
       .error(function (data) {
           deferred.reject(data);
       });

        return deferred.promise;
    }

    var createTrip = function (header, data) {
        var deferred = $q.defer();
        header["Content-Type"] = "application/json";

        $http({
            method: 'POST',
            url: url + 'api/trips',
            data: data,
            headers: header
        })
       .success(function (data) {
           deferred.resolve(data);
       })
       .error(function (data) {
           deferred.reject(data);
       });

        return deferred.promise;
    }

    

    var getPrivateTrips = function (header, page, orderBy, orderType, onlyMine) {
        var deferred = $q.defer();
        //header["Content-Type"] = "application/json";
        var finalUrl = url + 'api/trips';

        if (page >= 0) {
            finalUrl += '?page=' + page;
        }

        if (orderBy) {
            finalUrl += '&orderBy=' + orderBy;
        }

        if (orderType) {
            finalUrl += '&orderType=' + orderType;
        }

        if (onlyMine !== undefined) {
            finalUrl += '&onlyMine=' + onlyMine;
        }

        //if (from) {
        //    finalUrl += '&from=' + from;
        //}

        //if (to) {
        //    finalUrl += '&to=' + to;
        //}

        $http({
            method: 'GET',
            url: finalUrl,
            headers: header
        })
       .success(function (data) {
           deferred.resolve(data);
       })
       .error(function (data) {
           deferred.reject(data);
       });

        return deferred.promise;
    };

    var getTripInfo = function (header, tripId) {
        var deferred = $q.defer();
        //header["Content-Type"] = "application/json";

        $http({
            method: 'GET',
            url: url + 'api/trips/' + tripId,
            headers: header
        })
       .success(function (data) {
           deferred.resolve(data);
       })
       .error(function (data) {
           deferred.reject(data);
       });

        return deferred.promise;
    }

    var jointrip = function (header, tripId) {
        var deferred = $q.defer();
        //header["Content-Type"] = "application/json";

        $http({
            method: 'PUT',
            url: url + 'api/trips/' + tripId,
            headers: header
        })
       .success(function (data) {
           deferred.resolve(data);
       })
       .error(function (data) {
           deferred.reject(data);
       });

        return deferred.promise;
    }

    return {
        getPrivateDriverInfo: getPrivateDriverInfo,
        getTripInfo: getTripInfo,
        jointrip: jointrip,
        getLastDriversPrivate: getLastDriversPrivate,
        getPrivateTrips: getPrivateTrips,
        createTrip: createTrip
    }
});