define(['jquery', 'q'], function($, Q) {
  'use strict';
  var makeRequest = function(url, type, data, headers) {
    var deferred = Q.defer();

    $.ajax({
      url: url,
      type: type,
      headers: headers,
      contentType: 'application/json',
      data: JSON.stringify(data) || undefined,
      success: function(data) {
        deferred.resolve(data);
      },
      error: function(error) {
        deferred.reject(error);
      }
    });

    return deferred.promise;
  };

  var makeGetRequest = function(url, headers) {
    return makeRequest(url, 'GET', null, headers);
  };

  var makePostRequest = function(url, data, headers) {
    return makeRequest(url, 'POST', data, headers);
  };

  var makePutRequest = function(url, data, headers) {
    return makeRequest(url, 'PUT', data, headers);
  };

  var makeDeleteRequest = function(url, headers) {
    return makeRequest(url, 'DELETE', null, headers);
  };

  return {
    get: makeGetRequest,
    post: makePostRequest,
    put: makePutRequest,
    delete: makeDeleteRequest
  };
});
