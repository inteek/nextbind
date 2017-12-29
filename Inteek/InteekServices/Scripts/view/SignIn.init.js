if (window['jQuery'] != undefined) {

    jQuery(function () { "use strict";

        _init();

        function initSignIn() {

        }
        function _init() {
            initSignIn();
        }



        $("#btnSignIn").on("click", function () {

            var user = $("#txtUser").val();
            var pass = $("#txtPass").val();
            var remember = $("#chkSave").is(':checked') ? true : false;


            var data = {
                    user: user,
                    password: pass,
                    remmemberPassword: remember
            };


            conectarAsy("Login/Validate", data, function (result) {
                debugger
                if(result.error == false)
                {
                    location.href = result.page; //$("#btnSignIn").attr("dataUrl");
                }
            });


            //location.href = $(this).attr("dataUrl");
        })

    });


   
    


}




