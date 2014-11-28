(function () {
    var currentSlide = 0,
        $prevButton = $($('#previous')[0]),
        $nextButton = $($('#next')[0]),
        $slides = $('.slide');

    function changeSlide(slideNumber) {
        $slides.removeClass('visible');
        var currentSlideName = 'slide-' + slideNumber;
        $('#' + currentSlideName).addClass('visible');
    }

    function onPreviousButtonClick() {
        if (currentSlide > 0) {
            currentSlide -= 1;
        } else {
            currentSlide = $slides.length - 1;
        }
        changeSlide(currentSlide);
    }

    function onNextButtonClick() {
        currentSlide = (currentSlide + 1) % $slides.length;
        changeSlide(currentSlide);
    }

    $prevButton.on('click', onPreviousButtonClick);
    $nextButton.on('click', onNextButtonClick);

    window.setInterval(function () {
        currentSlide = (currentSlide + 1) % $slides.length;
        changeSlide(currentSlide);
    }, 5000);
}());