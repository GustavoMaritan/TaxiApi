(function () {
    var app = angular.module('coperativaControllers', ['infinite-scroll']);

    app.controller('buscaCtrl', function ($scope, buscarService, listCoperativa) {
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

        $scope.delete = function (todo) {
            var index = $scope.todos.indexOf(todo);
            var index1 = $scope.filteredTodos.indexOf(todo);
            var id = $scope.todos[index].Id;
            buscarService.delete(id)
                .success(function(data) {
                    if (data.error == "") {
                        toastr.success("Coperativa excluida com sucesso.");
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
        };

        if (listCoperativa.status == 200) {
            $scope.todos = listCoperativa.data;
            $scope.pageChanged();
            totPag($scope.todos.length, $scope.numPerPage);
        }
    });

    app.controller('cadastroCtrl', function ($scope, buscarService) {
        var user = usuarioLog();
        $scope.modal = false;
        
        function inicializaModel() {
            $scope.model = {
                Descricao: "",
                Ativo: true,
                Excluido: false,
                DataCadastro: "",
                Senha: null,
                Login: null,
                Cnpj: "",
                RazaoSocial: "",
                QtdeTelefones: 0,
                Endereco: "",
                Bairro: "",
                Cep: "",
                Numero: "",
                Telefones: [],
                Controles: [{
                    DataVencimento: "",
                    Recebido: false,
                    Valor: ""
                }]
            };
        };

        inicializaModel();

        $scope.post = function () {
            var a = $scope.model;
            buscarService.post(a)
                .success(function (data) {
                    if (data.error == "") {
                        inicializaModel();
                        toastr.success('Cooperativa cadastrada com sucesso.');
                    } else {
                        toastr.error(data.error);
                    }
                })
                .error(function () {
                    toastr.error('Erro ao enviar dados.');
                });
        };

        $scope.delTelefone = function (indice) {
            $scope.model.Telefones.splice(indice, 1);
        };

        $scope.addTelefone = function () {
            $scope.model.Telefones.push({
                Ddd: null,
                Numero: null,
                Ramal: null
            });
        };

        $scope.fecharModal = function () {
            var tel = $scope.model.Telefones;
            var valida = false;
            for (var i = 0; i < tel.length; i++) {
                var ddd = tel[i].Ddd;
                var num = tel[i].Numero;
                if (ddd == null || ddd == "" || num == null || num == "") {
                    toastr.error("DDD e Número são obrigatórios.", "Aviso");
                    valida = true;
                    break;
                }
            }
            $scope.modal = valida;
        };
    });

    app.controller('editarCtrl', function ($scope, buscarService, coperativa) {
        if (coperativa.status == 200) {
            $scope.model = coperativa.data;
        }
        
        $scope.modal = false;
        
        $scope.put = function () {
            var a = $scope.model;
            buscarService.put(a)
                .success(function (data) {
                    if (data.error == "") {
                        toastr.success('Cooperativa editada com sucesso.');
                        window.location.href = "#/Coperativa/Buscar";
                    } else {
                        toastr.error(data.error);
                    }
                })
                .error(function () {
                    toastr.error('Erro ao enviar dados.');
                });
        };

        $scope.delTelefone = function (indice) {
            $scope.model.Telefones.splice(indice, 1);
        };

        $scope.addTelefone = function () {
            $scope.model.Telefones.push({
                CoperativaId: $scope.model.Id,
                Ddd: null,
                Numero: null,
                Ramal: null
            });
        };

        $scope.fecharModal = function () {
            var tel = $scope.model.Telefones;
            var valida = false;
            for (var i = 0; i < tel.length; i++) {
                var ddd = tel[i].Ddd;
                var num = tel[i].Numero;
                if (ddd == null || ddd == "" || num == null || num == "") {
                    toastr.error("DDD e Número são obrigatórios.", "Aviso");
                    valida = true;
                    break;
                }
            }
            $scope.modal = valida;
        };
    });
})();