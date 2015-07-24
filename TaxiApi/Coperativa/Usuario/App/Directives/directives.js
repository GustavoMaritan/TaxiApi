(function () {
    var app = angular.module('directives', []);

    app.directive("mascaraDt", function ($filter) {
        return {
            require: "ngModel",
            link: function (scope, element, attrs, ctrl) {
                setTimeout(function () {
                    ctrl.$setViewValue(ctrl.$viewValue.split('T')[0]);
                    ctrl.$render();
                    element.attr('type', 'date');
                }, 100);
            }
        };
    });

    app.directive("mascaraData", function ($filter) {
        return {
            require: "ngModel",
            link: function (scope, element, attrs, ctrl) {

                var _formatDate = function (date) {

                    if (date == null)
                        return "";

                    date = date.replace(/[^0-9]+/g, "");
                    if (date.length > 2) {
                        date = date.substring(0, 2) + "/" + date.substring(2);
                    }
                    if (date.length > 5) {
                        date = date.substring(0, 5) + "/" + date.substring(5, 9);
                    }
                    return date;
                };

                element.bind("keyup", function () {
                    ctrl.$setViewValue(_formatDate(ctrl.$viewValue));
                    ctrl.$render();
                });

                ctrl.$parsers.push(function (value) {
                    return value;
                });

                ctrl.$formatters.push(function (value) {
                    return $filter("date")(value, "dd/MM/yyyy");
                });

                setTimeout(function() {
                    element.trigger("keyup");
                }, 10);
            }
        };
    });
    
    app.directive("mascaraTelefone", function ($filter) {
        return {
            require: "ngModel",
            link: function (scope, element, attrs, ctrl) {

                var _formatTelefone = function (tel) {
                    
                    if (tel == null)
                        return "";

                    tel = tel.replace(/[^0-9]+/g, "");
                    
                    if (tel.length > 4) {
                        tel = tel.substring(0, 4) + "-" + tel.substring(4);
                    }
                    
                    if (tel.length > 8) {
                        tel = tel.substring(0, 4) + "-" + tel.substring(5,9);
                    }
                    
                    return tel;
                };

                element.bind("keyup", function () {
                    ctrl.$setViewValue(_formatTelefone(ctrl.$viewValue));
                    ctrl.$render();
                });

                ctrl.$parsers.push(function (value) {
                    return value.replace('-', '');
                });

                setTimeout(function() {
                    element.trigger("keyup");
                }, 10);
            }
        };
    });

    app.directive("mascaraInt", function ($filter) {
        return {
            require: "ngModel",
            link: function (scope, element, attrs, ctrl, tipo) {

                var formatInt = function (inteiro) {
                    if (inteiro == null)
                        return "";

                    return inteiro.replace(/[^0-9]+/g, "");
                };

                element.bind("keyup", function () {
                    ctrl.$setViewValue(formatInt(ctrl.$viewValue));
                    ctrl.$render();
                });
                
                element.bind("blur", function () {
                    if (ctrl.$viewValue == null || ctrl.$viewValue == "") {
                        ctrl.$setViewValue("0");
                        ctrl.$render();
                    }
                });

                ctrl.$parsers.push(function (value) {
                    return value;
                });

            }
        };
    });

    app.directive("mascaraCep", function ($filter) {
        return {
            require: "ngModel",
            link: function (scope, element, attrs, ctrl) {

                var formatCep = function (cep) {

                    cep = cep.replace(/[^0-9]+/g, "");

                    if (cep.length > 5) {
                        cep = cep.substring(0, 5) + "-" + cep.substring(5);
                    }

                    if (cep.length > 9) {
                        cep = cep.substring(0, 5) + "-" + cep.substring(6, 9);
                    }
                    return cep;
                };
                
                var padLr = function (value, leftRight) {
                    var str = "" + value.replace('-', '');
                    var pad = "00000000";
                    var valor = pad.substring(0, pad.length - str.length);
                    return leftRight == "R" ? str + valor : valor + str;
                };

                element.bind("keyup", function () {
                    ctrl.$setViewValue(formatCep(ctrl.$viewValue));
                    ctrl.$render();
                });

                element.bind("blur", function () {
                    if (ctrl.$viewValue != null && ctrl.$viewValue != "") {
                        ctrl.$viewValue = padLr(ctrl.$viewValue,"R");
                        element.trigger("keyup");
                    }
                });

                ctrl.$parsers.push(function (value) {
                    return value.replace('-', '');
                });

                setTimeout(function () {
                    if (ctrl.$viewValue != null && ctrl.$viewValue != "") {
                        ctrl.$viewValue = padLr(ctrl.$viewValue, "L");
                        element.trigger("keyup");
                    }
                }, 10);
            }
        };
    });

    app.directive("mascaraCelular", function ($filter) {
        return {
            require: "ngModel",
            link: function (scope, element, attrs, ctrl, tipo) {

                var formatCelular = function (cel) {

                    if (cel == null)
                        return "";

                    cel = cel.replace(/[^0-9]+/g, "");

                    if (cel.length > 4) {
                        cel = cel.substring(0, 4) + "-" + cel.substring(4);
                    }

                    if (cel.length > 9) {
                        var ctx = cel.replace('-', '');
                        cel = ctx.substring(0, 5) + "-" + ctx.substring(5, 9);
                    }

                    return cel;
                };

                element.bind("keyup", function () {
                    ctrl.$setViewValue(formatCelular(ctrl.$viewValue));
                    ctrl.$render();
                });

                ctrl.$parsers.push(function (value) {
                    return value.replace('-', '');
                });

                setTimeout(function() {
                    element.trigger("keyup");
                }, 10);
            }
        };
    });
    
    app.directive("mascaraCnpj", function ($filter) {
        return {
            require: "ngModel",
            link: function (scope, element, attrs, ctrl, tipo) {

                var formatCnpj = function (inteiro) {
                    if (inteiro == null)
                        return "";
                    inteiro = inteiro.replace(/[^0-9]+/g, "");
                    
                    if (inteiro.length > 2 && inteiro.length <= 5) {
                        inteiro = inteiro.substring(0, 2) + "." + inteiro.substring(2);
                    }
                    else if (inteiro.length > 5 && inteiro.length <= 8) {
                        inteiro =
                            inteiro.substring(0, 2) + "." +
                            inteiro.substring(2, 5) + "." +
                            inteiro.substring(5);
                    }
                    else if (inteiro.length > 8 && inteiro.length <= 12) {
                        inteiro =
                            inteiro.substring(0, 2) + "." +
                            inteiro.substring(2, 5) + "." +
                            inteiro.substring(5, 8) + "/"+
                            inteiro.substring(8);
                    }
                    else if (inteiro.length > 12) {
                        inteiro =
                            inteiro.substring(0, 2) + "." +
                            inteiro.substring(2, 5) + "." +
                            inteiro.substring(5, 8) + "/"+
                            inteiro.substring(8, 12) + "-" +
                            inteiro.substring(12);
                    }
                    return inteiro;
                };

                element.bind("keyup", function () {
                    ctrl.$setViewValue(formatCnpj(ctrl.$viewValue));
                    ctrl.$render();
                });
                
                element.bind("blur", function () {
                    if (!validarCNPJ(ctrl.$viewValue)) {
                        element[0].focus();
                        toastr.warning("Cnpj Inválido.");
                    }
                });

                ctrl.$parsers.push(function (value) {
                    return value != null ? value.replace(/[^0-9]+/g, "") : "";
                });

                setTimeout(function () {
                    element.trigger("keyup");
                }, 10);
            }
        };
    });
    
    app.directive("mascaraMoney", function ($filter) {
        return {
            require: "ngModel",
            link: function (scope, element, attrs, ctrl, tipo) {

                var formatCnpj = function (inteiro) {
                    if (inteiro == null)
                        return "";

                    var mon = inteiro.split(',');

                    mon[0] = mon[0].replace(/[^0-9]+/g, "");
                    var rev = mon[0].split("").reverse().join("");
                    var money = "";
                    for (var i = 1; i <= rev.length; i++) {
                        money += rev[i - 1];
                        if (i >= 3 && i % 3 == 0 && i != rev.length) {
                            money += ".";
                        }
                    }
                    if (mon.length > 1) {
                        if (mon[1].length > 2) {
                            mon[1] = mon[1].substring(0, 2);
                        }
                        return money.split("").reverse().join("") + "," + mon[1];
                    } else {
                        return money.split("").reverse().join("");
                    }
                };

                element.bind("keyup", function (code) {
                    ctrl.$setViewValue(formatCnpj(ctrl.$viewValue));
                    ctrl.$render();
                });

                element.bind("blur", function () {
                    if (ctrl.$viewValue == null || ctrl.$viewValue == "") {
                        ctrl.$setViewValue("0,00");
                    } else {
                        var mon = ctrl.$viewValue.split(',');
                        if (mon.length > 1) {
                            if (mon[1].length == 0) {
                                mon[1] = "00";
                            } else if (mon[1].length == 1) {
                                mon[1] += "0";
                            }
                            ctrl.$setViewValue(mon[0] + "," + mon[1]);
                        } else {
                            ctrl.$setViewValue(ctrl.$viewValue + ",00");
                        }
                    }
                    ctrl.$render();
                });
                
                element.bind("keydown", function (evt) {
                    evt = evt || window.event;
                    if ((evt.keyCode >= 96 && evt.keyCode <= 105) ||
                        (ctrl.$viewValue.indexOf(',') == -1 && evt.keyCode == 110) ||
                        evt.keyCode == 8 ||
                        (evt.keyCode >= 48 && evt.keyCode <= 57)) {
                        return true;
                    } else {
                        return false;
                    }
                });
                
                ctrl.$parsers.push(function (value) {
                    var a = value.replace(/[.]+/g, "");
                    return a.replace(',', ".");
                });

                setTimeout(function () {
                    ctrl.$viewValue = ctrl.$viewValue.replace('.', ",");
                    if (ctrl.$viewValue == null || ctrl.$viewValue == "") {
                        ctrl.$viewValue = "0,00";
                    } else if (ctrl.$viewValue.split(',').length < 2) {
                        ctrl.$viewValue = ctrl.$viewValue + ",00";
                    }
                    element.trigger("keyup");
                }, 10);
            }
        };
    });
})();