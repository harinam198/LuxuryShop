var header = document.getElementById("myDIV");
var btns = header.getElementsByClassName("size");
for (var i = 0; i < btns.length; i++) {
    btns[i].addEventListener("click", function() {
        var current = document.getElementsByClassName("click-size");
        current[0].className = current[0].className.replace(" click-size", "");
    this.className += " click-size";
});
}



$(document).ready(function() {
    $('.num-in span').click(function () {
    var $input = $(this).parents('.num-block').find('input.in-num');
    if($(this).hasClass('minus')) {
        var count = parseFloat($input.val()) - 1;
        count = count < 1 ? 1 : count;
            if (count < 2) {
                $(this).addClass('dis');
            }
            else {
                $(this).removeClass('dis');
            }
        $input.val(count);
    }
    else {
        var count = parseFloat($input.val()) + 1
        $input.val(count);
    if (count > 1) {
        $(this).parents('.num-block').find(('.minus')).removeClass('dis');
    }
}

$input.change();
return false;
});
});

//cmt
$(document).ready(function(){
    $(".reply-popup").click(function(){
      $(".reply-box").toggle();
    });
  });