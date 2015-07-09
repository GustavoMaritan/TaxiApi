(function () {

    var app = angular.module('routes', ['ngRoute']);

    app.config(function ($routeProvider) {
        $routeProvider
            //.when('/Contato/Cadastrar', {
            //    templateUrl: 'views/contato/contatoCadastrar.html',
            //    controller: 'contatoCadastrarCtrl'
            //})
            //.when('/Contato/Buscar/:id?', {
            //    templateUrl: 'views/contato/contatoBuscar.html',
            //    controller: 'contatoBuscarCtrl',
            //})
            //.when('/Contato/Editar/:id', {
            //    templateUrl: 'views/contato/contatoEditar.html',
            //    controller: 'contatoEditarCtrl',
            //    resolve: {
            //        "contato": function (contatoService, $route) {
            //            return contatoService.getById($route.current.params.id);
            //        }
            //    }
            //})
             .when('/Login/Index', {
                 templateUrl: 'index.html',
             })
            .otherwise({ redirectTo: '/Login/Index' });;
    });
})();