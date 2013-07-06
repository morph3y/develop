$(document).ready(function () {
    $('.loginForm').hide();
    $("#loginButton").on("click", function (e) {
        $('.loginForm').slideToggle("slow");
        e.preventDefault();
    });
    $('#logoutButton').css('display', 'none');

    $('#submit').on("click", function () {
        var username = $('#inputLogin').val();
        var password = $('#inputPassword').val();
        var url = $('#submit').attr('href');

        $.ajax({
            type: 'POST',
            url: url,
            data: {
                userName: username,
                password: password
            },
            success: function (data) {
                $('.loginStatus').prepend(data);
                $('.loginForm').slideToggle("slow");
                $('#logoutButton').css('display', 'block');
                $("#loginButton").css('display', "none");
            },
            error: function () {
                $('.loginForm').slideToggle("slow");
            }
        });
        return false;
    });

    $('#logoutButton').on("click", function () {
        var url = $('#logoutButton').attr('href');
        $.ajax({
            type: 'POST',
            url: url,
            data: { },
            success: function (data) {
                $('#logoutButton').css('display', 'none');
                $("#loginButton").css('display', "block");
            },
            error: function () {
                $('.loginForm').slideToggle("slow");
            }
        });
        return false;
    });
});