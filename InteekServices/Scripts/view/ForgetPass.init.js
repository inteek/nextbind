if (window['jQuery'] != undefined) {

    jQuery(function () {
        "use strict";

        _init();

        function initSignIn() {

        }
        function _init() {
            initSignIn();
        }

        $("#btnReset").on("click", function () {
            debugger
            var mail = $("#txtEmail").val();
            var data = { email: mail };
            conectarAsy("SolReestablecerPassword", data, function (result) {
                if (result.error == false)
                {
                    alert("Se ha enviado un correo a tu cuenta de correo electronico");
                    location.href = result.page;
                }
                else
                    alert(result.msg);
            });

        });
    });
}