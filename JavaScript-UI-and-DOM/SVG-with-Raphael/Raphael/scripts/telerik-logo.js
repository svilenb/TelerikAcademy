(function () {
    var paper = new Raphael(10, 10, 600, 300),
        name,
        slogan,
        logo;

    name = paper.text(350, 100, "Telerik®");
    name.attr({
        "font-weight": "bold",
        "font-size": 100,
        "font-family": "Calibri, Consolas, Arial"
    });

    slogan = paper.text(390, 160, "Develop experiences");
    slogan.attr({
        "font-weight": "lighter",
        "font-size": 45,
        "font-family": "Calibri, Consolas, Arial"
    });

    logo = paper.path("M40 80 L75 50 L127 120 L100 152 L70 120 L125 50 L160 80")
    logo.attr({
        "stroke-width": 20,
        stroke: "#5CE600"
    });
}());