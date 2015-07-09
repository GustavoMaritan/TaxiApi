(function () {
    var app = angular.module('headerController', ['infinite-scroll']);

    app.controller('headerCtrl', function ($scope) {

        $scope.nomeUsuario = usuarioLog().nome;

        $scope.sair = function () {
            localStorage["usuarioId"] = "";
            window.location.href = "http://" + window.location.host + "/Coperativa/Login/index.html";
        };
    });
})();
