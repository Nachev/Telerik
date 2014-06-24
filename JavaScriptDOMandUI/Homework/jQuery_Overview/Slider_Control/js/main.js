/*jslint browser: true*/
jQuery(document).ready(function($) {
    var $this = $(this),
        $container = $this.find('#container'),
        $divChildren = null,
        i = 0,
        $currentElement = null,
        time = false;

    function changeShownElement(nextElementToShow) {
        $currentElement.hide();
        $currentElement = nextElementToShow;
        $currentElement.show();
    }

    function showNext() {
        var $nextElement = $currentElement.next();
        if ($nextElement.length <= 0) {
            $nextElement = $divChildren.first();
        }

        changeShownElement($nextElement);
    }

    function showPrevious() {
        var $previousElement = $currentElement.prev();
        if ($previousElement.length <= 0) {
            $previousElement = $divChildren.last();
        }

        changeShownElement($previousElement);
    }

    if ($container.length > 0) {
        $divChildren = $container.children();
    }

    // Hides all elements
    for (i = $divChildren.length - 1; i >= 0; i--) {
        $($divChildren[i]).hide();
    }

    $currentElement = $divChildren.first();
    $currentElement.show();

    $this.on('click', '#next', function(event) {
        event.preventDefault();
        showNext();
    });

    $this.on('click', '#previous', function(event) {
        event.preventDefault();
        showPrevious();
    });

    $this.on('click', '#slide', function(event) {
        event.preventDefault();
        if (time) {
            clearInterval(time);
            time = false;
        } else {
            time = setInterval(showNext, 5000);
        }
    });
});