(function () {
    var app = angular.module('loginControllers', ['infinite-scroll']);

    app.controller('loginController', function ($scope, loginService) {
        $scope.nome = "";
        $scope.senha = "";
        localStorage["usuarioId"] = "";
        $scope.tpUsua = 1;

        $scope.get = function() {
            if ($scope.nome == "" || $scope.senha == "") {
                if ($scope.senha == "")
                    toastr.warning("Campo senha obrigatório.", 'Aviso!');
                if ($scope.nome == "")
                    toastr.warning("Campo nome do usuário obrigatório.", 'Aviso!');
                return;
            }
            if ($scope.tpUsua == 1) {
                loginService.getUsua($scope.nome, $scope.senha)
                     .success(function (data) {
                         if (data.error != null) {
                             toastr.error(data.error, 'Erro!');
                         } else {
                             var model = {
                                 nome: data.Descricao,
                                 id: data.Id
                             };
                             console.log(model);
                             localStorage["usuarioId"] = angular.toJson(model);
                             window.location.href = caminhoHost + "Coperativa/Usuario/index.html";
                         }
                     })
                     .error(function (xhr) {
                         toastr.error(xhr.responseText, 'Erro!');
                     });
            } else {
                loginService.get($scope.nome, $scope.senha)
                    .success(function(data) {
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
                    .error(function(xhr) {
                        toastr.error(xhr.responseText, 'Erro!');
                    });
            }
        };
    });
})();
