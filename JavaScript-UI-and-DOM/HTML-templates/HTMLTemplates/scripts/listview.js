(function ($) {
    $.fn.listview = function (items) {

        var $this = $(this),
            templateID = $this.attr('data-template'),
            templateHTML = $('#' + templateID).html(),
            template = Handlebars.compile(templateHTML);

        $this.append(template(items));
    };

    var books = [
            { id: 1, title: 'JavaScript: The good parts' },
            { id: 2, title: 'Secrets of the JavaScript Ninja' },
            { id: 3, title: 'Core HTML5 Canvas: Graphics, Animation, and Game Development' },
            { id: 4, title: 'JavaScript Patterns' },
    ],
    students = [
        { name: 'Petar Petrov', mark: 5.5, number: 1 },
        { name: 'Stamat Georgiev', mark: 4.7, number: 2 },
        { name: 'Maria Todorova', mark: 6, number: 3 },
        { name: 'Georgi Geshov', mark: 3.7, number: 4 },
    ];

    $('#books-list').listview({ books: books });
    $('#students-table').listview({ students: students });
}(jQuery));