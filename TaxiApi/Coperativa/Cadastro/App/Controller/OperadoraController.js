(function () {
    var app = angular.module('operadoraControllers', ['infinite-scroll']);

    app.controller('buscaOprCtrl', function ($scope, operadoraService, listOperadora) {
        $scope.todos = [];
        $scope.filteredTodos = [];
        $scope.currentPage = 1;
        $scope.numPerPage = 5;
        $scope.maxSize = 5;
        $scope.totalPaginas = 1;

        $scope.ordenar = function (ordenacao) {
            $scope.order = ordenacao;
        };

        $scope.remaining = function () {
            return $scope.todos.length;
        };

        $scope.mascaraData = function (data) {
            if (data == null || data == "")
                return null;

            var d = data.split('T')[0].split('-');
            return d[2] + "/" + d[1] + "/" + d[0];
        };

        $scope.pageChanged = function () {
            var begin = (($scope.currentPage - 1) * $scope.numPerPage);
            var end = parseInt(begin) + parseInt($scope.numPerPage);
            $scope.filteredTodos = $scope.todos.slice(begin, end);
        };

        function totPag(totReg, numPag) {
            var t = parseInt(totReg / numPag); // 12 % 5;
            t = t < 1 ? 1 : t;
            t = totReg > numPag && totReg % numPag != 0 ? t + 1 : t;
            $scope.totalPaginas = t;
        }

        $scope.setNumPerPage = function (pageNo) {
            $scope.numPerPage = pageNo;
            $scope.pageChanged();
            totPag($scope.todos.length, $scope.numPerPage);
        };

        $scope.delete = function(todo) {
            alertify.confirm("Deseja excluir a operadora?", function(e) {
                if (e) {
                    var index = $scope.todos.indexOf(todo);
                    var index1 = $scope.filteredTodos.indexOf(todo);
                    var id = $scope.todos[index].Id;
                    operadoraService.delete(id)
                        .success(function(data) {
                            if (data.error == "") {
                                toastr.success("Operadora excluida com sucesso.");
                                $scope.todos.splice(index, 1);
                                $scope.filteredTodos.splice(index1, 1);
                                $scope.pageChanged();
                            } else {
                                toastr.error(data.error);
                            }
                        })
                        .error(function() {
                            toastr.error("Erro ao excluir coperativa.");
                        });
                }
            });
        };

        if (listOperadora.status == 200) {
            $scope.todos = listOperadora.data;
            $scope.pageChanged();
            totPag($scope.todos.length, $scope.numPerPage);
        }
    });
    
    app.controller('cadastroOprCtrl', function ($scope, operadoraService) {
        var user = usuarioLog();

        function inicializaModel() {
            $scope.model = {
                Nome: "",
            };
        };

        inicializaModel();

        $scope.post = function () {
            var a = $scope.model;
            operadoraService.post(a)
                .success(function (data) {
                    if (data.error == "") {
                        inicializaModel();
                        toastr.success('Operadora cadastrada com sucesso.');
                    } else {
                        toastr.error(data.error);
                    }
                })
                .error(function () {
                    toastr.error('Erro ao enviar dados.');
                });
        };
    });
    
    app.controller('editarOprCtrl', function ($scope, operadoraService, operadora) {

        if (operadora.status == 200) {
            $scope.model = operadora.data;
        }
        $scope.put = function () {
            var a = $scope.model;
            operadoraService.put(a)
                .success(function (data) {
                    if (data.error == "") {
                        toastr.success('Operadora editada com sucesso.');
                        window.location.href = "#/Operadora/Buscar";
                    } else {
                        toastr.error(data.error);
                    }
                })
                .error(function () {
                    toastr.error('Erro ao enviar dados.');
                });
        };
    });

})();