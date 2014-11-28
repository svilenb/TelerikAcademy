(function () {
    var paper = Raphael(10, 10, 600, 300),
        rect,
        tube,
        you;

    you = paper.text(180, 100, "You");
    you.scale(0.6, 1);
    you.attr({
        "font-weight": "bold",
        "font-size": 150,
        "font-family": "Calibri, Consolas, Arial",
        fill: "#4A4A4A"
    });

    rect = paper.rect(255, 40, 210, 130, 25);
    rect.attr({
        stroke: "none",
        fill: "#EC262A"
    });

    tube = paper.text(360, 100, "Tube");
    tube.scale(0.6, 1);
    tube.attr({
        "font-weight": "bold",
        "font-size": 150,
        "font-family": "Calibri, Consolas, Arial",
        fill: "white"
    });
}());