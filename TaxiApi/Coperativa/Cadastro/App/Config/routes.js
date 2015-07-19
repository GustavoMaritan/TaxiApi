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
            .when('/Operadora/Buscar', {
                templateUrl: 'view/Operadora/Grid.html',
                controller: 'buscaOprCtrl',
                resolve: {
                    "listOperadora": function (operadoraService) {
                        usuarioLog();
                        return operadoraService.get();
                    }
                }
            })
            .when('/Operadora/Cadastro', {
                templateUrl: 'view/Operadora/Cadastro.html',
                controller: 'cadastroOprCtrl'
            })
            .when('/Operadora/Editar/:id', {
                templateUrl: 'view/Operadora/Editar.html',
                controller: 'editarOprCtrl',
                resolve: {
                    "operadora": function (operadoraService, $route) {
                        usuarioLog();
                        return operadoraService.getId($route.current.params.id);
                    }
                }
            })
            .otherwise({ redirectTo: '/Coperativa/Buscar' });;
    });
})();