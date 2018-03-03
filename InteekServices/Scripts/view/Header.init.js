//if (window['jQuery'] != undefined) {

    //jQuery(function () {
    //    "use strict";

    //    _init();

    //    function initSignIn() {

    //    }
    //    function _init() {
    //        initSignIn();
    //    }

function Funcion() {
            conectarAsy("Salir",null, function (result) {
                debugger
                if (result.error == false) {
                    location.href = result.page;
                }
                else
                {
                    alert("error");
                }
            });
        }
 //  });
//}