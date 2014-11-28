(function () {
    var fontColor = document.getElementById('font-color'),
        backgroundColor = document.getElementById('background-color'),
        textarea = document.getElementsByTagName('textarea')[0];

    function changeFontColor() {
        textarea.style.color = fontColor.value;
    }

    function changeBackgroundColor() {
        textarea.style.backgroundColor = backgroundColor.value;
    }

    //fontColor.onchange = changeFontColor;
    //backgroundColor.onchange = changeBackgroundColor;
    fontColor.addEventListener('change', changeFontColor);
    backgroundColor.addEventListener('change', changeBackgroundColor);
}());