if (window['jQuery'] != undefined) {

    jQuery(function () { "use strict";

        _init();

        function initSignIn() {

        }
        function _init() {
            initSignIn();
        }

        window.onload = function () {
            debugger
            var variable = getUrlVar()["exit"];
            if(typeof variable == "undefined"){
                conectarAsy("Login/AutenticacionAutomatica", null, function (result) {
                    debugger
                    if (result != null)
                        if (result.error == false) {
                            location.href = result.page;
                        }
                });
            }
        }

        function getUrlVar() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }

        $("#btnSignIn").on("click", function () {
            debugger

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




