/*jslint browser: true*/
/*global alert */

window.onload = function () {
    var oddEven = document.getElementById("odd-even"),
        moduloSeven = document.getElementById("modulo-seven"),
        rectangleArea = document.getElementById("rectangle-area"),
        thirdDigit = document.getElementById("third-digit"),
        fourthBit = document.getElementById("fourth-bit"),
        isInCircle = document.getElementById("is-in-circle"),
        checkForPrime = document.getElementById("is-prime"),
        trapezoidArea = document.getElementById("trapezoid-area"),
        isInShape = document.getElementById("is-in-shape");

    function printResult(element, text) {
        element.innerHTML = text;
        element.style.color = "black";
    }

    function mathPow(number, power) {
        var i = 0; // Loop counter
        for (i = 1; i < power; i++) {
            number *= number;
        }
        return number;
    }

    oddEven.getElementsByTagName("button")[0].onclick = function () {
        var oddEvenInput = parseInt(oddEven.children[1].value, 10),
            result = oddEven.getElementsByTagName("span")[0],
            answer;

        if (oddEvenInput) {
            if ((oddEvenInput & 1) === 1) {
                answer = "odd";
            } else {
                answer = "even";
            }

            printResult(result, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    moduloSeven.getElementsByTagName("button")[0].onclick = function () {
        var moduloSevenInput = parseInt(moduloSeven.children[1].value, 10),
            result = moduloSeven.getElementsByTagName("span")[0],
            answer;

        if (moduloSevenInput) {
            answer = (((moduloSevenInput % 7) === 0) && ((moduloSevenInput % 5) === 0));

            printResult(result, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    rectangleArea.getElementsByTagName("button")[0].onclick = function () {
        var inputX = parseFloat(rectangleArea.getElementsByTagName("input")[0].value, 10),
            inputY = parseFloat(rectangleArea.getElementsByTagName("input")[1].value, 10),
            result = rectangleArea.getElementsByTagName("span")[0],
            answer;

        if (inputX && inputY) {
            answer = inputY * inputX;

            printResult(result, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    thirdDigit.getElementsByTagName("button")[0].onclick = function () {
        var input = parseInt(thirdDigit.getElementsByTagName("input")[0].value, 10),
            result = thirdDigit.getElementsByTagName("span")[0],
            answer,
            modulo;

        if (input) {
            modulo = (input / 100) % 10;
            modulo = parseInt(modulo, 10);
            answer = modulo === 7;

            printResult(result, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    fourthBit.getElementsByTagName("button")[0].onclick = function () {
        var input = parseInt(fourthBit.getElementsByTagName("input")[0].value, 10),
            result = fourthBit.getElementsByTagName("span")[0],
            answer;

        if (input) {
            if ((input >> 3) === 1) {
                answer = "one";
            } else {
                answer = "zero";
            }

            printResult(result, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    isInCircle.getElementsByTagName("button")[0].onclick = function () {
        var inputX = parseFloat(isInCircle.getElementsByTagName("input")[0].value, 10),
            inputY = parseFloat(isInCircle.getElementsByTagName("input")[1].value, 10),
            result = isInCircle.getElementsByTagName("span")[0],
            CIRCLE_C = 0.00,
            CIRCLE_R = 5.00,
            answer;

        if (inputX && inputY) { // Checks if there is correct input
            answer = (mathPow(inputX, 2) + mathPow(inputY, 2)) <= (CIRCLE_R - CIRCLE_C);// Pythagorean formula

            printResult(result, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    checkForPrime.getElementsByTagName("button")[0].onclick = function () {
        var input = parseInt(checkForPrime.getElementsByTagName("input")[0].value, 10),
            result = checkForPrime.getElementsByTagName("span")[0],
            answer = "is prime",
            condition,
            i;

        if (input) {
            condition = Math.sqrt(input);
            for (i = 2; i < condition; i++) {
                if (((input % i) === 0) && input > 2) {
                    answer = "is not prime";
                    break;
                }
            }

            printResult(result, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    trapezoidArea.getElementsByTagName("button")[0].onclick = function () {
        var inputA = parseFloat(trapezoidArea.getElementsByTagName("input")[0].value, 10),
            inputB = parseFloat(trapezoidArea.getElementsByTagName("input")[1].value, 10),
            inputH = parseFloat(trapezoidArea.getElementsByTagName("input")[2].value, 10),
            answer,
            result = trapezoidArea.getElementsByTagName("span")[0];

        if (inputA && inputB && inputH) {
            answer = ((inputA + inputB) / 2) * inputH; // Area = 1/2 * (a + b) * h where a,b are bases and h - height

            printResult(result, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    isInShape.getElementsByTagName("button")[0].onclick = function () {
        var inputX = parseFloat(isInShape.getElementsByTagName("input")[0].value, 10),
            inputY = parseFloat(isInShape.getElementsByTagName("input")[1].value, 10),
            result = isInShape.getElementsByTagName("span")[0],
            CIRCLE_C = 1.00,
            CIRCLE_R = 3.00,
            RECT_TOP = 1.00,
            RECT_LEFT = -1.00,
            RECT_WIDTH = 6.00,
            RECT_HEIGHT = 2.00,
            vectorLenght,
            outRectangle,
            answer;

        if (inputX && inputY) { // Checks if there is correct input
            // Vector between point(x,y) and circle's center(1,1) has coordinates (x-1,y-1) and lenght vectorLenght.
            vectorLenght = Math.sqrt(mathPow(inputX - CIRCLE_C, 2) + mathPow(inputY - CIRCLE_C, 2));
            // If this requirement is fulfilled the point is outside the rectangle.
            outRectangle = (inputY > RECT_TOP) ||
                (inputY < (RECT_TOP + RECT_HEIGHT)) ||
                (inputX < RECT_LEFT) ||
                (inputX > (RECT_LEFT + RECT_WIDTH));
            // If vector's lenght is shorter than the circle's radius and the point is outside the rectangle there is a hit.
            answer = (vectorLenght < CIRCLE_R) && outRectangle;
            printResult(result, answer);
        } else {
            alert("Incorrect input!");
        }
    };
};