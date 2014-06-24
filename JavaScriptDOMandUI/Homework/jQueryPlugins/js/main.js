/*jslint browser: true*/
(function($) {
    $.fn.dropdown = function() {
        var $this = $(this),
            $container = null,
            $ul = null,
            $currentOption = null,
            $newLi = null;

        // Check if the element is SelectedHTMLElement
        if (!$this.is('select')) {
            throw new Error('Dropdown works on <select> elements only');
        }

        function toggleDropdownVisibility() {
            if ($(this).hasClass('open')) {
                $(this).children('li').filter(function() {
                    return !$(this).hasClass('selected');
                }).hide();

            } else {
                $(this).children('li').filter(function() {
                    return !$(this).hasClass('selected');
                }).show();
            }
            $(this).toggleClass('open');
        }

        // Hide original element
        $this.hide();

        // Create dropdown elements
        $container = $('<div>').addClass('dropdown-list-container');
        $ul = $('<ul>').addClass('dropdown-list-options');
        $currentOption = $this.children('option').first();
        while ($currentOption.length > 0) {
            $newLi = $('<li>')
                .addClass('dropdown-list-option')
                .attr('data-value', $currentOption.val() - 1)
                .text($currentOption.text())
                .hide();
            if ($currentOption.is(':selected')) {
                $newLi.show().addClass('selected');
            }
            $newLi.appendTo($ul);
            $currentOption = $currentOption.next();
        }

        $ul.css('display', 'inline-block')
            .css('border', '1px solid black')
            .css('cursor', 'pointer')
            .appendTo($container);
        $container.appendTo($(this).parent());

        // Handle functions
        $ul.on('click blur', toggleDropdownVisibility);

        $ul.on('click', '.dropdown-list-option', function() {
            if ($ul.hasClass('open')) {
                // Manage selected class on the dropdown options
                $(this).parent().children('li').removeClass('selected');
                $(this).addClass('selected');
                // Manage selected attribute on the original select
                $this.find('option:selected').removeAttr('selected', '');
                $this.find('option[value=' + ($(this).data('value') + 1) + ']')
                    .attr('selected', 'selected');
            }
        });

        return $this;
    };
}(jQuery));

jQuery(document).ready(function($) {
    'use strict';
    $(this).find('#dropdown').dropdown();
});