(function () {

    var app = angular.module('serviceCoperativa', []);

    app.service('buscarService', function ($http) {

        var caminhoApiModulo = caminhoApi + "Coperativa";

        this.get = function () {
            return $http.get(caminhoApiModulo);
        };
        
        this.getId = function (id) {
            return $http.get(caminhoApiModulo + "/" + id);
        };
        
        this.post = function (entidade) {
            console.log(entidade);
            return $http.post(caminhoApiModulo, entidade);
        };
    });
})();
