/*jslint browser: true*/
/*global alert */

(function () {
    'use strict';
    var translateDigit = document.getElementById('translate-digit'),
        reverseDigits = document.getElementById('reverse-digits'),
        searchText = document.getElementById('search-text'),
        countDivs = document.getElementById('count-divs'),
        countNumberAppearances = document.getElementById('count-number-appearances'),
        compareNeighbours = document.getElementById('compare-neighbours'),
        findBiggerThanNeighbours = document.getElementById('find-bigger-than-neighbours');

    function printResult(element, text) {
        var result = element.getElementsByClassName('result')[0];
        result.innerHTML = text;
        result.style.color = 'black';
    }

    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    function getButton(element) {
        return element.getElementsByTagName('button')[0];
    }

    function handleSingleInput(element, inputIndex) {
        var inputValue = element.getElementsByTagName('input')[inputIndex].value;

        inputValue = parseFloat(inputValue, 10);
        if (!isNumber(inputValue)) {
            alert('Incorrect input!');
        } else {
            return inputValue;
        }

        return null;
    }

    function handleSequenceInput(element, inputIndex) {
        var i,
            input = element.getElementsByTagName('input')[inputIndex].value,
            inputValues = [],
            length,
            numberValues = [],
            parsedValue,
            separators = /(\s*;\s*)|(\s*,\s*)|(\s+)/;

        inputValues = input.split(separators);
        for (i = 0, length = inputValues.length; i < length; i++) {
            parsedValue = parseFloat(inputValues[i], 10);
            if (isNumber(parsedValue)) {
                numberValues.push(parsedValue);
            }
        }

        return numberValues;
    }

    /*Task 6 and 7*/
    function isBiggerThanNeighbours(array, index) {
        var previousMember = index > 0 ? array[index - 1] : Number.MAX_VALUE * -1,
            currentMember = array[index],
            nextMember = index < array.length ? array[index + 1] : Number.MAX_VALUE * -1;
        if (currentMember > previousMember && currentMember > nextMember) {
            return true;
        }

        return false;
    }

    /*1. Write a function that returns the last digit of given integer as an English word.*/
    getButton(translateDigit).onclick = function translateDigitFunc() {
        var answer = '',
            lastDigit = 0,
            inputNumber = handleSingleInput(translateDigit, 0);

        function digitTranslator(digit) {
            var dictOnes = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'],
                result = '';

            result = dictOnes[digit];
            return result;
        }

        function getLastDigit(number) {
            var result = 0;

            result = number % 10;
            return result;
        }

        lastDigit = getLastDigit(inputNumber);
        answer = digitTranslator(lastDigit);
        printResult(translateDigit, answer);
    };

    /*2. Write a function that reverses the digits of given decimal number.*/
    getButton(reverseDigits).onclick = function reverseDigitsFunc() {
        var answer = '',
            inputNumber = handleSingleInput(reverseDigits, 0),
            numberAsString = '';

        function handleNegative(number) {
            if (number < 0) {
                alert('Minus sign will be ignored.');
                number *= -1;
            }
            return number;
        }

        function reverseDigitsOrder(numberAsStr) {
            var i,
                result = '';

            for (i = numberAsStr.length - 1; i >= 0; i--) {
                result += numberAsStr[i];
            }
            return result;
        }

        inputNumber = handleNegative(inputNumber);
        numberAsString = inputNumber.toString();
        answer = reverseDigitsOrder(numberAsString);
        printResult(reverseDigits, answer);
    };

    /*3. Write a function that finds all the occurrences of word in a text.*/
    getButton(searchText).onclick = function searchTextFunc() {
        var answer = '',
            repeatCount = 0,
            inputText = searchText.getElementsByTagName('input')[0].value,
            inputWord = searchText.getElementsByTagName('input')[1].value,
            indexes = [],
            searchResult = {};

        function compareStrings(baseWord, competitor) {
            if (baseWord < competitor) {
                return -1;
            }
            if (baseWord > competitor) {
                return 1;
            }
            return 0;
        }

        function searchForWordInText(text, word) {
            var i,
                length = text.length,
                result = {
                    startIndex: [],
                    count: 0
                },
                substr = '',
                wordLen = word.length;

            for (i = 0; i < length; i++) {
                if (text[i] === word[0]) {
                    substr = text.substr(i, wordLen);
                    if (compareStrings(word, substr) === 0) {
                        result.startIndex.push(i);
                        result.count += 1;
                    }
                }
            }
            return result;
        }

        searchResult = searchForWordInText(inputText, inputWord);
        indexes = searchResult.startIndex;
        repeatCount = searchResult.count;

        if (repeatCount > 0) {
            answer = 'This word appears ' +
                repeatCount + ' times in the text, at indexes ' +
                indexes;
        } else {
            answer = 'This word is not found in the text.';
        }

        printResult(searchText, answer);
    };

    /*4. Write a function to count the number of divs on the web page.*/
    getButton(countDivs).onclick = function countDivsFunc() {
        var answer = '',
            body = document.body;

        function countDivElements(htmlElement) {
            var nodes = htmlElement.getElementsByTagName('div'),
                result = nodes.length;

            return result;
        }

        answer = countDivElements(body);
        printResult(countDivs, answer);
    };

    /*5. Write a function that counts how many times given number appears in given array. 
     * Write a test function to check if the function is working correctly.*/
    getButton(countNumberAppearances).onclick = function countNumberAppearancesFunc() {
        var answer = '',
            inputArray = handleSequenceInput(countNumberAppearances, 0),
            inputNumber = handleSingleInput(countNumberAppearances, 1);

        function countAppearancesOfNumber(number, array) {
            var result = 0,
                i = 0,
                len;

            for (i = 0, len = array.length; i < len; i++) {
                if (number === array[i]) {
                    result += 1;
                }
            }

            return result;
        }

        answer = countAppearancesOfNumber(inputNumber, inputArray);
        printResult(countNumberAppearances, answer);
    };

    /*6. Write a function that checks if the element at given position in given array of 
     * integers is bigger than its two neighbors (when such exist).*/
    getButton(compareNeighbours).onclick = function compareNeighboursFunc() {
        var answer = '',
            inputPosition = handleSingleInput(compareNeighbours, 1),
            inputArray = handleSequenceInput(compareNeighbours, 0);

        function isAllIntegers(array) {
            var i = 0,
                length = 0;
            for (i = 0, length = array.length; i < length; i++) {
                if (array[i] % 1 !== 0) {
                    alert('Not all numbers in the array are integers.');
                    return 'Error';
                }
            }

            return null;
        }

        function checkNeighbourhood(array, position) {
            if (position < 0 || position > array.length) {
                alert('Entered position is not in the array range!');
                return 'Error';
            }

            return isAllIntegers(array) || isBiggerThanNeighbours(array, position);
        }

        answer = checkNeighbourhood(inputArray, inputPosition);
        printResult(compareNeighbours, answer);
    };

    /*7. Write a function that returns the index of the first element in array that is 
     * bigger than its neighbors, or -1, if there’s no such element.  Use the function 
     * from the previous exercise.*/
    getButton(findBiggerThanNeighbours).onclick = function findBiggerThanNeighboursFunc() {
        var answer = '',
            i,
            inputArray = handleSequenceInput(findBiggerThanNeighbours, 0),
            length = 0;

        function findFirstBiggerThanNeighbours() {
            for (i = 0, length = inputArray.length; i < length; i++) {
                if (isBiggerThanNeighbours(inputArray, i)) {
                    return i;
                }
            }

            return -1;
        }

        answer = findFirstBiggerThanNeighbours();
        printResult(findBiggerThanNeighbours, answer);
    };
}());