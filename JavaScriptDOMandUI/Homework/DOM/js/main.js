/*jslint browser: true*/
window.onload = function () {
    (function divSelectors() {
        /*Write a script that selects all the div nodes that are 
        directly inside other div elements*/
        function divSelectorQuery() {
            /*Create a function using querySelectorAll()*/
            var selectedDivs = document.querySelectorAll('div>div'),
                i = 0,
                j = 0,
                len = selectedDivs.length;

            function markBorder(item) {
                item.style.border = '1px dotted red';
            }

            function unmarkBorder(item) {
                item.style.border = '1px solid purple';
            }

            function divMarker() {
                var currentDiv = selectedDivs[i];
                i += 1;

                markBorder(currentDiv);
                setTimeout(divUnmarker, 1000);
            }

            function divUnmarker() {
                var currentDiv = selectedDivs[j];
                j += 1;

                unmarkBorder(currentDiv);
                if (j < len) {
                    setTimeout(divMarker, 1000);
                }
            }

            divMarker();
        }

        function divSelectorByTag() {
            /*Create a function using getElementsByTagName()*/
            var selected = document.getElementsByTagName('div'),
                i,
                len;

            for (i = 1, len = selected.length; i < len; i += 1) {
                console.log(selected[i]);
            }
        }

        divSelectorQuery();
        divSelectorByTag();
    }());

    (function getValue() {
        /*Create a function that gets the value of <input 
        type="text"> ands prints its value to the console*/
        var input = document.querySelector('input[type=text]'),
            button = document.getElementById('take-button'),
            result = document.getElementById('display'),
            inputValue;

        function setValue() {
            inputValue = input.value;
            result.innerText = inputValue;
            console.log(inputValue);
        }

        button.addEventListener('click', setValue, false);
    }());

    (function () {
        /*Crеate a function that gets the value of <input
        type="color"> and sets the background of the body
        to this value*/
        var input = document.querySelector('input[type="color"]');

        input.value = '#ffffff'; // Sets default value to white;

        function changeBackGround() {
            document.body.style.backgroundColor = input.value;
        }

        input.addEventListener('input', changeBackGround, false);

    }());

    (function () {
        /**Write a script that shims querySelector and 
        querySelectorAll in older browsers*/

    }());
};