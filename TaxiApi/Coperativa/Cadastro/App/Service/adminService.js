(function () {

    var app = angular.module('serviceAdmin', []);

    app.service('adminService', function ($http) {

        var caminhoApiModulo = caminhoApi + "Admin";

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