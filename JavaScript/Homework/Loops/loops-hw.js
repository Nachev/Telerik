/*jslint browser: true*/
/*global alert */

window.onload = function () {
    var numbersToN = document.getElementById("numbers-to-n"),
        numbersWithCondition = document.getElementById("numbers-with-condition"),
        minMaxInSequence = document.getElementById("min-max-sequence"),
        findShortestAndLongestProperty = document.getElementById("find-property");

    function printResult(element, text) {
        var result = element.getElementsByClassName("result")[0];
        result.innerHTML = text;
        result.style.color = "black";
    }

    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    function appendSeparator(string, member, length) {
        var betweenMembers = ", ",
            atTheEnd = ";";
        if (member < length) {
            string += betweenMembers;
        } else {
            string += atTheEnd;
        }

        return string;
    }

    function checkIfDivisible(n) {
        var dividerSeven = 7,
            dividerFive = 5;

        if (isNumber(n)) {
            if ((n % dividerSeven !== 0) || (n % dividerFive !== 0)) {
                return n;
            }
        }

        return null;
    }

    function generateSequenceWithCondition(n, conditionFunc) {
        var i, // counter variable
            member,
            output = "";

        if (isNumber(n)) {
            for (i = 1; i <= n; i++) {
                member = i;

                // Check if there is condition function.
                if (typeof conditionFunc === "function") {
                    member = conditionFunc(i);
                }

                // If member is number adds it to the output string.
                if (isNumber(member)) {
                    output += member.toString();
                    output = appendSeparator(output, member, n);
                }
            }
        } else {
            output = "No N";
        }

        return output;
    }

    function handleOneInput(element) {
        var inputValue = element.getElementsByTagName("input")[0].value;

        inputValue = parseInt(inputValue, 10);
        if (!isNumber(inputValue)) {
            alert("Incorrect input!");
        } else {
            return inputValue;
        }
    }

    function handleSequenceInput(element) {
        var i,
            input = element.getElementsByTagName("input")[0].value,
            inputValues = [],
            length,
            numberValues = [],
            parsedValue,
            separators = /(\s*;\s*)|(\s*,\s+)|(\s+)/;

        inputValues = input.split(separators);
        for (i = 0, length = inputValues.length; i < length; i++) {
            parsedValue = parseFloat(inputValues[i], 10);
            if (isNumber(parsedValue)) {
                numberValues.push(parsedValue);
            }
        }

        return numberValues;
    }

    function getMax(base, chalenger) {
        if (base < chalenger) {
            return chalenger;
        }

        return base;
    }

    function getMin(base, chalenger) {
        if (base > chalenger) {
            return chalenger;
        }

        return base;
    }

    function getProperties(myObject) {
        var keys = [],
            prop;

        for (prop in myObject) {
            if (myObject.hasOwnProperty(prop)) {
                keys.push(prop);
            }
        }

        return keys;
    }

    function findExtremumLengthElements(strArray) {
        var i, // Loop counter.
            lastLongest = 0,
            lastShortest = Number.MAX_VALUE,
            len, // Array length.
            longest = Number.MAX_VALUE * -1,
            longPropName = "", // Current longest property name.
            result = "",
            shortest = Number.MAX_VALUE,
            shortPropName = ""; // Current shortest property name.

        for (i = 0, len = strArray.length; i < len; i++) {
            // Finds max length element.
            longest = getMax(longest, strArray[i].toString().length);
            if (lastLongest < longest) {
                longPropName = strArray[i].toString();
                lastLongest = longest;
            }

            // Finds min length element.
            shortest = getMin(shortest, strArray[i].toString().length);
            if (lastShortest > shortest) {
                shortPropName = strArray[i].toString();
                lastShortest = shortest;
            }
        }

        result = "Longest: " + longPropName + " - " + longest + ", Shortest: " + shortPropName + " - " + shortest;
        return result;
    }

    numbersToN.getElementsByTagName("button")[0].onclick = function () {
        var answer = "",
            inputValue = handleOneInput(numbersToN);

        answer = generateSequenceWithCondition(inputValue);
        printResult(numbersToN, answer);
    };

    numbersWithCondition.getElementsByTagName("button")[0].onclick = function () {
        var answer = "",
            inputValue = handleOneInput(numbersWithCondition);

        answer = generateSequenceWithCondition(inputValue, checkIfDivisible);
        printResult(numbersWithCondition, answer);
    };

    minMaxInSequence.getElementsByTagName("button")[0].onclick = function () {
        var answer = "",
            i,
            inputValues = handleSequenceInput(minMaxInSequence),
            len,
            min = Number.MAX_VALUE,
            max = Number.MAX_VALUE * -1;

        for (i = 0, len = inputValues.length; i < len; i++) {
            min = getMin(min, inputValues[i]);
            max = getMax(max, inputValues[i]);
        }

        answer = "Min = " + min + ", " + "Max = " + max;
        printResult(minMaxInSequence, answer);
    };

    findShortestAndLongestProperty.getElementsByTagName("button")[0].onclick = function () {
        var answer = "",
            keys = [];

        keys = getProperties(window);
        answer += "window -> " + findExtremumLengthElements(keys) + "; " + "\n";

        keys = getProperties(document);
        answer += "document -> " + findExtremumLengthElements(keys) + "; " + "\n";

        keys = getProperties(navigator);
        answer += "navigator -> " + findExtremumLengthElements(keys);

        printResult(findShortestAndLongestProperty, answer);
    };
};