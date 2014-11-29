var auth = require('./auth'),
    mongoose = require('mongoose'),
    User = mongoose.model('User'),
    Car = mongoose.model('Car'),
    controllers = require('../controllers');

module.exports = function (app) {
    app.get('/api/users', auth.isInRole('admin'), controllers.users.getAllUsers);
    app.post('/api/users', controllers.users.createUser);
    app.put('/api/users', auth.isAuthenticated, controllers.users.updateUser);

    app.get('/api/cars/picture/:id', controllers.cars.getPicture);
    app.get('/api/cars', controllers.cars.searchCar);
    //app.get('/api/cars', controllers.cars.getAllCars);
    app.post('/api/cars', auth.isAuthenticated, controllers.cars.createCar);

    app.get('/api/cars/:id', controllers.cars.getCarById);

    app.get('/api/makes', controllers.makes.getAllMakes);
    app.post('/api/makes', controllers.makes.createMake);
    app.get('/api/makes/:id', controllers.makes.getMakeById);
    app.put('/api/makes/:id', controllers.makes.updateMake);

    app.get('/api/models', controllers.models.getAllModels);
    app.post('/api/models', controllers.models.createModel);
    app.get('/api/models/make', controllers.models.getModelByMake);

    app.get('/api/categories', controllers.categories.getAllCategories);
    app.post('/api/categories', controllers.categories.createCategory);
    app.get('/api/categories/:id', controllers.categories.getCategoryById);
    app.put('/api/categories/:id', controllers.categories.updateCategory);

    app.get('/api/colors', controllers.colors.getAllColors);
    app.get('/api/engines', controllers.engineTypes.getAllEngineTypes);
    app.get('/api/gearboxes', controllers.gearboxTypes.getAllGearboxTypes);
    app.get('/api/regions', controllers.regions.getAllRegions);

    app.get('/partials/:partialDir/:partialName', function (req, res) {
        res.render('../../public/app/' + req.params.partialDir + '/' + req.params.partialName);
    });

    app.post('/login', auth.login);
    app.post('/logout', auth.logout);

    app.get('/api/*', function (req, res) {
        res.status(404);
        res.end();
    });

    app.get('*', function (req, res) {
        res.render('index', { currentUser: req.user });
    });
};