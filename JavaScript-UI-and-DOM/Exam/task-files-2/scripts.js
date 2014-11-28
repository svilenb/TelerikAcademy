$.fn.gallery = function (cols) {
    var $gallery = $(this),
        $galleryList = $($gallery.find('.gallery-list')[0]),
        $selected = $gallery.find('.selected');

    cols = cols || 4;
    $gallery.addClass('gallery');
    $galleryList.css('width', cols * 260 + 'px');

    $selected.children().remove();

    var $images = $gallery.find('.image-container'),
        i;

    function onImageClick() {
        var $this = $(this),
            $prev,
            $next;

        if ($this.prev().length !== 0) {
            $prev = $this.prev();
        } else {
            $prev = $($images[$images.length - 1]);
        }

        if ($this.next().length !== 0) {
            $next = $this.next();
        } else {
            $next = $($images[0]);
        }

        var $currentContainer = $('<div />').addClass('current-image'),
            $previousContainer = $('<div />').addClass('previous-image'),
            $nextContainer = $('<div />').addClass('next-image'),
            $prevImage = $('<img />'),
            $currentImage = $('<img />'),
            $nextImage = $('<img />');

        $prevImage.attr('id', 'previous-image');
        $prevImage.attr('src', $prev.find('img').attr('src'));
        $currentImage.attr('id', 'current-image');
        $currentImage.attr('src', $this.find('img').attr('src'));
        $nextImage.attr('id', 'next-image');
        $nextImage.attr('src', $next.find('img').attr('src'));

        $previousContainer.append($prevImage);
        $currentContainer.append($currentImage);
        $nextContainer.append($nextImage);

        $selected.append($previousContainer);
        $selected.append($currentContainer);
        $selected.append($nextContainer);

        $galleryList.addClass('blurred');
        $galleryList.addClass('disabled-background ');
        makeBackgroundDisabled();

        $currentContainer.on('click', function () {
            $galleryList.removeClass('blurred');
            $galleryList.removeClass('disabled-background ');
            makeBackgroundEnabled();
            $selected.children().remove();
        });

        $previousContainer.on('click', function () {
            $nextImage.attr('src', $this.find('img').attr('src'))
            $currentImage.attr('src', $prev.find('img').attr('src'));

            if ($prev.prev().length !== 0) {
                $prevImage.attr('src', $prev.prev().find('img').attr('src'));
            } else {
                $prevImage.attr('src', $($images[$images.length - 1]).find('img').attr('src'));
            }

            $next = $this;
            $this = $prev;

            if ($prev.prev().length !== 0) {
                $prev = $prev.prev();
            } else {
                $prev = $($images[$images.length - 1]);
            }
        });

        $nextContainer.on('click', function () {
            $prevImage.attr('src', $this.find('img').attr('src'));
            $currentImage.attr('src', $next.find('img').attr('src'));

            if ($next.next().length !== 0) {
                $nextImage.attr('src', $next.next().find('img').attr('src'));
            } else {
                $nextImage.attr('src', $($images[0]).find('img').attr('src'));
            }

            $prev = $this;
            $this = $next;

            if ($next.next().length !== 0) {
                $next = $next.next();
            } else {
                $next = $($images[0]);
            }
        });
    }

    function makeBackgroundDisabled() {
        for (i = 0; i < $images.length; i++) {
            $($images[i]).off('click', onImageClick);
        }
    }

    function makeBackgroundEnabled() {
        for (i = 0; i < $images.length; i++) {
            $($images[i]).on('click', onImageClick);
        }
    }

    makeBackgroundEnabled();
};