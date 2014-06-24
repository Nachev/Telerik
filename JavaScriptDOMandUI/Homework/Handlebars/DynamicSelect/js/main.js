/*jslint browser: true*/
window.onload = function() {
    var items = [{
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
    }];

    var templateSource = document.getElementById('post-template').innerHTML;
    var template = Handlebars.compile(templateSource);

    var selectOptionsHtml = template({
        items: items
    });

    var container = document.getElementById('container');
    container.innerHTML += selectOptionsHtml;
};