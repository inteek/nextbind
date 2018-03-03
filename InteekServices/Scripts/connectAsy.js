function conectarAsy(url, data, callback) {
    debugger;
    var datos = new Object();
    if (typeof data == "undefined" || data == null) {
        $.ajax({
            type: "POST",
            timeout: 3000000,
            async: true,
            url: url,
            contentType: "application/json; charset=utf-8",
            success: function (mydata) {
                if (mydata != null) {
                    datos = mydata;
                }
            },
            error: function (e) {
                console.log(e.responseText);
                //sweetAlert("Exportacion", "Error de conexion.", "error");
            },
            complete: function (e) {
                callback(datos);
            }
        });
    } else {

        $.ajax({
            type: "POST",
            timeout: 3000000,
            async: true,
            url: url,
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (mydata) {
                debugger;
                if (mydata != null) {
                    datos = mydata;
                }
            },
            error: function (e) {
                debugger;
                //alert("Error de conexion.");
                console.log(e.responseText);
                //sweetAlert("Exportacion", "Error de conexion.", "error");
            },
            complete: function (e) {
                debugger;
                callback(datos);
            }
        });
    }

    return datos;
}

