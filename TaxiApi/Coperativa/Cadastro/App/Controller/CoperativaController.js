(function () {
    var app = angular.module('coperativaControllers', ['infinite-scroll']);

    app.controller('buscaCtrl', function ($scope, buscarService, listCoperativa) {
        $scope.todos = [];
        $scope.filteredTodos = [];
        $scope.currentPage = 1;
        $scope.numPerPage = 5;
        $scope.maxSize = 5;
        $scope.totalPaginas = 1;

        $scope.remover = function (todo) {
            var index = $scope.todos.indexOf(todo);
            var index1 = $scope.filteredTodos.indexOf(todo);
            $scope.todos.splice(index, 1);
            $scope.filteredTodos.splice(index1, 1);
            toastr.warning(todo.Id);
            $scope.pageChanged();
        };

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

        if (listCoperativa.status == 200) {
            $scope.todos = listCoperativa.data;
            $scope.pageChanged();
            totPag($scope.todos.length, $scope.numPerPage);
        }
    });

    app.controller('cadastroCtrl', function ($scope, buscarService) {
        var user = usuarioLog();

        function inicializaModel() {
            $scope.model = {
                NomeFantasia: "",
                RazaoSocial: "",
                QtdeTelefones: "",
                Pago: false,
                DataVencimento: "",
                Login: "",
                Senha: "",
                Cnpj: "",
                Bloqueado: false,
                Excluido: false,
                UsuarioId: user.id,
                Telefones: []
            };
        }

        inicializaModel();

        $scope.post = function () {
            var caminhoApiModulo = "http://" + window.location.hostname + ":17463/api/Coperativa";
            var a = $scope.model;
            $.post(caminhoApiModulo, a)
                .success(function () {
                    toastr.success('Cooperativa cadastrada com sucesso.');
                })
                .error(function () {
                    toastr.error('Erro ao enviar dados.');
                });
            inicializaModel();
        };
    });

    app.controller('editarCtrl', function ($scope, buscarService, coperativa) {
        if (coperativa.status == 200) {
            $scope.model = coperativa.data;
        }
    });
})();





