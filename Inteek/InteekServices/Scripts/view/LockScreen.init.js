if (window['jQuery'] != undefined) {

    jQuery(function () {
        "use strict";

        _init();

        function initSignIn() {

        }
        function _init() {
            initSignIn();
        }

        $("#btnSignIn").on("click", function () {
            debugger
            var cookie = getCookie("UserInfo");
            var user = cookie.split('&')[0].split('=')[1];
            var pass = $("#txtPass").val();


            var data = {
                user: user,
                password: pass,
                remmemberPassword: true
            };

            $.ajax({
                type: "POST",
                timeout: 3000000,
                async: true,
                url: "Validate",
                data: JSON.stringify(data),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (mydata) {
                    debugger;
                    if (mydata != null) {
                        location.href = mydata.page;
                    }
                },
                error: function (e) {
                    console.log(e.responseText);
                },
            });
        });


        function getCookie(cname) {
            var name = cname + "=";
            var decodedCookie = decodeURIComponent(document.cookie);
            var ca = decodedCookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        }
    });
}