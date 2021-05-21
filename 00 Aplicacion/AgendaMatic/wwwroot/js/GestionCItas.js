function anularCita(idCita) {
    var data = {};
    data.Id = idCita;

    $.ajax({
        type: "POST",
        url: "/Usuario/AnularCita/",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.status) {
                $("#divTextModal").html("<p>Cita Anulada</p>");
                $("#divTextModal").show();
                window.location = '../Home/Index';
            }
            else {
                $("#divTextModal").html("<p>" + msg.messege + "/p>");
                $("#divTextModal").show();
                $('#modal').modal();
            }
        }
    });
}

function agendarCita(idBloque)
{
    var data = {};
    data.IdBloque = idBloque;
    data.Nombre = $('#inputNombreCita').val();
    data.Descripcion = $('#inputDescripcion').val();

    $.ajax({
        type: "POST",
        url: "/Usuario/AgendarCita/",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.status) {
                $("#alertAgendar").html("<div class='alert alert-success' role='alert'>¡Agendado!</div >");
                $("#alertAgendar").show();
                setTimeout("location.href='/Home/Index'", 2000)
            }
            else {
                $("#alertAgendar").html("<div class='alert alert-danger' role='alert'>" + msg.messege + "</div >");
                $("#alertAgendar").show();
            }
        }
    });
}

