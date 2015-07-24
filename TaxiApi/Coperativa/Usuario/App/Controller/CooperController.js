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
    });
})();

function GetDrop($scope, dropService) {
    dropService.getOperadora().success(function (data) {
        console.log(data);
        $scope.operadoras = data;
    });
}