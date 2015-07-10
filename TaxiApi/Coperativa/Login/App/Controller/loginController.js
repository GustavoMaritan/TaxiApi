(function () {
    var app = angular.module('loginControllers', ['infinite-scroll']);

    app.controller('loginController', function ($scope, loginService) {
        $scope.nome = "";
        $scope.senha = "";
        localStorage["usuarioId"] = "";

        $scope.get = function () {
            if ($scope.nome == "" || $scope.senha == "") {
                if ($scope.senha == "") 
                    toastr.warning("Campo senha obrigatório.", 'Aviso!');
                if ($scope.nome == "") 
                    toastr.warning("Campo nome do usuário obrigatório.", 'Aviso!');
                return;
            }
            loginService.get($scope.nome, $scope.senha)
                .success(function (data) {
                    if (data.error != null) {
                        toastr.error(data.error, 'Erro!');
                    } else {

                        var model = {
                            nome: data.Nome,
                            id: data.Id
                        };

                        localStorage["usuarioId"] = angular.toJson(model);
                        window.location.href = caminhoHost + "Coperativa/Cadastro/index.html";
                    }
                })
                .error(function (xhr) {
                    toastr.error(xhr.responseText, 'Erro!');
                });
        };
    });
})();
