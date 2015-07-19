(function () {
    var app = angular.module('headerController', ['infinite-scroll']);

    app.controller('headerCtrl', function ($scope) {

        var usua = usuarioLog();

        $scope.nomeUsuario = usua.nome;
        $scope.id = usua.id;

        $scope.sair = function () {
            localStorage["usuarioId"] = "";
            window.location.href = caminhoHost + "Coperativa/Login/index.html";
        };
    });
})();
