var app = angular.module('app', ['ngResource', 'ngRoute']).value('toastr', toastr);

app.config(function($routeProvider) {
    var routeUserChecks = {
        adminRole: {
            authenticate: function(auth) {
                return auth.isAuthorizedForRole('admin');
            }
        },
        authenticated: {
            authenticate: function(auth) {
                return auth.isAuthenticated();
            }
        }
    };

    $routeProvider
        .when('/signup', {
            templateUrl: '/partials/account/signup',
            controller: 'SignUpCtrl'
        })
        .when('/', {
           templateUrl: '/partials/main/home',
           controller: 'MainCtrl'
        })
        .when('/cars', {
            templateUrl: '/partials/cars/cars-list',
            controller: 'CarsListCtrl',
            reloadOnSearch: false
        })
        .when('/cars/add', {
            templateUrl: '/partials/cars/car-ad-form',
            controller: 'AddCarCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/cars/my-ads', {
            templateUrl: '/partials/cars/cars-list',
            controller: 'MyAdsCtrl',
            resolve: routeUserChecks.authenticated
        })
        .when('/cars/:id', {
            templateUrl: '/partials/cars/car-details',
            controller: 'CarDetailsCtrl'
        })
        .when('/cars/:id/modify', {
            templateUrl: '/partials/cars/car-ad-form',
            controller: 'ModifyCarCtrl',
            resolve: routeUserChecks.authenticated
        })
//        .when('/admin/users', {
//            templateUrl: '/partials/admin/users-list',
//            controller: 'UserListCtrl',
//            resolve: routeUserChecks.adminRole
//        })
        .when('/admin/makes', {
            templateUrl: '/partials/admin/makes-list',
            controller: 'MakesListCtrl',
            resolve: routeUserChecks.adminRole
        })
        .when('/admin/makes/add', {
            templateUrl: '/partials/admin/make-form',
            controller: 'AddMakeCtrl',
            resolve: routeUserChecks.adminRole
        })
        .when('/admin/makes/:id', {
            templateUrl: '/partials/admin/make-form',
            controller: 'MakeDetailsCtrl',
            resolve: routeUserChecks.adminRole
        })
        .when('/admin/models', {
            templateUrl: '/partials/admin/models-list',
            controller: 'ModelsListCtrl',
            resolve: routeUserChecks.adminRole
        })
        .when('/admin/models/add', {
            templateUrl: '/partials/admin/model-form',
            controller: 'AddModelCtrl',
            resolve: routeUserChecks.adminRole
        })
        .when('/admin/models/:id', {
            templateUrl: '/partials/admin/model-form',
            controller: 'ModelDetailsCtrl',
            resolve: routeUserChecks.adminRole
        })
        .when('/admin/categories', {
            templateUrl: '/partials/admin/categories-list',
            controller: 'CategoriesListCtrl',
            resolve: routeUserChecks.adminRole
        })
        .when('/admin/categories/add', {
            templateUrl: '/partials/admin/category-form',
            controller: 'AddCategoryCtrl',
            resolve: routeUserChecks.adminRole
        })
        .when('/admin/categories/:id', {
            templateUrl: '/partials/admin/category-form',
            controller: 'CategoryDetailsCtrl',
            resolve: routeUserChecks.adminRole
        })
        .when('/profile', {
            templateUrl: '/partials/account/profile',
            controller: 'ProfileCtrl',
            resolve: routeUserChecks.authenticated
        })
        .otherwise({ redirectTo: "/" });
}).value('socket', new io());

app.run(function($rootScope, $location) {
    $rootScope.$on('$routeChangeError', function(ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            $location.path('/');
        }
    })
});