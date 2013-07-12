registerNamespace("System.Login");

System.Login = {
    init: function () {
        var loginForm = $('.loginForm');
        var loginButton = $("#loginButton");
        var submitButton = $('#submit');

        if (loginButton[0] != undefined) {
            loginButton.on("click", function (e) {
                loginForm.slideToggle("slow");
                e.preventDefault();
            });
        }

        var refreshMethod = function() {
            document.location.reload(true);
        };

        submitButton.on("click", function () {
            var username = $('#inputLogin').val();
            var password = $('#inputPassword').val();
            var url = $('#submit').attr('href');
            var data = { username: username, password: password };

            System.postData(data, url, refreshMethod, refreshMethod);

            return false;
        });
    }
};

$(document).ready(function () {
    System.Login.init();
});