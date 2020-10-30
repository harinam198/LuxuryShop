$(document).ready(function() {
    $('#signin').on('click', function() {
        var userName = $('#Name').val();
        var password = $('#Pass').val();

        if (userName == 'lehainam' && password == '123') {
            $('#successToast').toast('show');
        } else {
            $('failedToast').toast('show');
        }
    })
});