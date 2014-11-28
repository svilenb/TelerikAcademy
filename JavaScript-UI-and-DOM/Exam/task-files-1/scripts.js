function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector),
        ul = document.createElement('ul'),
        li = document.createElement('li'),
        h2 = document.createElement('h2'),
        img = document.createElement('img'),
        input = document.createElement('input'),
        largeImage = document.createElement('div'),
        paragraph = document.createElement('p'),
        imagesContainer = document.createElement('div'),
        i;

    largeImage.style.display = 'inline-block';
    largeImage.style.padding = '10px';

    container.style.border = '1px solid grey';
    container.style.width = '950px';
    container.style.height = '600px';
    container.style.display = 'inline-block';

    ul.id = 'images';
    ul.style.listStyleType = 'none';
    ul.style.height = '450px';
    ul.style.width = '300px';
    ul.style.textAlign = 'center';
    ul.style.padding = '2px';
    ul.style.float = 'right';
    ul.style.overflow = 'scroll';
    ul.style.display = 'inline-block';

    img.style.width = '150px';
    img.style.borderRadius = '15px';
    img.style.height = '150px';

    paragraph.style.textAlign = 'right';
    paragraph.style.paddingRight = '80px';
    input.type = 'text';

    function onMouseover() {
        this.style.background = 'grey';
    }

    function onMouseout() {
        this.style.background = '';
    }

    function enlargeImage(li) {
        var h2 = li.getElementsByTagName('h2')[0].cloneNode(true),
            img = li.getElementsByTagName('img')[0].cloneNode(true),
            i,
            len;

        for (i = 0, len = largeImage.childNodes.length; i < len; i += 1) {
            largeImage.removeChild(largeImage.childNodes[0]);
        }

        h2.style.fontSize = '40px';
        largeImage.appendChild(h2);
        img.style.width = '350px';
        img.style.height = '350px';
        largeImage.appendChild(img);
    }

    function onClick() {
        enlargeImage(this);
    }

    function filter() {
        var value,
            listItems;
        value = this.value.toLocaleLowerCase();
        listItems = document.getElementById('images').getElementsByTagName('li');
        if (value === '') {
            for (var i = 0; i < listItems.length; i++) {
                listItems[i].style.display = '';
            }
        } else {
            for (var i = 0; i < listItems.length; i++) {
                listItems[i].style.display = 'none';
            }

            for (var i = 0; i < listItems.length; i++) {
                if (listItems[i].innerText.toLocaleLowerCase().indexOf(value.toLowerCase()) !== -1) {
                    listItems[i].style.display = '';
                }
            }
        }
    }

    for (i = 0; i < items.length; i++) {
        var currentLi = li.cloneNode(true),
            currentH2 = h2.cloneNode(true),
            currentImg = img.cloneNode(true);

        currentImg.src = items[i].url;
        currentH2.innerHTML = items[i].title;
        currentLi.appendChild(currentH2);
        currentLi.appendChild(currentImg);
        currentLi.addEventListener('mouseover', onMouseover);
        currentLi.addEventListener('mouseout', onMouseout);
        currentLi.addEventListener('click', onClick);
        ul.appendChild(currentLi);

        if (i === 0) {
            enlargeImage(currentLi);
        }
    }

    input.addEventListener('keyup', filter);

    var documentFragment = document.createDocumentFragment();

    paragraph.appendChild(input);
    documentFragment.appendChild(paragraph);
    imagesContainer.appendChild(largeImage);
    imagesContainer.appendChild(ul);
    documentFragment.appendChild(imagesContainer);
    container.appendChild(documentFragment);
}