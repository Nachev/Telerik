/*jslint browser: true*/
define(['jquery', 'handlebars'], function ($, Handlebars) {
    'use strict';
    var _objArray;

    function ComboBox(objArray) {
        _objArray = objArray;
        if (!(this instanceof ComboBox)) {
            return new ComboBox(objArray);
        }
    }

    ComboBox.prototype.render = function (template) {
        var createHtmlDropDown = (function createHtmlDropDown(template) {
            var $ul,
                $newLi,
                optionTemplate,
                obj;

            $ul = $('<ul>').addClass('drop-down-list-container');
            optionTemplate = Handlebars.compile(template);
            for (var i = 0, len = _objArray.length; i < len; i += 1) {
                obj = _objArray[i];
                $newLi = $('<li>')
                    .addClass('drop-down-list-option')
                    .attr('data-value', i)
                    .append(optionTemplate(obj))
                    .hide();
                if (!i) {
                    $newLi.show().addClass('selected');
                }
                $newLi.appendTo($ul);
            }

            $ul.css('display', 'inline-block')
                .css('border', '1px solid black')
                .css('cursor', 'pointer')
                .css('list-style', 'none')
                .css('margin', '10px')
                .css('padding', '10px');

            return $ul[0].outerHTML;
        }(template));

        var onClickToggleVisibility = function onClickToggleVisibility() {
            var $self = $(this);
            if ($self.hasClass('open')) {
                $self.children('li').filter(function () {
                    return !$(this).hasClass('selected');
                }).hide();

            } else {
                $self.children('li').filter(function () {
                    return !$(this).hasClass('selected');
                }).show();
            }
            $self.toggleClass('open');
        };

        var onClickHandleSelector = function onClickHandleSelector() {
            var $self = $(this),
                $parent = $self.parent();

            if ($parent.hasClass('open')) {
                // Manage selected class on the drop down options
                $parent.children('li').removeClass('selected');
                $self.addClass('selected');
            }
        };

        // Handle functions
        var $body = $('body'); // Body is the only element that exists in that moment.
        $body.on('click blur', 'ul.drop-down-list-container', onClickToggleVisibility);
        $body.on('click', 'li.drop-down-list-option', onClickHandleSelector);

        return createHtmlDropDown;
    };

    return {
        ComboBox: ComboBox
    };
});
