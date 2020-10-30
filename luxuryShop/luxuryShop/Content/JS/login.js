$(document).ready(function() {
    $('#signin').on('click', function() {
        var userName = $('#Name').val();
        var password = $('#Pass').val();

        if (userName == 'lehainam' && password == '123' || userName == 'phamvanmanh' && password == '456') {
            $('#successToastSignin').toast('show');
        } else {
            $('#failedToastSignin').toast('show');
        }
    })

    $('#icon-click').click(function() {
        // $('#eye').css("color", "#5887ef");
        var input = $('#Pass');
        if (input.attr("type") === "password") {
            input.attr("type", "text");
            $('#eye').toggleClass('fa-eye-slash');
        } else {
            input.attr("type", "password");
            // $('#eye').css("color", "#7a797e");
            $('#eye').toggleClass('fas fa-eye');
        }
    })

    $('#Name, #Pass').keyup(function(e) {
        if (e.keyCode === 13) {
            $('#signin').click();
        }
    })
});

$(document).ready(function() {

    $('#Register').on('click', function() {

        var email = $('#myEmail').val();
        var userName = $('#username').val();
        var password = $('#myPassword').val();
        var ConfirmPasss = $('#confirmPass').val();

        check();

    })
    $('#myEmail, #username, #myPassword, #confirmPass').keyup(function(e) {
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
    var userName = $('#username').val();
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






// $(function() {
//     $('input[name="myEmail"]' && 'input[name="username"]' && 'input[name="myPassword"]' && 'input[name="confirmPass"]').change(function() {
//         if ($(this).val()) {
//             $("#Register").prop("type", "submit");
//         }
//     })
// })

// var CORRECT_USER ='lehainam';
// var CORRECT_PASS = 'hainam';

// var inputemail = document.getElementById('myEmail');
// var inputpass = document.getElementById('myPassword');

// var fromLogin = document.getElementById('form-login');

// if(fromLogin.attachEvent){
//   fromLogin.attachEvent('submit', onFormSubmit);
// }else{
//   fromLogin.addEventListener('submit', onFormSubmit);
// }

// function check(e){
//   var username = inputemail.value;
//   var password = inputpass.value;

//   if (username == CORRECT_USER && password == CORRECT_PASS)
//   {
//     alert('Đăng nhập thành công');
//   }else {
//     alert('Đăng nhập fail');
//   }

// function testOnKeyUp(e) {
//   var newValue = e.target.value;
//   if (newValue.length < 6) {
//     console.log('Invalid input. String must have at least 6 characters');
//   } else {
//     console.log('Input valid');
//   }
// }

// function login(e){
//    var email= document.getElementById(Email).value;
//    var pass= document.getElementById(Password).value;

//    if(email===""){
//        console.log("Bạn chưa nhập email");
//    }
//    if (pass===""){
//        console.log("Bạn chưa nhập password")
//    }
//    if (pass.length<6){
//        console.log("Mật khẩu phải có ít nhất 6 ký tự trở lên");
//    }
// }

// function check(form) {
//     if (form.Email.value == "nam@gmail.com" && form.Password.value == "123") {
//         $('#successToast').toast('show');
//     } else {
//         $('#failedToast').toast('show');
//     }
// }

// $('#failedToast').toast({
// 	delay:5000,
// });
// $('#signUp').modal({
//     backdrop: false,
//     show: false
// });
//     $('#myEmail').keyup(function() {
//         // check it work or not
//         $('#email').keyup(function(){
//             alert();
//         });
//         if (validateEmail()) {
//             //nếu email hợp lệ
//             $('#email').css('border', '2px solid green');
//         } else {
//             $('#email').css('border', '2px solid red');
//         }
//     });
// });

// function validateEmail() {
//     var email = $('#myEmail').val();
//     // use reular experession
//     var reg = /^\w+([-+.']\w+)*@\w([-.]\w+)*\.\w+([-.]\w+)*$/
//     if (reg.test(email)) {
//         return true;
//     } else {
//         return false;
//     }
// }


// var email = document.getElementById('myEmail');
// var filter = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/
// if (!filter.test(email.value)) {
//     alert('Cú pháp không hợp lệ. \nExample@gmail.com')
//     email.focus;
//     return false;
// }

// $('#formRegister').validate({
//     rules: {
//         userName: "required",
//         myPassword: "required",
//         confirmPass: "required",
//         myEmail: {
//             required: true,
//             email: true,
//             maxlength: 225,
//         }
//     },
//     message: {
//         myEmail: "Nhập đúng định dạng email"
//     }
// })

// $('#myEmail').on('keydown', function(validate) {
//     var form = $('#formRegister').val();
//     var email = $('#myEmail').val();
//     var text = $('#text').val();
//     var pattern = /^[^ ]+@[^ ]+\.[a-z]{2,3}$/;
//     if (email.match(pattern)) {
//         form.classList.add('valid')
//         form.classList.remove('invalid')
//     } else {
//         form.classList.remove('valid')
//         form.classList.add('invalid')
//     }
// })