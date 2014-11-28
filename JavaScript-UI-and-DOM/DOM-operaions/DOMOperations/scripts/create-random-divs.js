function generateRandomColor() {
    var red = (Math.random() * 256) | 0,
        green = (Math.random() * 256) | 0,
        blue = (Math.random() * 256) | 0,
        alpha = (Math.random() * 256 | 0);

    return "rgba(" + red + "," + green + "," + blue + "," + alpha + ")";
}

function generateRandomDiv() {
    var div = document.createElement("div");
    div.style.textAlign = "center";

    var strong = document.createElement("strong");
    strong.innerHTML = "div";
    div.appendChild(strong);
    div.style.width = Math.floor(Math.random() * 81 + 20) + "px";
    div.style.height = Math.floor(Math.random() * 81 + 20) + "px";
    div.style.backgroundColor = generateRandomColor();
    div.style.color = generateRandomColor();
    div.style.borderStyle = "solid";
    div.style.borderRadius = Math.floor(Math.random() * 21 + 1) + "px";
    div.style.borderColor = generateRandomColor();
    div.style.borderWidth = Math.floor(Math.random() * 21 + 1) + "px";
    div.style.position = "absolute";
    div.style.top = Math.floor(Math.random() * 801) + "px";
    div.style.left = Math.floor(Math.random() * 901) + "px";

    return div;
}

function generateDivs() {
    var documentFragment = document.createDocumentFragment(),
        i,
        currentDiv;

    for (i = 0; i < 10; i += 1) {
        currentDiv = generateRandomDiv();
        documentFragment.appendChild(currentDiv);
    }

    document.body.appendChild(documentFragment);
}

(function () {
    var button = document.getElementById('the-button');

    button.addEventListener('click', generateDivs);
}());