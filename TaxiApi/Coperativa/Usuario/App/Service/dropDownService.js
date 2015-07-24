(function () {

    var app = angular.module('serviceDropDown', []);

    app.service('dropService', function ($http) {
        this.getPlano = function () {
            return $http.get(caminhoApi + "/Plano");
        };
        this.getOperadora = function () {
            return $http.get(caminhoApi + "/Operadora");
        };
        this.getTipoCoop = function () {
            return $http.get(caminhoApi + "/TipoCooperativa");
        };
    });
})();