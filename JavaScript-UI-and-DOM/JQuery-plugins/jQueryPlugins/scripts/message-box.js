(function ($) {
    $.fn.messageBox = function () {
        var $this = $(this);

        return {
            success: function (message) {
                $this.css('background-color', 'yellowgreen');
                $this.css('color', 'white');
                $this.css('opacity', 0);
                $this.html(message);
                $this.animate({ 'opacity': 1 }, 1000, function () {
                    $this.animate({ 'opacity': 0 }, 3000);
                });

                return $this;
            },

            error: function (message) {
                $this.css('background-color', 'red');
                $this.css('color', 'white');
                $this.css('opacity', 0);
                $this.html(message);
                $this.animate({ 'opacity': 1 }, 1000, function () {
                    $this.animate({ 'opacity': 0 }, 3000);
                });

                return $this;
            }
        };
    };

    var successButton = $('#success'),
        errorButton = $('#error'),
        messageBox = $('#message-box').messageBox();

    successButton.on('click', function () {
        messageBox.success('Success message');
    });

    errorButton.on('click', function () {
        messageBox.error('Error message');
    });
}(jQuery));