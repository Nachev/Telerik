/*jslint browser: true*/
/*global alert */

(function () {
    'use strict';
    var shapes = document.getElementById('shapes'),
        calcDistance = document.getElementById('calc-distance'),
        checkTriangle = document.getElementById('check-triangle'),
        remove = document.getElementById('remove'),
        deepCopy = document.getElementById('deep-copy'),
        checkProperty = document.getElementById('check-property'),
        youngestPersons = document.getElementById('persons'),
        groupObjects = document.getElementById('group-objects'),
        testObject = {
            x: 3,
            y: '4',
            z: [5, 6, 7]
        },
        persons = [
                    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
                    { firstname: 'Pesho', lastname: 'Ivanov', age: 41 },
                    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
                    { firstname: 'Bay', lastname: 'Zhelyazko', age: 31 },
                    { firstname: 'Mariika', lastname: 'Moneva', age: 53 }
        ];

    // Helper functions
    function printResult(element, text) {
        var result = element.getElementsByClassName('result')[0];
        result.innerHTML = text;
        result.style.color = 'black';
    }

    /*function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }*/

    function isNumber(n) {
        return !isNaN(n - 0) && n !== null && n !== "" && n !== false;
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

    function handleNumSequenceInput(element, inputIndex) {
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

    function handleAnySequenceInput(element, inputIndex) {
        var input = element.getElementsByTagName('input')[inputIndex].value,
            outputValues = [],
            legitValue = /[A-Za-z0-9\']+/g;

        outputValues = input.match(legitValue);

        return outputValues;
    }

    function power(number, n) {
        var result = 1;

        if (n === 0) {
            return 1;
        }

        for (var i = 0; i < n; i++) {
            result *= number;
        }

        return result;
    }

    function initializeValues(args) {
        if (Array.isArray(args)) {
            for (var i = 0, length = args.length; i < length; i++) {
                args[i] = initializeValues(args[i]);
            }
        } else if (typeof args === 'object') {
            for (var prop in args) {
                if (args.hasOwnProperty(prop) && isNumber(args[prop])) {
                    args[prop] = 0;
                }
            }
        } else if (isNumber(args)) {
            args = 0;
            return args;
        }

        return null;
    }

    testObject.toString = function () {
        var prop,
            result = [];

        for (prop in this) {
            if (this.hasOwnProperty(prop) && prop !== 'toString') {
                result.push(prop + ':' + this[prop]);
            }
        }

        return '{' + result.join() + '}';
    };

    function deepCopyObj(obj) {
        // Handle the 3 simple types, and null or undefined
        if (obj === null || !(obj instanceof Object)) {
            return obj;
        }

        // Handle Date
        if (obj instanceof Date) {
            var copyDate = new Date();
            copyDate.setTime(obj.getTime());
            return copyDate;
        }

        // Handle Array
        if (obj instanceof Array) {
            var copyArray = [];
            for (var i = 0, len = obj.length; i < len; i++) {
                copyArray[i] = deepCopyObj(obj[i]);
            }
            return copyArray;
        }

        // Handle Function
        if (obj instanceof Function) {
            var copyFunc = function () { };
            for (var key in obj) {
                if (obj.hasOwnProperty(key)) {
                    copyFunc[key] = obj[key];
                }
            }
            return copyFunc;
        }

        // Handle Object
        if (obj instanceof Object) {
            var copyObject = new obj.constructor();
            for (var attr in obj) {
                if (obj.hasOwnProperty(attr)) {
                    copyObject[attr] = deepCopyObj(obj[attr]);
                }
            }
            return copyObject;
        }

        throw new Error("Unable to copy obj! Its type isn't supported.");
    }

    function findYoungestOne(objArray) {
        var minAge = 200,
        youngestIndex = 0;

        for (var i = 0, length = objArray.length; i < length; i++) {
            if (objArray[i].hasOwnProperty('age')) {
                if (objArray[i].age < minAge) {
                    minAge = objArray[i].age;
                    youngestIndex = i;
                }
            }
        }

        return youngestIndex;
    }

    function strcmp(str1, str2) { // Function for string comparision
        return ((str1 === str2) ? 0 : ((str1 > str2) ? 1 : -1));
    }

    persons.toString = function () {
        var result = '';
        for (var i = 0, len = this.length; i < len; i++) {
            result += 'name: ' + this[i].firstname + ' ' + this[i].lastname + ' age: ' + this[i].age + '; ';
        }
        return result;
    };

    /*1. Write functions for working with shapes in standard Planar coordinate system*/
    shapes.onclick = function shapesFunc() { // Wrapper function
        function isPoint(obj) {
            if (typeof obj === 'object') {
                if (obj.hasOwnProperty('xCoord') && obj.hasOwnProperty('yCoord')) {
                    return true;
                }
            }

            return false;
        }

        function Point(xCoord, yCoord) {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
        }

        function calcLinearDistance(firstPoint, secondPoint) {
            var x = firstPoint.xCoord - secondPoint.xCoord,
                y = firstPoint.yCoord - secondPoint.yCoord,
                result = 0;

            result = Math.sqrt(power(x, 2) + power(y, 2));

            return result;
        }

        function Line(startPoint, endPoint) {
            if (isPoint(startPoint) && isPoint(endPoint)) {
                this.startPoint = startPoint;
                this.endPoint = endPoint;
            } else {
                alert('Error in Line creation.');
            }
        }

        function isPossibleToConstructTriangle(lines) {
            var i,
                len,
                linesLength = [0, 0, 0];

            for (i = 0, len = lines.length; i < len; i++) {
                linesLength = calcLinearDistance(lines[i].startPoint, lines[i].endPoint);
            }

            if (linesLength[0] < linesLength[1] + linesLength[2]) {
                return true;
            }

            return false;
        }

        /*On button click calculates the distance between two given points.*/
        getButton(calcDistance).onclick = function calcDistanceFunc() {
            var answer = '',
                firstPointCoords = handleNumSequenceInput(calcDistance, 0),
                secondPointCoords = handleNumSequenceInput(calcDistance, 1),
                firstPoint,
                secondPoint;

            firstPoint = new Point(firstPointCoords[0], firstPointCoords[1]);
            secondPoint = new Point(secondPointCoords[0], secondPointCoords[1]);

            answer = calcLinearDistance(firstPoint, secondPoint);
            printResult(calcDistance, answer);
        };

        /*On button click checks if it is possible to construct triangle*/
        getButton(checkTriangle).onclick = function checkTriangleFunc() {
            var answer = '',
                pointsCoords = [],
                firstPoint,
                secondPoint,
                lines = [0, 0, 0];

            (function handleThreeLineInput() {
                for (var linesCount = 0; linesCount < 3; linesCount++) {
                    for (var pointsCount = 0; pointsCount < 2; pointsCount++) {
                        pointsCoords[pointsCount] = handleNumSequenceInput(checkTriangle, linesCount + pointsCount);
                    }

                    firstPoint = new Point(pointsCoords[0][0], pointsCoords[0][1]);
                    secondPoint = new Point(pointsCoords[1][0], pointsCoords[1][1]);
                    lines[linesCount] = new Line(firstPoint, secondPoint);
                    initializeValues(firstPoint);
                    initializeValues(secondPoint);
                }
            }());

            if (isPossibleToConstructTriangle(lines)) {
                answer = 'It is possible.';
            } else {
                answer = 'It is not possible.';
            }

            printResult(checkTriangle, answer);
        };
    };

    /*2. Write a function that removes all elements with a given value.*/
    Array.prototype.removeAll = function removeAllSplice(value) {
        var i,
            len;

        for (i = 0, len = this.length; i < len; i++) {
            if (this[i] === value) {
                this.splice(i, 1);
            }
        }
    };

    function removeAllSlice(array, value) { // Much slower variant.
        var i,
            len,
            result = [],
            startIndex = 0;

        for (i = 0, len = array.length; i < len; i++) {
            if (array[i] === value) {
                array.slice(startIndex, i).forEach(function (x) { result.push(x); }, result);
            }
        }

        return result;
    }

    getButton(remove).onclick = function removeElements() {
        var answer = '',
            inputArray = handleAnySequenceInput(remove, 0),
            inputValue = remove.getElementsByTagName('input')[1].value;

        inputArray.removeAll(inputValue);
        answer = inputArray.toString();
        printResult(remove, answer);
    };

    /*3. Write a function that makes a deep copy of an object*/
    deepCopy.onmouseover = function () {
        var display = deepCopy.getElementsByClassName('object')[0];
        display.textContent = testObject.toString();

        getButton(deepCopy).onclick = function deepCopyFunc() {
            var newObject = {};//JSON.parse(JSON.stringify(testObject));
            newObject = deepCopyObj(testObject);
            newObject.toString = testObject.toString;
            printResult(deepCopy, newObject);
        };
    };

    /*4. Write a function that checks if a given object contains a given property*/
    checkProperty.onmouseover = function () {
        var display = checkProperty.getElementsByClassName('object')[0];
        display.textContent = testObject.toString();

        function hasProperty(obj, property) {
            return obj.hasOwnProperty(property);
        }

        getButton(checkProperty).onclick = function checkPropertyFunc() {
            var answer = '',
                propInput = checkProperty.getElementsByTagName('input')[0].value;
            answer = hasProperty(testObject, propInput);
            printResult(checkProperty, answer);
        };
    };

    /*5. Write a function that finds the youngest person in a given array of persons and 
     * prints his/hers full name*/
    youngestPersons.onmouseover = function () {
        var display = youngestPersons.getElementsByClassName('object')[0];

        display.textContent = persons.toString();

        getButton(youngestPersons).onclick = function findPersonFunc() {
            var answer = '',
                searchIndex = 0;

            searchIndex = findYoungestOne(persons);
            answer = persons[searchIndex].firstname + ' ' + persons[searchIndex].lastname;
            printResult(youngestPersons, answer);
        };
    };

    /*6. Write a function that groups an array of persons by age, first or last name. The 
     * function must return an associative array, with keys - the groups, and values - 
     * arrays with persons in this groups*/
    groupObjects.onmouseover = function () {
        function group(objArray, property) {
            switch (property) {
                case 'age':
                    var groupedByAge = orderByAge(objArray);
                    return groupedByAge;
                case 'firstname':
                case 'lastname':
                    var groupedByName = orderByName(objArray, property);
                    return groupedByName;
                default:
                    var allInOne = [],
                        byAge = orderByAge(objArray),
                        byFname = orderByName(objArray, 'firstname'),
                        byLname = orderByName(objArray, 'lastname');

                    allInOne.age = byAge.age;
                    allInOne.firstname = byFname.firstname;
                    allInOne.lastname = byLname.lastname;
                    return allInOne;
            }
        }

        function orderByAge(objArray) {
            var youngestIndex = 0,
                arrCopy = deepCopyObj(objArray),
                orderedArray = [],
                result = [];

            while (arrCopy.length > 0) {
                youngestIndex = findYoungestOne(arrCopy);
                orderedArray.push(arrCopy[youngestIndex]);
                arrCopy.splice(youngestIndex, 1);
            }

            result.age = orderedArray;
            return result;
        }

        function foremostName(arrCopy, name) {
            if (!arrCopy.every(function (x) {
                return x.hasOwnProperty(name);
            })) {
                throw Error('ArrCopy does not have this property: ' + name);
            }

            var foremost = arrCopy[0][name],
                indexSave = 0,
                nameToLower = '',
                foremostToLower = '';

            for (var i = 0, len = arrCopy.length; i < len; i++) {
                nameToLower = arrCopy[i][name].toLowerCase();
                foremostToLower = foremost.toLowerCase();
                if (strcmp(nameToLower, foremostToLower) < 0) {
                    foremost = arrCopy[i][name];
                    indexSave = i;
                }
            }

            return indexSave;
        }

        function orderByName(objArray, name) {
            var foremostNameIndex = 0,
                arrCopy = deepCopyObj(objArray),
                orderedArray = [],
                result = [];

            while (arrCopy.length > 0) {
                foremostNameIndex = foremostName(arrCopy, name);
                orderedArray.push(arrCopy[foremostNameIndex]);
                arrCopy.splice(foremostNameIndex, 1);
            }

            result[name] = orderedArray;
            return result;
        }

        function orderedObjectsToString() {

        }

        getButton(groupObjects).onclick = function groupObjectsFunc() {
            var result = '',
                groupedArray = [];

            groupedArray = group(persons);
            for (var i in groupedArray) {
                if (groupedArray.hasOwnProperty(i)) {
                    if (Array.isArray(groupedArray[i])) {
                        result += i.toString() + ' - ';
                        for (var j = 0, length = groupedArray[i].length; j < length; j++) {
                            result += ' ' + groupedArray[i][j].firstname + ' ' + groupedArray[i][j].lastname + ' ' + groupedArray[i][j].age + ';';
                        }
                    }
                }                
            }

            printResult(groupObjects, result);
        };
    };
}());