////////////////////////////////////////////////////////////
// Click đăng ký, đăng nhập
///////////////////////////////////////////////////////////

function UserClick(str) {
    if (str == 'signin') {
        $('#divChangePass').css("display", "none");
        $('#divSignIn').css("display", "block");
        $('#divProcessing').css("display", "none");
        $('#divNotRememberPass').css("display", "none");
        $('#divNotRememberPassNotice').css("display", "none");
    }
    else if (str == 'changepass') {
            $('#divChangePass').css("display", "block");
            $('#divSignIn').css("display", "none");
            $('#divProcessing').css("display", "none");
            $('#divNotRememberPass').css("display", "none");
            $('#divNotRememberPassNotice').css("display", "none");
        }

    $('#basic-modal-content').modal();

    return false;
};

////////////////////////////////////////////////////////////
// Goi lại popup khi đăng ký xong, hoặc đăng nhập
///////////////////////////////////////////////////////////

function UserInSideClick(str) {
   if (str == 'signin') {
        $('#divNotRememberPass').css("display", "none");
        $('#divNotRememberPassNotice').css("display", "none");
        $('#divSignIn').css("display", "block");
        $('#divProcessing').css("display", "none");
        $('#divChangePass').css("display", "none");
    }
   else if (str == 'notrememberpass') {
        $('#divSignIn').css("display", "none");
        $('#divNotRememberPass').css("display", "block");
        $('#divNotRememberPassNotice').css("display", "none");
        $('#divProcessing').css("display", "none");
        $('#divChangePass').css("display", "none");
    }
    else if (str == 'notrememberpassnotice') {
        $('#divSignIn').css("display", "none");
        $('#divNotRememberPass').css("display", "none");
        $('#divNotRememberPassNotice').css("display", "block");
        $('#divProcessing').css("display", "none");
        $('#divChangePass').css("display", "none");
    }
    else if (str == 'loading') {
        $('#divSignIn').css("display", "none");
        $('#divNotRememberPass').css("display", "none");
        $('#divNotRememberPassNotice').css("display", "none");
        $('#divProcessing').css("display", "block");
        $('#divChangePass').css("display", "none");
    }
    else if (str == 'changepass') {
        $('#divSignIn').css("display", "none");
        $('#divNotRememberPass').css("display", "none");
        $('#divNotRememberPassNotice').css("display", "none");
        $('#divProcessing').css("display", "none");
        $('#divChangePass').css("display", "block");
    }
    $('#simplemodal-container').css("height", "auto");
};

////////////////////////////////////////////////////////////
// Check ChangPass
///////////////////////////////////////////////////////////

function validateOldPass() {
    var OldPassword_ChangePass = $("#txtOldPassword_ChangePass");
    var OldPassword_ChangePassInfo = $("#OldPassword_ChangePass");
    //it's NOT valid
    if (OldPassword_ChangePass.val().length < 6) {
        OldPassword_ChangePass.addClass("textboxerror");
        OldPassword_ChangePassInfo.text("Mật khẩu phải > 5 ký tự!");
        OldPassword_ChangePassInfo.addClass("error");
        return false;
    }
    //it's valid
    else {
        OldPassword_ChangePass.removeClass("textboxerror");
        OldPassword_ChangePassInfo.text("");
        OldPassword_ChangePassInfo.removeClass("error");
        return true;
    }
}
function validateNewPass() {
    var NewPassword_ChangePass = $("#txtNewPassword_ChangePass");
    var NewPassword_ChangePassInfo = $("#NewPassword_ChangePass");
    //it's NOT valid
    if (NewPassword_ChangePass.val().length < 6) {
        NewPassword_ChangePass.addClass("textboxerror");
        NewPassword_ChangePassInfo.text("Mật khẩu phải > 5 ký tự!");
        NewPassword_ChangePassInfo.addClass("error");
        return false;
    }
    //it's valid
    else {
        NewPassword_ChangePass.removeClass("textboxerror");
        NewPassword_ChangePassInfo.text("");
        NewPassword_ChangePassInfo.removeClass("error");
        return true;
    }
}
function validateReNewPass() {
    var NewPassword_ChangePass = $("#txtNewPassword_ChangePass");
    var ReNewPassword_ChangePass = $("#txtReNewPassword_ChangePass");
    var ReNewPassword_ChangePassInfo = $("#ReNewPassword_ChangePass");
    if (ReNewPassword_ChangePass.val().length < 6) {
        ReNewPassword_ChangePass.addClass("textboxerror");
        ReNewPassword_ChangePassInfo.text("Mật khẩu phải > 5 ký tự!");
        ReNewPassword_ChangePassInfo.addClass("error");
        return false;
    }
    //it's valid
    else {
        if (NewPassword_ChangePass.val() != ReNewPassword_ChangePass.val()) {
            ReNewPassword_ChangePass.addClass("textboxerror");
            ReNewPassword_ChangePassInfo.text("Mật khẩu nhập không đúng!");
            ReNewPassword_ChangePassInfo.addClass("error");
            return false;
        }
        //are valid
        else {
            ReNewPassword_ChangePass.removeClass("textboxerror");
            ReNewPassword_ChangePassInfo.text("");
            ReNewPassword_ChangePassInfo.removeClass("error");
            return true;
        }
    }
}

function ChangePassClick() {
    if (validateOldPass() & validateNewPass() & validateReNewPass())
        return true;
    else
        return false;
}


////////////////////////////////////////////////////////////
// Goi Ajax ChangePass
///////////////////////////////////////////////////////////

function CallAjaxChangePass() {
    var strurl = '';
    var strdata = '';
    // nhấn nút đăng ký
    if (ChangePassClick()) {
        UserInSideClick('loading');
        strurl = "../Process/AjaxProcess.aspx/ChangePass";
        strdata = "{'oldpass':'" + $("#txtOldPassword_ChangePass").val() + "','newpass':'" + $("#txtNewPassword_ChangePass").val() + "','renewpass':'" + $("#txtReNewPassword_ChangePass").val() + "'}";
        $.ajax({
            type: "POST",
            url: strurl,
            data: strdata,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus) {
                if (data != null && data.d != null && data.d == true) {
                    UserInSideClick('changepass');
                    $("#lbError_ChangePass").text("Thay đổi mật khẩu thành công!");                    
                }
                else {
                    UserInSideClick('changepass');
                    $("#lbError_ChangePass").text("Thay đổi mật khẩu thất bại! bạn vui lòng thử lại!");
                }
            },
            error: function () {
                UserInSideClick('changepass');
                $("#lbError_ChangePass").text("Lỗi hệ thống, bạn vui lòng quay lại sau!");
            }
        });
    }
    else {
        return false;
    }
}


////////////////////////////////////////////////////////////
// Check ForgetPassword
///////////////////////////////////////////////////////////

// check Email
function validateEmailNotRememberPass() {
    var Email_NotRememberPass = $("#txtEmail_NotRememberPass");
    var Email_NotRememberPassInfo = $("#Email_NotRememberPassInfo");
    //testing regular expression
    //var filter = /^[a-zA-Z0-9]+[a-zA-Z0-9_.-]+[a-zA-Z0-9_-]+@[a-zA-Z0-9]+[a-zA-Z0-9.-]+[a-zA-Z0-9]+.[a-z]{2,4}$/;
    var filter = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    //if it's valid email
    if (filter.test(Email_NotRememberPass.val())) {
        Email_NotRememberPass.removeClass("textboxerror");
        Email_NotRememberPassInfo.text("");
        Email_NotRememberPassInfo.removeClass("error");
        return true;
    }
    //if it's NOT valid
    else {
        Email_NotRememberPass.addClass("textboxerror");
        Email_NotRememberPassInfo.text("Email không đúng định dạng!");
        Email_NotRememberPassInfo.addClass("error");
        return false;
    }
}
function NotRememberPassClick() {
    if ($("#Email_NotRememberPassInfo").text().length <= 0) { 
        validateEmailNotRememberPass();
    }
    if ($("#Email_NotRememberPassInfo").text().length <= 0)
        return true;
    else
        return false;
}

////////////////////////////////////////////////////////////
// Goi Ajax NotRememberPass
///////////////////////////////////////////////////////////


function CallAjaxCheckEmailNotRememberPass() {
    var strurl = '';
    var strdata = '';
    // kiem tra email co tồn tại chưa
    if (validateEmailNotRememberPass()) {
        strurl = "../Process/AjaxProcess.aspx/CheckEmail";
        strdata = "{'email':'" + $("#txtEmail_NotRememberPass").val() + "'}";
        $.ajax({
            type: "POST",
            url: strurl,
            data: strdata,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus) {
                if (data != null && data.d != null && data.d == true) {
                    $("#Email_NotRememberPassInfo").text("");
                }
                else {
                    var Email_NotRememberPass = $("#txtEmail_NotRememberPass");
                    var Email_NotRememberPassInfo = $("#Email_NotRememberPassInfo");
                    Email_NotRememberPass.addClass("textboxerror");
                    Email_NotRememberPassInfo.text("Email này không tồn tại!");
                    Email_NotRememberPassInfo.addClass("error");

                }
            }

        });
        if ($("#Email_NotRememberPassInfo").text().length > 0) {
            return false;
        }
        else {
            return true;
        }
    }
    else {
        return false;
    }
}
//Send mail cho member
function CallAjaxNotRememberPass() {
    var strurl = '';
    var strdata = '';
    // nhấn nút đăng ký
    if (NotRememberPassClick()) {
        UserInSideClick('loading');
        strurl = "../Process/AjaxProcess.aspx/SendMail";
        strdata = "{'email':'" + $("#txtEmail_NotRememberPass").val() + "'}";
        $.ajax({
            type: "POST",
            url: strurl,
            data: strdata,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus) {
                if (data != null && data.d != null && data.d == true) {
                    $("#lbEmail_NotRememberPassNotice").text($("#txtEmail_NotRememberPass").val());
                    UserInSideClick('notrememberpassnotice');

                }
                else {
                    UserInSideClick('notrememberpass');
                    alert("Lỗi hệ thống, quay lại sau");
                }
            },
            error: function () {
                UserInSideClick('notrememberpass');
            }
        });
    }
    else {
        return false;
    }
}



////////////////////////////////////////////////////////////
// Check SignIn
///////////////////////////////////////////////////////////



// check Email
function validateUserNameSignIn() {
    var UserName_SignIn = $("#txtUserName_SignIn");
    var UserName_SignInInfo = $("#UserName_SignInInfo");
    //it's NOT valid
    if (UserName_SignIn.val().length < 1) {
        UserName_SignIn.addClass("textboxerror");
        UserName_SignInInfo.text("Bạn chưa nhập tên tài khoản!");
        UserName_SignInInfo.addClass("error");
        return false;
    }
    //if it's NOT valid
    else {
        UserName_SignIn.removeClass("textboxerror");
        UserName_SignInInfo.text("");
        UserName_SignInInfo.removeClass("error");
        return true;
    }
}
function validatePassSignIn() {
    var Password_SignIn = $("#txtPassword_SignIn");
    var Password_SignInInfo = $("#Password_SignInInfo");
    //it's NOT valid
    if (Password_SignIn.val().length < 6) {
        Password_SignIn.addClass("textboxerror");
        Password_SignInInfo.text("Mật khẩu phải > 5 ký tự!");
        Password_SignInInfo.addClass("error");
        return false;
    }
    //it's valid
    else {
        Password_SignIn.removeClass("textboxerror");
        Password_SignInInfo.text("");
        Password_SignInInfo.removeClass("error");
        return true;
    }
}
function SignInClick() {
    if (validateUserNameSignIn() & validatePassSignIn())
        return true;
    else
        return false;
}


////////////////////////////////////////////////////////////
// Goi Ajax SignIn
///////////////////////////////////////////////////////////

function CallAjaxSignIn() {
    var strurl = '';
    var strdata = '';
    // nhấn nút đăng nhập
    if (SignInClick()) {
        UserInSideClick('loading');
        strurl = "../Process/AjaxProcess.aspx/LoginUser";
        strdata = "{'username':'" + $("#txtUserName_SignIn").val() + "','password':'" + $("#txtPassword_SignIn").val() + "'}";
        $.ajax({
            type: "POST",
            url: strurl,
            data: strdata,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus) {
                if (data != null && data.d != null && data.d == true) {
                    $("#lbError_SignIn").text("");
                    window.location.reload();

                }
                else {
                    UserInSideClick('signin');
                    $("#lbError_SignIn").text("Tài khoản hoặc mật khẩu không đúng, bạn vui lòng thử lại!");
                }
            },
            error: function () {
                UserInSideClick('signin');
                $("#lbError_SignIn").text("Lỗi hệ thống, bạn vui lòng quay lại sau!");
            }
        });
    }
    else {
        return false;
    }
}


////////////////////////////////////////////////////////////
// Goi Ajax DangXuat
///////////////////////////////////////////////////////////

function CallAjaxSignOut() {
    var strurl = '';
    UserInSideClick('loading');
    strurl = "../Process/AjaxProcess.aspx/RemoveSession";
    $.ajax({
        type: "POST",
        url: strurl,
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, textStatus) {
            if (data != null && data.d != null && data.d == true) {
                window.location.reload();

            }

        },
        error: function () {
        }
    });
}
