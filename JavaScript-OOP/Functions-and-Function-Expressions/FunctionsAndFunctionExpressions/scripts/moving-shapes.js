var movingShapes = (function () {
    var self,
        div = document.createElement('div'),
        divs = [],
        centerX = 650,
        centerY = 300,
        radius = 200,
        maxTop = 500,
        maxLeft = 900,
        minTop = 100,
        minLeft = 400;

    div.innerHTML = 'div';
    div.style.width = '40px';
    div.style.height = '40px';
    div.style.borderWidth = '1px';
    div.style.borderStyle = 'solid';
    div.style.textAlign = 'center';
    div.style.display = 'inline-block';
    div.style.position = 'absolute';
    div.style.top = "300px";
    div.style.left = "850px";

    function getRandomColor() {
        var red = Math.floor(Math.random() * 256);
        var green = Math.floor(Math.random() * 256);
        var blue = Math.floor(Math.random() * 256);

        return 'rgb(' + red + ',' + green + ',' + blue + ')';
    }

    function createDiv() {
        var result = div.cloneNode(true);
        result.style.borderColor = getRandomColor();
        result.style.font = getRandomColor();
        result.style.backgroundColor = getRandomColor();

        return result;
    }

    function addCircularDiv() {
        var divToAdd = createDiv();
        divToAdd.classList.add('ellipse');
        divToAdd.setAttribute('data-angle', '0');
        divs.push(divToAdd);
        document.getElementById('container').appendChild(divToAdd);
    }

    function addRectangularDiv() {
        var divToAdd = createDiv();
        divToAdd.classList.add('rect');
        divToAdd.setAttribute('data-direction', 'up');
        divs.push(divToAdd);
        document.getElementById('container').appendChild(divToAdd);
    }

    function move(divToMOve) {
        if (divToMOve.classList.contains('ellipse')) {
            var x,
                y,
                angle = parseInt(divToMOve.getAttribute('data-angle'), 10);

            x = Math.cos(angle) * radius;
            y = Math.sin(angle) * radius;
            divToMOve.style.top = (centerY - y) + "px";
            divToMOve.style.left = (centerX + x) + "px";
            divToMOve.setAttribute('data-angle', (angle + 1).toString());
        } else if (divToMOve.classList.contains('rect')) {
            var direction = divToMOve.getAttribute('data-direction'),
                top = parseInt(divToMOve.style.top, 10),
                left = parseInt(divToMOve.style.left, 10);

            if (direction === 'up') {
                top -= 20;
            } else if (direction === 'left') {
                left -= 20;
            } else if (direction === 'down') {
                top += 20;
            } else if (direction === 'right') {
                left += 20;
            }

            divToMOve.style.top = top + 'px';
            divToMOve.style.left = left + 'px';

            if (direction === 'up' && top <= minTop) {
                divToMOve.setAttribute('data-direction', 'left');
            } else if (direction === 'left' && left <= minLeft) {
                divToMOve.setAttribute('data-direction', 'down');
            } else if (direction === 'down' && top >= maxTop) {
                divToMOve.setAttribute('data-direction', 'right');
            } else if (direction === 'right' && left >= maxLeft) {
                divToMOve.setAttribute('data-direction', 'up');
            }
        }
    }

    function moveDivs() {
        var i;
        for (i = 0; i < divs.length; i += 1) {
            move(divs[i]);
        }
    }

    window.setInterval(moveDivs, 150);

    self = {
        add: function (movement) {
            if (movement === 'ellipse') {
                addCircularDiv();
            } else if (movement === 'rect') {
                addRectangularDiv();
            }
        }
    };

    return self;
}());
