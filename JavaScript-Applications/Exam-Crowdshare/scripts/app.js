(function() {
  require.config({
    paths: {
      jquery: '../bower_components/jquery/dist/jquery.min',
      handlebars: '../bower_components/handlebars/handlebars.min',
      q: '../libs/q',
      sammy: '../bower_components/sammy/lib/sammy',
      underscore: '../bower_components/underscore/underscore-min',
      requester: 'ajax-requester',
      persisters: 'persisters',
      controller: 'controller',
      ui: 'ui'
    }
  });

  require(['sammy', 'jquery', 'controller', 'persisters'], function(sammy, $, Controller) {
    var resourceURL = 'http://localhost:3000/',
      controller = new Controller('#main', resourceURL);

    function changeActiveTab(selector) {
      $('#tabs .active').removeClass("active");
      $(selector).addClass("active");
    }

    var app = sammy('#main', function() {
      this.get('#/', function() {
        controller.loadHome();
        changeActiveTab('#tabs #home');
      });

      this.get('#/register', function() {
        controller.loadRegister();
        changeActiveTab('#tabs #register');
      });

      this.get('#/login', function() {
        controller.loadLogin();
        changeActiveTab('#tabs #login');
      });

      this.get('#/post', function() {
        controller.loadCreatePost();
        changeActiveTab('#tabs #create-post');
      });

      this.get('#/view-posts', function() {
        controller.loadViewPosts();
        changeActiveTab('#tabs #view-posts');
      });

      this.get('#/profile', function() {
        controller.loadProfile();
        changeActiveTab('#tabs #profile');
      });
    });

    $(function() {
      app.run('#/');
    });
  });
}());
