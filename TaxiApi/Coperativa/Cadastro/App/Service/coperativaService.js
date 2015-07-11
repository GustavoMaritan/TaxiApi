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
            return $http.post(caminhoApiModulo, entidade);
        };
        
        this.put = function (entidade) {
            return $http.put(caminhoApiModulo, entidade);
        };
        
        this.delete = function (id) {
            return $http.delete(caminhoApiModulo + "?id=" + id);
        };
    });
})();
