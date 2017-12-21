var self_login = function () {
    $("#userLogin").click(function () {
        $("#userLogin").attr("disabled", "disabled");
        //$("#userLogin").html("正在登录...");
        var loginNum = 0;

        var data = {
            "username": $("#username").val(),
            "pwd": $("#password").val(),
            "remember": $("input[name='remember']").is(":checked")
        };

        $.ajax({
            url: "/Login/CheckLogin",
            data: data,
            type: "post",
            dataType: "Json",
            success: function (data) {
                if (data.success) {

                    //$("#code").attr("style", "display:none");
                    $("#userLogin").removeAttr("disabled");
                    //$("#userLogin").html("登 录");
                    //self_errorHidden();
                    loginNum = 0;
                    $("#password").val("");
                    //$("#valiCode").val("");
                    swal({
                        title: "提示！",
                        text: "登录成功！",
                        icon: "success",
                        button: false
                    });
                    window.location.href = "/";

                }
                else {
                    swal({
                        title: "提示！",
                        text: "登录失败，" + data.error + "！",
                        icon: "error"
                    });
                    // 每次登录失败后次数 + 1
                    loginNum++;
                    $("#userLogin").removeAttr("disabled");
                    //$("#userLogin").html("登 录");
                    if (loginNum >= 3) {
                        //self_valiCode();
                        //$("#code").removeAttr("style");
                    }
                    //self_errorShow();
                    //return $("#userError").html(data.error);
                }
            }
        });
    });
}();