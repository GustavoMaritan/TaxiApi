(function () {

    var app = angular.module('serviceCoperativa', []);

    app.service('buscarService', function ($http) {

        var caminhoApiModulo = "http://" + window.location.hostname + ":17463/api/Coperativa";

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
