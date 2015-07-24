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

window.onbeforeunload = function() {
    localStorage["usuarioId"] = "";
};

function validarCNPJ(cnpj) {

    if (cnpj == null || cnpj == '') return true;

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj.length != 14)
        return false;

    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999")
        return false;

    // Valida DVs
    var tamanho = cnpj.length - 2;
    var numeros = cnpj.substring(0, tamanho);
    var digitos = cnpj.substring(tamanho);
    var soma = 0;
    var pos = tamanho - 7;
    for (var i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    var resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
        return false;

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
        return false;

    return true;
}

/* Upload Imagem */
var files;
$(document).on('change', '#pdffile', function (event) {
    var a = $(this).val().split('\\');
    $('#subfile').val(a.length > 0 ? a[a.length - 1] : "");

    var reader = new FileReader();
    $(reader).load(function (event) {
        $("#imgPerfil").attr("src", event.target.result);
    });
    reader.readAsDataURL(event.target.files[0]);
    return true;
});
$(document).on('submit', '#form', function () {
    if (files != null && files.length > 0) {
        if ($('#pdffile').val().lastIndexOf('.png') === -1 && $('#pdffile').val().lastIndexOf('.jpeg') === -1) {
            toastr.error("Somente imagem png ou jpeg");
            $('#pdffile').val('');
            return;
        }
        if (window.FormData !== undefined) {
            var data = new FormData();
            for (var x = 0; x < files.length; x++) {
                data.append("file" + x, files[x]);
            }
            var caminho = $('#pdffile').data('caminho');
            $.ajax({
                type: "POST",
                url: caminhoApi + 'Upload/UploadFile?id=' + caminho,
                contentType: false,
                processData: false,
                data: data,
                success: function (result) {
                    console.log(result);
                },
                error: function (xhr, status, p3, p4) {
                    var err = "Error " + " " + status + " " + p3 + " " + p4;
                    if (xhr.responseText && xhr.responseText[0] == "{")
                        err = JSON.parse(xhr.responseText).Message;
                    console.log(err);
                }
            });
        } else {
            toastr.error("This browser doesn't support HTML5 file uploads!");
        }
    }
});
$(document).on('change', '#pdffile', function (e) {
    files = e.target.files;
});