(function myfunction($) {
    var $li = $('<li />'),
        $lis = $('li'),
        $beforeButton = $('#before'),
        $afterButton = $('#after');

    $li.html('The inserted item');

    function makeSelected() {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
    }

    var i;
    for (i = 0; i < $lis.length; i += 1) {
        $($lis[i]).on('click', makeSelected);
    }

    $beforeButton.on('click', function () {
        $li.clone().insertBefore($('.selected'));
    });

    $afterButton.on('click', function () {
        $li.clone().insertAfter($('.selected'));
    });
}(jQuery));