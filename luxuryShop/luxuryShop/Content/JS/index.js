/*появление через время после захода на страницу
  setTimeout(function(){
    $('#rc-phone-form').animate({width:'605%'}).removeClass('closed');
    $('#rc-phone-form-close').removeClass('closed');
  }, 11000);
*/

$(document).ready(function() {
    $('#rc-phone-icon').click(function() {
        if ($(this).hasClass('fa-times')) {
            $(this).removeClass('fa-times');
            $(this).addClass('fa-phone');
            $('#rc-phone-form').animate({ width: '50px' });
            setTimeout(function() { $('#rc-phone-form').addClass('closed'); }, 600);
        }
    });
    $('#rc-phone-form').click(function() {
        if ($(this).hasClass('closed')) {
            $('#rc-phone-icon').removeClass('fa-phone');
            $('#rc-phone-icon').addClass('fa-times');
            $('#rc-phone-form').animate({ width: '605%' }).removeClass('closed');
            setTimeout(function() { $('#rc-phone-form').addClass('opened'); }, 600);
        }
    });
});