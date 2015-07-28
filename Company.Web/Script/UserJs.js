function validateInput() {
    var isOk = true;
    if ($("#UName").val() == "" || $("#UName").val().length > 20) {
        $("#UName").focus();
        msgbox.showMsgErr("用户名不能为空，长度不能超过20个字符");
        isOk = false;
    }
    else if ($("#ULoginName").val() == "" || $("#ULoginName").val().length > 20) {
        $("#ULoginName").focus();
        msgbox.showMsgErr("登录名不能为空，长度不能超过20个字符");
        isOk = false;
    }
    else if ($("#UPwd").val() == "" || $("#UPwd").val().length > 20) {
        $("#UPwd").focus();
        msgbox.showMsgErr("密码不能为空，长度不能超过20个字符");
        isOk = false;
    }
    else if ($("#UPwd").val() != $("#UPwdRepeat").val()) {
        $("#UName").focus();
        msgbox.showMsgErr("密码不一致");
        isOk = false;
    }
    else if ($("#UCode").val() == "") {
        $("#UName").focus();
        msgbox.showMsgErr("验证码不能为空");
        isOk = false;
    }
    return isOk;
}