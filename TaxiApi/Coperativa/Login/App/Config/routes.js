(function () {

    var app = angular.module('routes', ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
             .when('/Login/Index', {
                 templateUrl: 'index.html',
             })
            .otherwise({ redirectTo: '/Login/Index' });;
    });
})();