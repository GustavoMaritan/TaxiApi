(function () {
    var app = angular.module('planosControllers', ['infinite-scroll']);

    app.controller('buscaPlnCtrl', function ($scope, planosService, listPlanos) {
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
            alertify.confirm("Deseja excluir a plano?", function(e) {
                if (e) {
                    var index = $scope.todos.indexOf(todo);
                    var index1 = $scope.filteredTodos.indexOf(todo);
                    var id = $scope.todos[index].Id;
                    planosService.delete(id)
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

        if (listPlanos.status == 200) {
            $scope.todos = listPlanos.data;
            $scope.pageChanged();
            totPag($scope.todos.length, $scope.numPerPage);
        }
    });
    
    app.controller('cadastroPlnCtrl', function ($scope, planosService) {
        var user = usuarioLog();

        function inicializaModel() {
            $scope.model = {
                Descricao: "",
                Preco: "",
                QuantidadeMaximaTelefones:0
            };
        };

        inicializaModel();

        $scope.post = function () {
            var a = $scope.model;
            planosService.post(a)
                .success(function (data) {
                    if (data.error == "") {
                        inicializaModel();
                        toastr.success('Plano cadastrada com sucesso.');
                    } else {
                        toastr.error(data.error);
                    }
                })
                .error(function () {
                    toastr.error('Erro ao enviar dados.');
                });
        };
    });
    
    app.controller('editarPlnCtrl', function ($scope, planosService, plano) {

        if (plano.status == 200) {
            $scope.model = plano.data;
        }
        $scope.put = function () {
            var a = $scope.model;
            planosService.put(a)
                .success(function (data) {
                    if (data.error == "") {
                        toastr.success('Plano editada com sucesso.');
                        window.location.href = "#/PLano/Buscar";
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