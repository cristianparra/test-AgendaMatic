function login() {
    $("#alert").hide();
    var data = {};
    data.usuario = $("#inputEmail").val();
    data.contrasena = $("#inputPassword").val();

    $.ajax({
        type: "POST",
        url: "/Usuario/Login/",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.status) {
                $("#alert").html("<div class='alert alert-success' role='alert'>Correcto!</div >");
                $("#alert").show();
                window.location = '../Home/Index';
            }
            else {
                $("#alert").html("<div class='alert alert-danger' role='alert'>" + msg.messege + "</div >");
                $("#alert").show();
            }
        }
    });
}

function registro() {
    $("#alert").hide();
    var data = {};
    data.nombre = $("#inputNombre").val();
    data.apellido = $("#inputApellido").val();
    data.correo = $("#inputEmail").val();
    data.contrasena = $("#inputPassword").val();

    $.ajax({
        type: "POST",
        url: "/Usuario/RegistroUsuario/",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        dataType: "json",
        async: false,
        success: function (msg) {
            if (msg.status) {
                $("#alert").html("<div class='alert alert-success' role='alert'>Correcto! Iremos al Login en 5 Segundos</div >");
                $("#alert").show();
                setTimeout("location.href='/Home/Login'", 3000)
            }
            else {
                $("#alert").html("<div class='alert alert-danger' role='alert'>" + msg.messege + "</div >");
                $("#alert").show();
            }
        }
    });
}