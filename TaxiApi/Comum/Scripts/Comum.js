function usuarioLog() {
    var usua = localStorage.getItem('usuarioId');
    if (usua == null || usua == "") {
        window.location.href = "http://" + window.location.host + "/Coperativa/Login/index.html";
    }
    return angular.fromJson(usua);
}
$(window).unload(function () {
    localStorage["usuarioId"] = "";
});

window.onbeforeunload = function () {
    localStorage["usuarioId"] = "";
}