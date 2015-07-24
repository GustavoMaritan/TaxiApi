(function () {
    var app = angular.module('serviceLogin', []);

    app.service('loginService', function ($http) {

        var caminhoApiAdmin = caminhoApi + "Admin";
        var caminhoApiUsua = caminhoApi + "Usuario";

        this.get = function (login,senha) {
            return $http.get(caminhoApiAdmin + "/Get" + "?login=" + login + "&senha=" + senha);
        };
        this.getUsua = function (login, senha) {
            return $http.get(caminhoApiUsua + "/Get" + "?login=" + login + "&senha=" + senha);
        };
    });
})();