/*jslint browser: true*/
/*global alert */

(function () {
    "use strict";
    var arrayInitialization = document.getElementById("index-multiplied-by-five"),
        lexicographicCompare = document.getElementById("compare-lexicographically"),
        maxSequenceOfEquals = document.getElementById("find-max-sequence-of-equals"),
        maxIncreasingSequence = document.getElementById("find-max-increasing-sequence"),
        selectionSort = document.getElementById("selection-sort"),
        mostFrequent = document.getElementById("most-frequent"),
        binarySearch = document.getElementById("binary-search");

    function printResult(element, text) {
        var result = element.getElementsByClassName("result")[0];
        result.innerHTML = text;
        result.style.color = "black";
    }

    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    function generateSequenceOfEqualElements(member, count) {
        var i,
            result = [];
        for (i = 0; i < count; i++) {
            result.push(member);
        }

        return result;
    }

    function handleSingleInput(element, inputIndex) {
        var inputValue = element.getElementsByTagName("input")[inputIndex].value;

        inputValue = parseInt(inputValue, 10);
        if (!isNumber(inputValue)) {
            alert("Incorrect input!");
        } else {
            return inputValue;
        }

        return null;
    }

    function handleSequenceInput(element, inputIndex) {
        var i,
            input = element.getElementsByTagName("input")[inputIndex].value,
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

    function handleCharArrayInput(element, inputIndex) {
        var charArray = element.getElementsByTagName("input")[inputIndex].value;
        return charArray;
    }

    function getButton(element) {
        return element.getElementsByTagName("button")[0];
    }

    function sortBySelectionSort(inputArray) {
        var arrIndex = 0,
            len = inputArray.length,
            minNumber = Number.MAX_VALUE,
            resultArray = [];

        while (resultArray.length < len) {
            minNumber = Number.MAX_VALUE;

            // Finds the minimal number.
            for (arrIndex = 0; arrIndex < inputArray.length; arrIndex++) {
                if (minNumber > inputArray[arrIndex]) {
                    minNumber = inputArray[arrIndex];
                }
            }

            // Removes minimal number from the original array
            inputArray.splice(inputArray.indexOf(minNumber), 1);

            resultArray.push(minNumber);
        }

        return resultArray;
    }

    function findMaxSequenceOfEqualNumbers(sequenceInput) {
        var counter = 1,
            i,
            len,
            maxCounter = 0,
            resultIndex = 0;

        for (i = 1, len = sequenceInput.length; i < len; i++) {
            if (sequenceInput[i] === sequenceInput[i - 1]) {
                counter += 1;

                // If this is the last element save result.
                if ((i + 1 >= len) && (counter > maxCounter)) {
                    maxCounter = counter;
                    resultIndex = i;
                }
            } else {
                if (counter > maxCounter) {
                    maxCounter = counter;
                    resultIndex = i - 1;
                }

                counter = 1;
            }
        }

        // Returns object with properties element and length of the repeating sequence
        return {
            element: sequenceInput[resultIndex],
            count: maxCounter
        };
    }

    function binarySearchFunction(inputArray, elementX) {
        var minIndex = 0,
            maxIndex = inputArray.length - 1,
            middlePoint = 0,
            result = "";

        // If minIndex becomes bigger than  maxIndex there is no such number in the array
        while (minIndex <= maxIndex) {
            // Middle point parsed to integer
            middlePoint = parseInt(minIndex + ((maxIndex - minIndex) / 2), 10);

            // Higher indexes - Lower indexes - Min = max index found
            if (elementX > inputArray[middlePoint]) {
                minIndex = middlePoint + 1;
            } else if (elementX < inputArray[middlePoint]) {
                maxIndex = middlePoint - 1;
            } else {
                result = "Searched index is " + middlePoint;
                break; // Break if result is achieved.
            }
        }
        result = result || "There is no such element in this array";

        return result;
    }

    function bubbleSort(inputArray) {
        var i,
            isSwapped = false,
            length = inputArray.length,
            lengthCopy = length,
            swapHelper = 0;

        do {
            isSwapped = false;
            for (i = 1; i < length; i++) {
                if (inputArray[i] < inputArray[i - 1]) {
                    swapHelper = inputArray[i - 1];
                    inputArray[i - 1] = inputArray[i];
                    inputArray[i] = swapHelper;
                    isSwapped = true;
                }
            }

            lengthCopy--;
        } while (isSwapped && lengthCopy >= 0);

        return inputArray;
    }

    function isArrayNotSorted(inputArray) {
        var answer = false,
            i,
            length;
        for (i = 1, length = inputArray.length; i < length; i++) {
            if (inputArray[i] < inputArray[i - 1]) {
                answer = true;
                break;
            }
        }

        return answer;
    }

    /*1. Write a script that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.*/
    getButton(arrayInitialization).onclick = function allocateArray() {
        var arr = new Array(20),
            i,
            length,
            MULTIPLIER = 5;

        for (i = 0, length = arr.length; i < length; i++) {
            arr[i] = i * MULTIPLIER;
        }

        printResult(arrayInitialization, arr.toString());
        console.log(arr);
    };

    /*2. Write a script that compares two char arrays lexicographically (letter by letter).*/
    getButton(lexicographicCompare).onclick = function compareByChar() {
        var answer = "Both arrays are lexicographically equal",
            firstSequence = handleCharArrayInput(lexicographicCompare, 0),
            i,
            length,
            secondSequence = handleCharArrayInput(lexicographicCompare, 1);

        // Takes the value of the shortest sequence.
        length = firstSequence.length <= secondSequence.length ?
                 firstSequence.length : secondSequence.length;

        for (i = 0; i < length; i++) {
            if (firstSequence[i] < secondSequence[i]) {
                answer = "First array is before the second one.";
                break;
            }

            if (firstSequence[i] > secondSequence[i]) {
                answer = "First array is after the second one.";
                break;
            }
        }

        printResult(lexicographicCompare, answer);
    };

    /*3. Write a script that finds the maximal sequence of equal elements in an array.*/
    getButton(maxSequenceOfEquals).onclick = function findMaximalSequenceOfEquals() {
        var answer = "Max length: ",
            maxSequenceProp,
            resultArray = [],
            sequenceInput = handleSequenceInput(maxSequenceOfEquals, 0);

        if (sequenceInput.length < 1) {
            alert("Incorrect input. Input must be array.");
            return;
        }

        maxSequenceProp = findMaxSequenceOfEqualNumbers(sequenceInput);
        resultArray = generateSequenceOfEqualElements(maxSequenceProp.element, maxSequenceProp.count);

        answer += maxSequenceProp.count + " -> " + resultArray;
        printResult(maxSequenceOfEquals, answer);
    };

    /*4. Write a script that finds the maximal increasing sequence in an array.*/
    getButton(maxIncreasingSequence).onclick = function findMaxIncreasingSequence() {
        var answer = "Max length: ",
            arrIndex = 0,
            counter = 1,
            inputArray = handleSequenceInput(maxIncreasingSequence, 0),
            len,
            maxCounter = 0,
            maxSequenceEndIndex = 0,
            resultArray = [],
            resultEndIndex = 0,
            resultStartIndex = 0;

        if (inputArray.length < 1) {
            alert("Incorrect input. Input must be array.");
            return;
        }

        for (arrIndex = 1, len = inputArray.length; arrIndex < len; arrIndex++) {
            // Check if current element is bigger than previous . If current is first continue
            if (inputArray[arrIndex] > inputArray[arrIndex - 1]) {
                counter++;

                // Check if this is the last element
                if ((arrIndex + 1 >= len) && (counter > maxCounter)) {
                    maxCounter = counter;
                    maxSequenceEndIndex = arrIndex + 1; // Due to slice specifications added 1;
                }
            } else {
                if (counter > maxCounter) {
                    maxCounter = counter;
                    maxSequenceEndIndex = arrIndex;
                }

                counter = 1;
            }
        }

        resultStartIndex = maxSequenceEndIndex - maxCounter;
        resultEndIndex = maxSequenceEndIndex;
        resultArray = inputArray.slice(resultStartIndex, resultEndIndex);
        answer += maxCounter + " -> " + resultArray.toString();
        printResult(maxIncreasingSequence, answer);
    };

    /*5. Sorting an array means to arrange its elements in increasing order. Write a script to sort an array. 
     * Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find 
     * the smallest from the rest, move it at the second position, etc. Hint: Use a second array*/
    getButton(selectionSort).onclick = function selectionSortTask() {
        var inputArray = handleSequenceInput(selectionSort, 0),
            resultArray = [];

        resultArray = sortBySelectionSort(inputArray);

        printResult(selectionSort, resultArray.toString());
    };

    /*6. Write a program that finds the most frequent number in an array.*/
    getButton(mostFrequent).onclick = function findMostFrequentNumber() {
        var answer = "Most frequent is ",
            inputArray = handleSequenceInput(mostFrequent, 0),
            mostFrequentProp,
            sortedArray = [];

        sortedArray = sortBySelectionSort(inputArray);
        mostFrequentProp = findMaxSequenceOfEqualNumbers(sortedArray);
        answer += mostFrequentProp.element + " (" + mostFrequentProp.count + " times)";

        printResult(mostFrequent, answer);
    };

    /*7. Write a program that finds the index of given element in a sorted array of integers by using the 
     * binary search algorithm (find it in Wikipedia).*/
    getButton(binarySearch).onclick = function binarySearchTask() {
        var answer = "",
            inputArray = handleSequenceInput(binarySearch, 0),
            inputWantedElement = handleSingleInput(binarySearch, 1),
            sortedArray = [];

        if (isArrayNotSorted(inputArray)) {
            answer += "The array is internally sorted! ";
            sortedArray = bubbleSort(inputArray);
        } else {
            sortedArray = inputArray;
        }

        answer += binarySearchFunction(sortedArray, inputWantedElement);

        printResult(binarySearch, answer);
    };
}());