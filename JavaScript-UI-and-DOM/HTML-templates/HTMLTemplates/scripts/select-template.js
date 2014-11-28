(function () {
    var options = [{
        value: 1,
        text: 'One'
    }, {
        value: 2,
        text: 'Two'
    }, {
        value: 3,
        text: 'Three'
    }, {
        value: 4,
        text: 'Four'
    }, {
        value: 5,
        text: 'Five'
    }, {
        value: 6,
        text: 'Six'
    }];

    var selectTemplateHTML = document.getElementById('select-template').innerHTML,
        selectTemplate = Handlebars.compile(selectTemplateHTML);

    document.getElementById('root').innerHTML += selectTemplate({ options: options });
}());