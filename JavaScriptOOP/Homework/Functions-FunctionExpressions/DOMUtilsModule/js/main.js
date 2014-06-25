/*jslint browser: true*/
/*globals alert*/
window.onload = function () {
    'use strict';
    var domModule = (function domUtils() {
        var MAX_BUFFER_SIZE = 100,
            internalBuffer = {};

        function appendElementTo(elementToAppend, parentSelector) {
            var parentDom = document.querySelector(parentSelector);

            parentDom.appendChild(elementToAppend);
        }

        function removeElement(parentSelector, elementSelector) {
            var parentDom = document.querySelector(parentSelector),
                elementDom = parentDom.querySelectorAll(elementSelector),
                i = 0;

            for (i = elementDom.length - 1; i >= 0; i -= 1) {
                parentDom.removeChild(elementDom[i]);
            }
        }

        function addHandler(elementSelector, eventType, eventHandler) {
            var elementDom = document.querySelectorAll(elementSelector),
                i = 0;

            for (i = elementDom.length - 1; i >= 0; i -= 1) {
                elementDom[i].addEventListener(eventType, eventHandler, false);
            }
        }

        function appendToBuffer(parentSelector, element) {
            var parentDom = document.querySelector(parentSelector),
                i = 0,
                len = 0;

            if (!internalBuffer[parentSelector]) {
                internalBuffer[parentSelector] = [];
            }

            internalBuffer[parentSelector].push(element);
            if (internalBuffer[parentSelector].length >= MAX_BUFFER_SIZE) {
                for (i = 0, len = internalBuffer[parentSelector].length; i < len; i += 1) {
                    parentDom.appendChild(internalBuffer[parentSelector][i]);
                }

                internalBuffer[parentSelector] = null;
            }
        }

        return {
            appendChild: appendElementTo,
            removeChild: removeElement,
            addHandler: addHandler,
            appendToBuffer: appendToBuffer
        };
    }());

    (function testFunction() {
        /*
         var div = document.createElement("div");
         //appends div to #wrapper
         domModule.appendChild(div,"#wrapper");
         //removes li:first-child from ul
         domModule.removeChild("ul","li:first-child");
         //add handler to each a element with class button
         domModule.addHandler("a.button", 'click',
         function(){alert("Clicked")});
         domModule.appendToBuffer("container", div.cloneNode(true));
         domModule.appendToBuffer("#main-nav ul", navItem);
         */
        window.setTimeout(function () {
            domModule.removeChild('div.divs:first-child', '.spans');

            var i = 0,// Append to buffer test counter.
                div = document.createElement("div");
            div.style.width = "5px";
            div.style.height = "4px";
            div.style.border = '3px solid green';
            domModule.appendChild(div, "#wrapper");

            domModule.addHandler("a.button", 'click',
                function () {
                    alert("Clicked");
                });

            for (i = 0; i < 100; i += 1) {
                domModule.appendToBuffer("#wrapper", div.cloneNode(true));
            }
        }, 3000);
    }());
};