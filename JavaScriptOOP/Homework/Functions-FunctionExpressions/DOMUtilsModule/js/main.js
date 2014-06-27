/*jslint browser: true*/
/*globals alert*/
window.onload = function () {
    'use strict';
    var domModule = (function domUtils() {
        var MAX_BUFFER_SIZE = 100,
            bufferCount,
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
            var parentDom = null,
                i = 0,
                len = 0,
                prop;

            internalBuffer[parentSelector] = internalBuffer[parentSelector] || [];
            bufferCount = bufferCount || 0;
            bufferCount += 1;
            internalBuffer[parentSelector].push(element);
            if (bufferCount >= MAX_BUFFER_SIZE) {
                for (prop in internalBuffer) {
                    if (internalBuffer.hasOwnProperty(prop)) {
                        parentDom = document.querySelector(prop);
                        for (i = 0, len = internalBuffer[prop].length; i < len; i += 1) {
                            parentDom.appendChild(internalBuffer[prop][i]);
                        }
                    }
                }

                internalBuffer = {};
                bufferCount = 0;
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
        window.setTimeout(function () {
            var i = 0,// Append to buffer test counter.
                div = document.createElement("div");

            domModule.removeChild('div.divs:first-child', '.spans');
            div.style.width = "5px";
            div.style.height = "4px";
            div.style.border = '3px solid green';
            domModule.appendChild(div, "#wrapper");

            domModule.addHandler("a.button", 'click',
                function () {
                    alert("Clicked");
                });

            domModule.appendToBuffer("#wrapper div:nth-child(2)", div.cloneNode(true));
            for (i = 0; i < 100; i += 1) {
                domModule.appendToBuffer("#wrapper", div.cloneNode(true));
            }
        }, 3000);
    }());
};