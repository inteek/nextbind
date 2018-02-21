if (window['jQuery'] != undefined) {

    jQuery(function () {
        "use strict";

        _init();

        var userEmail;
        function initSignIn() {

        }
        function _init() {
            initSignIn();
        }

        window.onload = function () {
           userEmail = getQueryVariable("email");
        }
        
        $("#btnReset").on("click", function () {
            debugger
            if(ValidarContraseñas())
            {
               //var userEmail = getQueryVariable("email");
                var pass = $("#txtPassword").val();
                var data = {
                    user: userEmail,
                    password: pass
                }
                conectarAsy("CambioPassword", data, function (result) {
                    alert(result.msg);
                });
            }

        });

        function ValidarContraseñas() {
            var pwd1 = $("#txtPassword").val();
            var pwd2 = $("#txtRePassword").val();

            if (pwd1 != pwd2) {
                Mensaje("Las contraseñas no coinciden");
                return false;
            }
            else
                return true
        }

        function Mensaje(mensaje) {
            document.getElementById("mensaje1").innerHTML = mensaje;
            $("#mensaje1").fadeIn(1500);
            $("#mensaje1").fadeOut(1500);
        }


        function getQueryVariable(variable) {
            var query = window.location.search.substring(1);
            var vars = query.split("&");
            for (var i = 0; i < vars.length; i++) {
                var pair = vars[i].split("=");
                if (pair[0] == variable) { return pair[1]; }
            }

            return null;
        }

    });
}