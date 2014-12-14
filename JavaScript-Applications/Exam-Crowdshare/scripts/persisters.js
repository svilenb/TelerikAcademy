define(['requester', 'q'], function(requester, Q) {
  'use strict';

  function saveSessionData(data) {
    localStorage.setItem('username', data.username);
    localStorage.setItem('sessionKey', data.sessionKey);
  }

  function removeSessionData() {
    localStorage.removeItem('username');
    localStorage.removeItem('sessionKey');
  }

  var BasePersister = function(resourceURL) {
    this.resourceURL = resourceURL;
    this.user = new UserPersister(resourceURL);
    this.post = new PostPersister(resourceURL);
  };

  BasePersister.prototype.isLoggedIn = function() {
    if (localStorage.getItem('sessionKey')) {
      return true;
    }

    return false;
  };

  var UserPersister = function(rootUrl) {
    this.rootUrl = rootUrl;
  };

  UserPersister.prototype.register = function(user) {
    var url = this.rootUrl + "user/";
    var userData = {
      username: user.username,
      authCode: CryptoJS.SHA1(user.username + user.password).toString()
    };

    return requester.post(url, userData);
  };

  UserPersister.prototype.login = function(user, errorCallback) {
    var url = this.rootUrl + "auth/";
    var userData = {
      username: user.username,
      authCode: CryptoJS.SHA1(user.username + user.password).toString()
    };

    return requester.post(url, userData).then(function(data) {
      saveSessionData(data);
    }, function(error) {
      errorCallback();
    });
  };

  UserPersister.prototype.logout = function(errorCallback) {
    var url = this.rootUrl + 'user/';

    return requester.put(url, {}, {
      "X-SessionKey": localStorage.getItem('sessionKey')
    }).then(function(data) {
      removeSessionData();
    }, function(error) {
      errorCallback();
    });
  };

  var PostPersister = function(resourceURL) {
    this.resourceURL = resourceURL;
  };

  PostPersister.prototype.create = function(post) {
    var url = this.resourceURL + 'post/';

    return requester.post(url, post, {
      "X-SessionKey": localStorage.getItem('sessionKey')
    });
  };

  PostPersister.prototype.getAllPosts = function(parameters) {
    var url = this.resourceURL + 'post/';

    return requester.get(url);
  };

  PostPersister.prototype.getFilteredByNamePosts = function(username) {
    var url = this.resourceURL + 'post?user=' + username;

    return requester.get(url);
  };

  PostPersister.prototype.getFilteredByPatternPosts = function(pattern) {
    var url = this.resourceURL + 'post?pattern=' + pattern;

    return requester.get(url);
  };

  PostPersister.prototype.getFilteredByBothPosts = function(username, pattern) {
    var url = this.resourceURL + 'post?pattern=' + pattern + '&user=' + username;

    return requester.get(url);
  };

  return {
    UserPersister: UserPersister,
    BasePersister: BasePersister,
    PostPersister: PostPersister
  };
});
