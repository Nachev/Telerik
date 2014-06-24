/*jslint browser: true*/
jQuery(document).ready(function() {
    'use strict';
    var $this = $(this);

    $('input[type=color]').on('change', function() {
        $this.find('body').css('background-color', this.value);
    });
});