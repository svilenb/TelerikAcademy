var auth = require('./auth'),
  controllers = require('../controllers');

module.exports = function(app) {
  app.get('/register', controllers.users.getRegister);
  app.post('/register', controllers.users.postRegister);

  app.get('/login', controllers.users.getLogin);
  app.post('/login', auth.login);
  app.get('/logout', auth.isAuthenticated, auth.logout);

  app.get('/events/details/:id', auth.isAuthenticated, controllers.events.getDetails);
  app.get('/profile', auth.isAuthenticated, controllers.users.getProfile);
  app.post('/profile', auth.isAuthenticated, controllers.users.changeProfile);

  app.get('/addevent', auth.isAuthenticated, controllers.events.getCreateEvent);
  app.post('/addevent', auth.isAuthenticated, controllers.events.postNewEvent);

  app.get('/myevents', auth.isAuthenticated, controllers.events.getMyActiveEvents);

  app.get('/', controllers.events.getPassedEvents);

  app.get('*', function(req, res) {
    res.render('index', {
      currentUser: req.user
    });
  });
};
