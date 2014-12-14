define(['jquery', 'handlebars', 'q'], function($, Handlebars, Q) {
  'use strict';
  var UI = function(selector) {
    this.selector = selector;
  };

  var fadeOutDuration = 5000;

  Handlebars.registerHelper('parsedDate', function(postDate) {
    var date = new Date(postDate);

    return (date.getMonth() + '/' + date.getDate() +
      '/' + date.getFullYear() + ' ' +
      date.getHours() + ':' + date.getMinutes());
  });

  UI.prototype.renderHome = function() {
    $(this.selector).load('./views/home.html');
  };

  UI.prototype.renderRegister = function() {
    var deferred = Q.defer();

    $(this.selector).load('views/register.html', function() {
      deferred.resolve();
    });

    return deferred.promise;
  };

  UI.prototype.renderLogin = function() {
    var deferred = Q.defer();

    $(this.selector).load('views/login.html', function() {
      deferred.resolve();
    });

    return deferred.promise;
  };

  UI.prototype.renderProfile = function() {
    var deferred = Q.defer();

    $(this.selector).load('views/profile.html', function() {
      deferred.resolve();
    });

    return deferred.promise;
  };

  UI.prototype.renderMessage = function(selector, messageName) {
    $(selector).load('messages/' + messageName + '.html', function() {
      $(this).fadeIn();
      $(this).fadeOut(fadeOutDuration);
    });
  };

  UI.prototype.renderCreatePost = function() {
    var deferred = Q.defer();

    $(this.selector).load('views/create-post.html', function() {
      deferred.resolve();
    });

    return deferred.promise;
  };

  UI.prototype.renderViewPosts = function() {
    var self = this,
      deferred = Q.defer();

    $(this.selector).load('views/view-posts.html', function() {
      deferred.resolve();
    });

    return deferred.promise;
  };

  UI.prototype.compilePostsTemplate = function(posts) {
    $.get('templates/posts.hbs', function(template) {
      var postTemplate = Handlebars.compile(template);

      $('#posts').html(postTemplate({
        posts: posts
      }));
    });
  };

  return UI;
});
