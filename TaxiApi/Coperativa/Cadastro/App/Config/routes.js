(function () {

    var app = angular.module('routes', ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/Coperativa/Buscar', {
                templateUrl: 'view/Crud/Grid.html',
                controller: 'buscaCtrl',
                resolve: {
                    "listCoperativa": function (buscarService) {
                        usuarioLog();
                        return buscarService.get();
                    }
                }
            })
            .when('/Coperativa/Cadastro', {
                templateUrl: 'view/Crud/Cadastro.html',
                controller: 'cadastroCtrl'
            })
            .when('/Coperativa/Editar/:id', {
                templateUrl: 'view/Crud/Editar.html',
                controller: 'editarCtrl',
                resolve: {
                    "coperativa": function (buscarService, $route) {
                        usuarioLog();
                        return buscarService.getId($route.current.params.id);
                    }
                }
            })
            .otherwise({ redirectTo: '/Coperativa/Buscar' });;
    });
})();