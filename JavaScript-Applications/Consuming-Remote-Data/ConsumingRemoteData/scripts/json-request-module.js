var requestsModule = (function () {
    function postJSON(url, data, headers) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "POST",
            headers: headers,
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (err) {
                deferred.reject(err);
            }
        });

        return deferred.promise;
    }

    function getJSON(url, headers) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "GET",
            headers: headers,
            contentType: 'application/json',            
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (err) {
                deferred.reject(err);
            }
        });

        return deferred.promise;
    }

    return {
        postJSON: postJSON,
        getJSON: getJSON
    };
}());