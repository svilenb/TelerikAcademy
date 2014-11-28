(function () {
    var liTags = document.getElementById('the-tree').getElementsByTagName('li'),
        i;

    var onLiCLick = function (ev) {
        if (this.getElementsByTagName('ul')[0] === undefined) {
            return;
        }

        if (this === ev.target) {
            if (this.getElementsByTagName('ul')[0].style.display !== 'none') {
                this.getElementsByTagName('ul')[0].style.display = 'none';
            } else {
                this.getElementsByTagName('ul')[0].style.display = '';
            }
        }
    };

    function hideNestedUl(liItem) {
        var nestedUl = liItem.getElementsByTagName('ul')[0];

        if (nestedUl !== undefined) {
            nestedUl.style.display = 'none';
        }
    }

    for (i = 0; i < liTags.length; i += 1) {
        liTags[i].addEventListener('click', onLiCLick);
        hideNestedUl(liTags[i]);
    }
}());