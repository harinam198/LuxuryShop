$(document).ready(function() {

    $('#Register').on('click', function() {

        var email = $('#myEmail').val();
        var userName = $('#userName').val();
        var password = $('#myPassword').val();
        var ConfirmPasss = $('#confirmPass').val();

        check();

    })
    $('#myEmail, #userName, #myPassword, #confirmPass').keyup(function(e) {
        if (e.keyCode === 13) {
            $('#Register').click();
        }
    })
});

function validateEmail() {
    var email = $('#myEmail').val();
    var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
    if (reg.test(email)) {
        return true;
    } else {
        return false;
    }
}

function validateUserNam() {
    var userName = $('#userName').val();
    if (userName.length > 5 && userName.length < 50) {
        return true;
    } else {
        return false;
    }
}

function validatePass() {
    var password = $('#myPassword').val();
    if (password.length > 5) {
        return true;
    } else {
        return false;
    }
    console.log(password);
}

function validateConfirmPass() {
    var password = $('#myPassword').val();
    var confirmPass = $('#confirmPass').val();
    if (confirmPass === password) {
        return true;
    } else {
        return false;
    }
}

function check() {
    if (validateEmail() && validateUserNam() && validatePass() && validateConfirmPass()) {
        $('#successToast').toast('show');
        $('#register').modal('hide');
    } else {
        $('#failedToast').toast('show');
    }
}

$('#icon-click-1').click(function() {
    // $('#eye').css("color", "#5887ef");
    var input = $('#myPassword');
    if (input.attr("type") === "password") {
        input.attr("type", "text");
        $('#eye').toggleClass('fa-eye-slash');
    } else {
        input.attr("type", "password");
        // $('#eye').css("color", "#7a797e");
        $('#eye').toggleClass('fas fa-eye');
    }
})

$('#icon-click-2').click(function() {
    // $('#eye').css("color", "#5887ef");
    var input = $('#confirmPass');
    if (input.attr("type") === "password") {
        input.attr("type", "text");
        $('#eye1').toggleClass('fa-eye-slash');
    } else {
        input.attr("type", "password");
        // $('#eye').css("color", "#7a797e");
        $('#eye1').toggleClass('fas fa-eye');
    }
})