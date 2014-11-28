/// <reference path="../libs/jquery-2.1.1.min.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/handlebars-v1.3.0.js" />
define(['jquery', 'handlebars'], function ($, hb) {
    var ComboBox = (function () {
        var ComboBox = function (items) {
            this.items = items;
        };

        ComboBox.prototype.render = function (template) {
            var $resultHTML,
                postTemplate = Handlebars.compile(template),
                colapsed,
                i;

            $resultHTML = $('<div />');

            for (i = 0; i < this.items.length; i++) {
                var animal = postTemplate(this.items[i]);
                $(animal).appendTo($resultHTML);
            }

            $resultHTML.children().first().addClass('selected');
            $resultHTML.children().hide();
            $resultHTML.find('.selected').css('display', 'block');

            colapsed = true;
            $resultHTML.on('click', '.animal-item', function () {
                if (colapsed) {
                    $resultHTML.children().show();
                    colapsed = false;
                }
                else {
                    $resultHTML.children().hide();
                    $resultHTML.find('.selected').removeClass('selected');
                    $(this).addClass('selected').css('display', 'block');
                    colapsed = true;
                }
            });

            return $resultHTML;
        };

        return ComboBox;
    }());

    return {
        ComboBox: ComboBox
    };
});