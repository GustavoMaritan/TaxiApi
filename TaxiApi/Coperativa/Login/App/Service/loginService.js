(function () {
    var app = angular.module('serviceLogin', []);

    app.service('loginService', function ($http) {

        var caminhoApiModulo = caminhoApi + "Admin";

        this.get = function (login,senha) {
            return $http.get(caminhoApiModulo+"/Get" + "?login=" + login + "&senha=" + senha);
        };
    });
})();