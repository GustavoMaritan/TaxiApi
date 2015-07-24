(function () {
    var app = angular.module('cooperControllers', ['infinite-scroll']);

    app.controller('editarCopCtrl', function ($scope, cooperService, dropService, coperativa) {
        GetDrop($scope, dropService);

        if (coperativa.status == 200) {
            $scope.model = coperativa.data;
        }
        function telefones() {
            var cont = $scope.model.Telefones.length;
            for (var i = cont ; i < $scope.model.QtdeTelefones ; i++) {
                $scope.model.Telefones.push({
                    Id: 0,
                    Ddd: "",
                    Numero: "",
                    Ramal: "",
                    OperadoraId: ""
                });
            }
        }

        telefones();

        Backup($scope.model);

        $scope.put = function () {
            var a = $scope.model;
            cooperService.put(a)
                .success(function (data) {
                    if (data.error == "") {
                        toastr.success('Cooperativa editada com sucesso.');
                        // backup = $scope.model;
                    } else {
                        toastr.error(data.error);
                    }
                })
                .error(function () {
                    toastr.error('Erro ao enviar dados.');
                });
        };

        $scope.cancel = function () {
            Recuperar($scope);
        };
    });
})();

function GetDrop($scope, dropService) {
    dropService.getOperadora().success(function (data) {
        $scope.operadoras = data;
    });
}

var backup;
function Backup(parameters) {
    backup = {
        Nome: parameters.Descricao,
        Tels: []
    };
    for (var i = 0; i < parameters.Telefones.length ; i++) {
        backup.Tels.push({
            Id2: parameters.Telefones[i].Id,
            Ddd2: parameters.Telefones[i].Ddd,
            Numero2: parameters.Telefones[i].Numero,
            Ramal2: parameters.Telefones[i].Ramal,
            OperadoraId2: parameters.Telefones[i].OperadoraId
        });
    }
}

function Recuperar($scope) {
    $scope.model.Descricao = backup.Nome;
    $scope.model.Telefones = [];
    for (var i = 0; i < backup.Tels.length ; i++) {
        $scope.model.Telefones.push({
            Id: backup.Tels[i].Id2,
            Ddd: backup.Tels[i].Ddd2,
            Numero: backup.Tels[i].Numero2,
            Ramal: backup.Tels[i].Ramal2,
            OperadoraId: backup.Tels[i].OperadoraId2,
        });
    }
}