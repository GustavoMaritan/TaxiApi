(function () {
    var app = angular.module('routes', ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/Cooper/Editar/:id', {
                templateUrl: 'view/Cooper/Editar.html',
                controller: 'editarCopCtrl',
                resolve: {
                    "coperativa": function(cooperService, $route) {
                        usuarioLog();
                        return cooperService.getId($route.current.params.id);
                    }
                }
            })
        .otherwise({ redirectTo: '/Cooper/Editar/:id ' + usuarioLog().id });;
    });
})();