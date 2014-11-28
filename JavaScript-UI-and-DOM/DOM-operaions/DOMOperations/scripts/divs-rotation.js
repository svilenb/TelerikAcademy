(function () {
    var startButton = document.getElementById('start'),
        stopButton = document.getElementById('stop'),
        divs = [],
        angle,
        i,
        divsCount = 5,
        documentFragment = document.createDocumentFragment(),
        currentDiv,
        centerX = 650,
        centerY = 300,
        radius = 200,
        y,
        x,
        intervalID;

    for (i = 0; i < divsCount; i += 1) {
        angle = i * 2 * Math.PI / divsCount;
        x = Math.cos(angle) * radius;
        y = Math.sin(angle) * radius;
        currentDiv = document.createElement('div');
        currentDiv.style.display = 'inline-block';
        currentDiv.style.position = 'absolute';
        currentDiv.style.background = 'red';
        currentDiv.style.font = 'white';
        currentDiv.innerHTML = 'div';
        currentDiv.style.top = (centerY - y) + "px";
        currentDiv.style.left = (centerX + x) + "px";
        documentFragment.appendChild(currentDiv);
        divs.push({
            div: currentDiv,
            angle: angle
        });
    }

    document.getElementById('container').appendChild(documentFragment);

    function rotate() {
        var i,
           x,
           y,
           angle;

        for (i in divs) {
            divs[i].angle += 1;
            angle = divs[i].angle;
            x = Math.cos(angle) * radius;
            y = Math.sin(angle) * radius;
            divs[i].div.style.top = (centerY - y) + "px";
            divs[i].div.style.left = (centerX + x) + "px";
        }
    }

    function startRotation() {
        intervalID = window.setInterval(rotate, 100);
    }

    function stopRotation() {
        window.clearInterval(intervalID);
    }


    startButton.addEventListener('click', startRotation);
    stopButton.addEventListener('click', stopRotation);
}());