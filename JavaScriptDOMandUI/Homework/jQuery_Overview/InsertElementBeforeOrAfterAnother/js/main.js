/*jslint browser: true*/
jQuery(document).ready(function() {
    var $this = $(this);

    function insertBefore(sibling, insertedElement) {
        $(sibling).prepend($(insertedElement));
    }

    function insertAfter(sibling, insertedElement) {
        $(sibling).append($(insertedElement));
    }

    function insertElementTest() {
        var $wrapper = $this.find('#wrapper'),
            $newElement = null;

        $newElement = $('<div>').text('lorem ipsum inserted before');
        insertBefore($wrapper, $newElement);

        $newElement = $('<div>').text('lorem ipsum inserted after');
        insertAfter($wrapper, $newElement);
    }

    $this.on('click', '#test', insertElementTest);
});