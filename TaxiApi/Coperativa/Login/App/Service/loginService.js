(function () {
    var app = angular.module('serviceLogin', []);

    app.service('loginService', function ($http) {

        var caminhoApiModulo = "http://" + window.location.hostname + ":17463/api/Admin";

        this.get = function (login,senha) {
            return $http.get(caminhoApiModulo + "?login=" + login + "&senha=" + senha);
        };
    });
})();