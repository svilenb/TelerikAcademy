define(['persisters', 'ui', 'jquery', 'underscore'], function(persisters, UI, $, _) {
  'use strict';

  function makeFormError(selector) {
    $(selector).parent().parent().removeClass('has-success');
    $(selector).parent().parent().addClass('has-error');
  }

  function makeFormSuccess(selector) {
    $(selector).parent().parent().removeClass('has-error');
    $(selector).parent().parent().addClass('has-success');
  }

  var Controller = function(selector, resourceURL) {
    this.selector = selector;
    this.resourceURL = resourceURL;
    this.persister = new persisters.BasePersister(resourceURL);
    this.ui = new UI(selector);
  };

  Controller.prototype.loadHome = function() {
    this.ui.renderHome();
  };

  Controller.prototype.loadRegister = function() {
    var self = this;
    this.ui.renderRegister().then(function() {
      $('#register-btn').click(function() {
        var username = $('#name').val(),
          password = $('#password').val();

        if ((typeof username).toLowerCase() === 'string' && (typeof password).toLowerCase() === 'string' &&
          username.length >= 6 && username.length <= 40 && password.length !== 0) {
          makeFormSuccess('#name');
          makeFormSuccess('#password');

          self.persister.user.register({
            username: username,
            password: password
          }).then(function(data) {
            self.ui.renderMessage('#messages', 'success-register');
          }, function(error) {
            self.ui.renderMessage('#messages', 'error-register');
          });
        } else {
          self.ui.renderMessage('#messages', 'error-register');
          if (username.length < 6 || username.length > 40) {
            makeFormError('#name');
          } else {
            makeFormSuccess('#name');
          }

          if (password.length === 0) {
            makeFormError('#password');
          } else {
            makeFormSuccess('#password');
          }
        }
      });
    });
  };

  Controller.prototype.loadLogin = function() {
    var self = this,
      errorCallback = function(argument) {
        self.ui.renderMessage('#messages', 'error-login');
      };
    this.ui.renderLogin().then(function() {
      $('#login-btn').click(function() {
        var username = $('#name').val(),
          password = $('#password').val();

        if (self.persister.isLoggedIn() === false && (typeof username).toLowerCase() === 'string' &&
          (typeof password).toLowerCase() === 'string' &&
          username.length >= 6 && username.length <= 40 && password.length !== 0) {
          makeFormSuccess('#name');
          makeFormSuccess('#password');

          self.persister.user.login({
            username: username,
            password: password
          }, errorCallback).then(function(data) {
            self.ui.renderMessage('#messages', 'success-login');
          });
        } else if (self.persister.isLoggedIn() === true) {
          self.ui.renderMessage('#messages', 'already-logged-in');
        } else {
          self.ui.renderMessage('#messages', 'error-login');
          if (username.length < 6 || username.length > 40) {
            makeFormError('#name');
          } else {
            makeFormSuccess('#name');
          }

          if (password.length === 0) {
            makeFormError('#password');
          } else {
            makeFormSuccess('#password');
          }
        }
      });
    });
  };

  Controller.prototype.loadProfile = function() {
    var self = this;
    this.ui.renderProfile().then(function() {
      if (self.persister.isLoggedIn()) {
        $('#profile-username').text(localStorage.getItem('username'));
      }

      $('#logout-btn').click(function() {
        self.persister.user.logout().then(function() {
          window.location = '#/';
        }, function(error) {
          console.log(error);
        });
      });
    });
  };

  Controller.prototype.loadCreatePost = function() {
    var self = this;
    this.ui.renderCreatePost().then(function() {
      $('#create-post-btn').click(function() {
        var title = $('#title').val(),
          body = $('#body').val();

        if (self.persister.isLoggedIn() && (typeof title).toLowerCase() === 'string' &&
          (typeof body).toLowerCase() === 'string' &&
          title.length !== 0 && body.length !== 0) {
          makeFormSuccess('#title');
          makeFormSuccess('#body');

          self.persister.post.create({
            title: title,
            body: body
          }).then(function(data) {
            self.ui.renderMessage('#messages', 'success-create-post');
          });
        } else if (self.persister.isLoggedIn() !== true) {
          self.ui.renderMessage('#messages', 'not-logged-in');
        } else {
          self.ui.renderMessage('#messages', 'error-create-post');
          if ((typeof title).toLowerCase() !== 'string' || title.length === 0) {
            makeFormError('#title');
          } else {
            makeFormSuccess('#title');
          }

          if ((typeof body).toLowerCase() !== 'string' || body.length === 0) {
            makeFormError('#body');
          } else {
            makeFormSuccess('#body');
          }
        }
      });
    });
  };

  Controller.prototype.loadViewPosts = function() {
    var self = this;

    this.ui.renderViewPosts().then(function() {
      self.persister.post.getAllPosts()
        .then(function(posts) {
          var currentPage = 1,
            postsPerPage = 4,
            countOfPages = Math.ceil(posts.length / postsPerPage),
            currentPosts = posts.slice(),
            showedPosts = self.getPostsOnPage(posts, currentPage, postsPerPage);

          $('#username-filter-btn').click(function() {
            var username = $('#name').val();

            self.persister.post.getFilteredByNamePosts(username)
              .then(function(filteredPosts) {
                currentPosts = filteredPosts;
                showedPosts = self.getPostsOnPage(filteredPosts, currentPage, postsPerPage);
                self.ui.compilePostsTemplate(showedPosts);
              });
          });

          $('#pattern-filter-btn').click(function() {
            var pattern = $('#pattern').val();

            self.persister.post.getFilteredByPatternPosts(pattern)
              .then(function(filteredPosts) {
                currentPosts = filteredPosts;
                showedPosts = self.getPostsOnPage(filteredPosts, currentPage, postsPerPage);
                self.ui.compilePostsTemplate(showedPosts);
              });
          });

          $('#both-filter-btn').click(function() {
            var pattern = $('#pattern').val(),
              username = $('#name').val();

            self.persister.post.getFilteredByBothPosts(username, pattern)
              .then(function(filteredPosts) {
                currentPosts = filteredPosts;
                showedPosts = self.getPostsOnPage(filteredPosts, currentPage, postsPerPage);
                self.ui.compilePostsTemplate(showedPosts);
              });
          });

          $('#title-sort-btn').click(function() {
            var sortedPosts = self.sortPosts(posts, 'title',
              $('#sort-direction option:selected').val() === 'ascending');
            currentPosts = sortedPosts;
            showedPosts = self.getPostsOnPage(sortedPosts, currentPage, postsPerPage);
            self.ui.compilePostsTemplate(showedPosts);
          });

          $('#date-sort-btn').click(function() {
            var sortedPosts = self.sortPosts(posts, 'postDate',
              $('#sort-direction option:selected').val() === 'ascending');
            currentPosts = sortedPosts;
            showedPosts = self.getPostsOnPage(sortedPosts, currentPage, postsPerPage);
            self.ui.compilePostsTemplate(showedPosts);
          });

          $('#previous-page').click(function() {
            if (currentPage > 1) {
              currentPage -= 1;
            }

            showedPosts = self.getPostsOnPage(currentPosts, currentPage, postsPerPage);
            self.ui.compilePostsTemplate(showedPosts);

            $('#page-number').val(currentPage);
          });

          $('#next-page').click(function() {
            if (currentPage < countOfPages) {
              currentPage += 1;
            }

            showedPosts = self.getPostsOnPage(currentPosts, currentPage, postsPerPage);
            self.ui.compilePostsTemplate(showedPosts);

            $('#page-number').val(currentPage);
          });

          self.ui.compilePostsTemplate(showedPosts);
        });
    });
  };

  Controller.prototype.sortPosts = function(posts, prop, ascending) {
    var sortedPosts = _.sortBy(posts, function(post) {
      return post[prop];
    });

    if (ascending === true) {
      return sortedPosts;
    } else {
      return sortedPosts.reverse();
    }
  };

  Controller.prototype.getPostsOnPage = function(allPosts, pageNumber, postsPerPage) {
    var countOfPosts = allPosts.length,
      firstIndexOfPage = (pageNumber - 1) * postsPerPage,
      lastIndexOfPage = pageNumber * postsPerPage,
      postsOnPage = [];

    if (lastIndexOfPage >= countOfPosts) {
      lastIndexOfPage = countOfPosts;
    }

    if (firstIndexOfPage < 0) {
      return [];
    }

    for (var currentPost = firstIndexOfPage; currentPost < lastIndexOfPage; currentPost++) {
      postsOnPage.push(allPosts[currentPost]);
    }

    return postsOnPage;
  };

  return Controller;
});
