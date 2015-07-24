﻿(function () {
    var app = angular.module('headerController', ['infinite-scroll']);

    app.controller('headerCtrl', function ($scope, cooperService) {

        var usua = usuarioLog();

        $scope.nomeUsuario = usua.nome;
        $scope.id = usua.id;
        $scope.imagem = 'perfil.jpg';

        //adminService.getId(usua.id)
        //    .success(function (data) {
        //        console.log(data);
        //        $scope.imagem = data.Image == null ? "perfil.jpg" : data.Image;
        //    });

        $scope.sair = function () {
            localStorage["usuarioId"] = "";
            window.location.href = caminhoHost + "Coperativa/Login/index.html";
        };
    });
})();