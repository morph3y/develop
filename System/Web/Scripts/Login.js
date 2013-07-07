registerNamespace("System.Login");

System.Login = {
    init: function () {
        var loginForm = $('.loginForm');
        var loginButton = $("#loginButton");
        var logoutButton = $('#logoutButton');
        var loginText = $('#loginText');
        var submitButton = $('#submit');

        loginForm.hide();
        loginButton.on("click", function (e) {
            loginForm.slideToggle("slow");
            e.preventDefault();
        });
        logoutButton.css('display', 'none');

        submitButton.on("click", function () {
            var username = $('#inputLogin').val();
            var password = $('#inputPassword').val();
            var url = $('#submit').attr('href');
            var data = { username: username, password: password };

            var successMethod = function (response) {
                if (response.result) {
                    loginText.text(response);
                    loginForm.slideToggle("slow");
                    logoutButton.css('display', 'block');
                    loginButton.css('display', "none");
                }
                else {
                    loginForm.slideToggle("slow");
                }
            };

            var failMethod = function (response) {
                loginForm.slideToggle("slow");
            };

            System.postData(data, url, successMethod, failMethod);

            return false;
        });

        logoutButton.on('click', function () {
            var url = logoutButton.attr('href');

            var successMethod = function (response) {
                loginText.text("");
                logoutButton.css('display', 'none');
                loginButton.css('display', "block");
            };

            var failMethod = function (response) {
                loginForm.slideToggle("slow");
            };

            System.postData({}, url, successMethod, failMethod);

            return false;
        });
    }
};

$(document).ready(function () {
    System.Login.init();
});