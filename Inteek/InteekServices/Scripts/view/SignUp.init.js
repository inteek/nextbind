/// <reference path="../plugins/sweetalert.min.js" />
if (window['jQuery'] != undefined) {

    jQuery(function () {
        "use strict";

        _init();

        function initSignIn() {

        }
        function _init() {
            initSignIn();
        }

        $(document).ready(function () {
            $("#txtName").attr("background-color",)
        });

        $("#btnSignUp").on("click", function () {
            debugger
            var datos = new Object();
            var user = $("#txtName").val().trim();
            var userFirst = $("#txtFirstName").val().trim();
            var userLast = $("#txtLastName").val().trim();
            var email = $("#txtEmail").val().trim();
            var pass = $("#txtPassword").val().trim();
            var rePass = $("#txtRePassword").val().trim();
            var accept = $("#chkTerms").is(':checked') ? true : false;

            if (user == "" || userFirst == "" || userLast == "" || email== "" || pass == "" || rePass == "") {
                Mensaje("Faltan campos por introducir");
            }
            else {
                if (Terminos() && ValidarContraseñas()) {
                    var data = {
                        user: user,
                        userFirst: userFirst,
                        userLast: userLast,
                        email: email,
                        password: pass
                    };

                    conectarAsy("AgregarUsuario", data, function (result) {
                        if (result.error == false) {
                            if (result.noError == 1) {
                                Mensaje(result.msg);
                            }
                            else {
                                location.href = result.page;
                            }
                        }
                    });
                }
            }
        })

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

        function Terminos() {
            var accept = $("#chkTerms").is(':checked') ? true : false;
            if (!accept) {
                Mensaje("Debes aceptar los terminos y condiciones");
                return false;
            }
            else
                return true;
        }

        function Mensaje(mensaje) {
            document.getElementById("mensaje1").innerHTML = mensaje;
            $("#mensaje1").fadeIn(1500);
            $("#mensaje1").fadeOut(1500);
        }
    });
}