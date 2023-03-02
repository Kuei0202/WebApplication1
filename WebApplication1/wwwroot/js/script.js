
$(function () {
    $('#button').submit(function () { $('#incident').val(''); });
    $('#days').each(function () {
        $(this).on('click', 'td', function () {
            alert($(this).text());
        });
    }
    );
    
});
