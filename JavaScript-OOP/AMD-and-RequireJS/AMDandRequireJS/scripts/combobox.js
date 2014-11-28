/// <reference path="../libs/jquery-2.1.1.min.js" />
/// <reference path="../libs/require.js" />
(function () {
    require.config({
        paths: {
            "jquery": "../libs/jquery-2.1.1.min",
            "handlebars": "../libs/handlebars-v1.3.0",
            "items": "items"
        }
    });

    require(['jquery', 'controls', 'items'], function ($, controls, animals) {
        var comboBox = new controls.ComboBox(animals),
            template = $("#animal-template").html(),
            $comboBoxHtml = comboBox.render(template);
        $comboBoxHtml.appendTo($('#container'));
    });
}());