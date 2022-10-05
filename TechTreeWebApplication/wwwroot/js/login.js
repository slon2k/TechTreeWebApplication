const URL = "/Identity/Account/Login?handler=LoginPartial";

$(function () {
    var loginButton = $("#UserLoginModal button[name='login']").click(onLoginClick);
    var url = URL

    function onLoginClick() {
        var antiForgeryToken = $("#UserLoginForm input[name='__RequestVerificationToken']").val();
        var email = $("#UserLoginForm input[name='Email']").val();
        var password = $("#UserLoginForm input[name='Password']").val();
        var rememberMe = $("#UserLoginForm input[name='RememberMe']").prop('checked');

        var input = {
            Email: email,
            Password: password,
            RememberMe: rememberMe,
            __RequestVerificationToken: antiForgeryToken
        }

        $.ajax({
            type: "POST",
            url: url,
            data: input,
            success: function (data) {
                var parsed = $.parseHTML(data);

                var success = $(parsed).find("input[name='Success']").val();

                if (success == 'True') {
                    $('#UserLoginModalBody').html(data);
                    location.href = "/";
                    window.location.reload();
                } else if (success == 'False') {
                    $('#UserLoginModalBody').html(data);
                    loginButton = $("#UserLoginModal button[name='login']").click(onLoginClick);

                    var form = $("#UserLoginForm");
                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);

                } else {
                    location.href = "/";
                }
                
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + "/r/n" + xhr.statusText + "/r/n" + xhr.responseText)
            }
        });

        console.log(input);

    };
})


$(document).ready(function () {
    $('#UserLoginModalBody').load(URL);
});

