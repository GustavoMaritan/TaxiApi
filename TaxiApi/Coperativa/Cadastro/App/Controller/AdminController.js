(function () {
    var app = angular.module('adminControllers', ['infinite-scroll']);

    app.controller('buscaAdmCtrl', function ($scope, adminService, listAdmin) {
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
            alertify.confirm("Deseja excluir o administrador?", function(e) {
                if (e) {
                    var index = $scope.todos.indexOf(todo);
                    var index1 = $scope.filteredTodos.indexOf(todo);
                    var id = $scope.todos[index].Id;
                    adminService.delete(id)
                        .success(function(data) {
                            if (data.error == "") {
                                toastr.success("Administrador excluido com sucesso.");
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

        if (listAdmin.status == 200) {
            $scope.todos = listAdmin.data;
            $scope.pageChanged();
            totPag($scope.todos.length, $scope.numPerPage);
        }
    });
    
    app.controller('cadastroAdmCtrl', function ($scope, adminService) {
        var user = usuarioLog();

        function inicializaModel() {
            $scope.model = {
                Nome: "",
                Email: "",
                Senha: "",
                Login:""
            };
        };

        inicializaModel();

        $scope.post = function () {
            var a = $scope.model;
            adminService.post(a)
                .success(function (data) {
                    if (data.error == "") {
                        inicializaModel();
                        toastr.success('Administrador cadastrado com sucesso.');
                    } else {
                        toastr.error(data.error);
                    }
                })
                .error(function () {
                    toastr.error('Erro ao enviar dados.');
                });
        };
    });
    
    app.controller('editarAdmCtrl', function ($scope, adminService, admin) {

        if (admin.status == 200) {
            $scope.model = admin.data;
        }
        $scope.put = function () {
            var a = $scope.model;
            adminService.put(a)
                .success(function (data) {
                    if (data.error == "") {
                        toastr.success('Administrador editada com sucesso.');
                        window.location.href = "#/Admin/Buscar";
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