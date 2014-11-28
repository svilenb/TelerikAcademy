(function ($) {
    $.fn.dropdown = function () {
        var $select = $(this),
            $parent = $select.parent(),
            $container = $('<div />').addClass('dropdonw-list-container'),
            $ul = $('<ul />').addClass('dropdown-list-options'),
            $options = $select.children(),
            i;

        function onLiClick() {
            var $this = $(this),
                value,
                selector;

            if ($this.hasClass('selected')) {
                $this.removeClass('selected');
                value = $this.attr('data-value');
                selector = 'option[value=\"' + value + '\"]';
                $select.find(selector).removeAttr('selected', 'selected');

            } else {
                $('.selected').removeClass('selected');
                $select.find("[selected]").removeAttr('selected', 'selected');
                $this.addClass('selected');
                value = $this.attr('data-value');
                selector = 'option[value=\"' + value + '\"]';
                $select.find(selector).attr('selected', 'selected');
            }
        }

        for (i = 0; i < $options.length; i += 1) {
            var $li = $('<li />')
                .addClass('dropdown-list-option')
                .attr('data-value', $($options[i]).attr('value'))
                .html($($options[i]).html())
                .on('click', onLiClick);
            $ul.append($li);
        }

        $container.append($ul);
        $parent.append($container);
        $select.css('display', 'none');

        return this;
    };
}(jQuery));