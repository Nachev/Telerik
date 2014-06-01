/*jslint browser: true*/
/*global alert */

window.onload = function () {
    var checkGreater = document.getElementById("check-greater"),
        checkProduct = document.getElementById("check-product"),
        findBiggest = document.getElementById("find-biggest"),
        sortDescending = document.getElementById("sort-descending"),
        translateDigit = document.getElementById("translate-digit"),
        calcQuadratic = document.getElementById("calc-quadratic"),
        findGreatest = document.getElementById("find-greatest"),
        translateNumber = document.getElementById("translate-number");

    function printResult(element, text) {
        var result = element.getElementsByClassName("result")[0];
        result.innerHTML = text;
        result.style.color = "black";
    }

    function mathPow(number, power) {
        var i = 0; // Loop counter
        for (i = 1; i < power; i++) {
            number *= number;
        }
        return number;
    }

    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    checkGreater.getElementsByTagName("button")[0].onclick = function () {
        var inputFirst = checkGreater.getElementsByTagName("input")[0],
            inputSecond = checkGreater.getElementsByTagName("input")[1],
            firstValue = parseInt(inputFirst.value, 10),
            secondValue = parseInt(inputSecond.value, 10),
            answer;

        if (isNumber(firstValue) && isNumber(secondValue)) {
            if (firstValue > secondValue) {
                // Swap variables.
                inputFirst.value = secondValue.toString();
                inputSecond.value = firstValue.toString();

                answer = "Exchanged";
            } else {
                answer = "Second one is greater or equal";
            }

            printResult(checkGreater, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    checkProduct.getElementsByTagName("button")[0].onclick = function () {
        var inputA = parseFloat(checkProduct.getElementsByTagName("input")[0].value, 10),
            inputB = parseFloat(checkProduct.getElementsByTagName("input")[1].value, 10),
            inputC = parseFloat(checkProduct.getElementsByTagName("input")[2].value, 10),
            answer = "+";

        if (isNumber(inputA) && isNumber(inputB) && isNumber(inputC)) {
            if (inputA === 0 || inputB === 0 || inputC === 0) {
                answer = "0";
            } else {
                if (inputA > 0 && inputB > 0 && inputC > 0) {
                    answer = "+";
                } else {
                    if (inputA < 0) {
                        if (inputB > 0 && inputC < 0) {
                            answer = "+";
                        } else {
                            if (inputB < 0 && inputC > 0) {
                                answer = "+";
                            } else {
                                answer = "-";
                            }
                        }
                    } else {
                        if (inputB < 0) {
                            if (inputC > 0) {
                                answer = "-";
                            } else {
                                answer = "+";
                            }
                        } else {
                            answer = "-";
                        }
                    }
                }
            }

            printResult(checkProduct, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    findBiggest.getElementsByTagName("button")[0].onclick = function () {
        var inputA = parseInt(findBiggest.getElementsByTagName("input")[0].value, 10),
            inputB = parseInt(findBiggest.getElementsByTagName("input")[1].value, 10),
            inputC = parseInt(findBiggest.getElementsByTagName("input")[2].value, 10),
            answer;

        if (isNumber(inputA) && isNumber(inputB) && isNumber(inputC)) {
            if (inputA > inputB) {
                if (inputB > inputC) {
                    answer = inputA;
                } else {
                    if (inputA > inputC) {
                        answer = inputA;
                    } else {
                        answer = inputC;
                    }
                }
            } else {
                if (inputB > inputC) {
                    answer = inputB;
                } else {
                    answer = inputC;
                }
            }

            printResult(findBiggest, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    sortDescending.getElementsByTagName("button")[0].onclick = function () {
        var inputA = parseInt(sortDescending.getElementsByTagName("input")[0].value, 10),
            inputB = parseInt(sortDescending.getElementsByTagName("input")[1].value, 10),
            inputC = parseInt(sortDescending.getElementsByTagName("input")[2].value, 10),
            answer = "";

        function joinNumbersToString(num1, num2, num3) {
            return num1.toString() + ", " + num2.toString() + ", " + num3.toString();
        }

        if (isNumber(inputA) && isNumber(inputB) && isNumber(inputC)) {
            if (inputA > inputB) {
                if (inputB > inputC) {
                    answer = joinNumbersToString(inputA, inputB, inputC);
                } else {
                    if (inputA > inputC) {
                        answer = joinNumbersToString(inputA, inputC, inputB);
                    } else {
                        answer = joinNumbersToString(inputC, inputA, inputB);
                    }
                }
            } else {
                if (inputB > inputC) {
                    if (inputA > inputC) {
                        answer = joinNumbersToString(inputB, inputA, inputC);
                    } else {
                        answer = joinNumbersToString(inputB, inputC, inputA);
                    }
                } else {
                    answer = joinNumbersToString(inputC, inputB, inputA);
                }
            }

            printResult(sortDescending, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    translateDigit.getElementsByTagName("button")[0].onclick = function () {
        var input = parseInt(translateDigit.getElementsByTagName("input")[0].value, 10),
            answer = "",
            digitStr = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        if (isNumber(input) && input < 10 && input >= 0) {
            switch (input) {
            case 0:
                answer = digitStr[0];
                break;
            case 1:
                answer = digitStr[1];
                break;
            case 2:
                answer = digitStr[2];
                break;
            case 3:
                answer = digitStr[3];
                break;
            case 4:
                answer = digitStr[4];
                break;
            case 5:
                answer = digitStr[5];
                break;
            case 6:
                answer = digitStr[6];
                break;
            case 7:
                answer = digitStr[7];
                break;
            case 8:
                answer = digitStr[8];
                break;
            case 9:
                answer = digitStr[9];
                break;
            default:
                alert("Unknown error.");
            }

            printResult(translateDigit, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    calcQuadratic.getElementsByTagName("button")[0].onclick = function () {
        var inputA = parseFloat(calcQuadratic.getElementsByTagName("input")[0].value, 10),
            inputB = parseFloat(calcQuadratic.getElementsByTagName("input")[1].value, 10),
            inputC = parseFloat(calcQuadratic.getElementsByTagName("input")[2].value, 10),
            answer,
            x1,
            x2,
            d;

        if (isNumber(inputA) && isNumber(inputB) && isNumber(inputC)) {
            d = mathPow(inputB, 2) - (4 * inputA * inputC);
            if (d < 0) {
                answer = "No real roots";
            } else {
                if (d === 0) {
                    // x = - b/2a
                    x1 = -1 * inputB / (2 * inputA);
                    x1 = +x2.toFixed(3); // Rounds the number to precision #.##
                    answer = "x1,x2 = " + x1;
                } else {
                    x1 = ((-1 * inputB) + Math.sqrt(d)) / (2 * inputA);
                    x2 = ((-1 * inputB) - Math.sqrt(d)) / (2 * inputA);
                    x1 = +x1.toFixed(3);
                    x2 = +x2.toFixed(3);
                    answer = "x1 = " + x1 + ", x2 = " + x2;
                }
            }

            printResult(calcQuadratic, answer);
        } else {
            alert("Incorrect input!");
        }
    };

    findGreatest.getElementsByTagName("button")[0].onclick = function () {
        var input = findGreatest.getElementsByTagName("input"),
            answer = Number.MAX_VALUE * -1,
            i,
            tempVar;

        for (i = 0; i < input.length; i++) {
            tempVar = parseFloat(input[i].value, 10);
            if (isNumber(tempVar)) {
                if (tempVar > answer) {
                    answer = tempVar;
                }
            } else {
                alert("Incorrect input!");
                return;
            }
        }

        printResult(findGreatest, answer);
    };

    translateNumber.getElementsByTagName("button")[0].onclick = function () {
        function capitaliseFirstLetter(string) {
            return string.charAt(0).toUpperCase() + string.slice(1);
        }

        var answer = "",
            i = 2,
            input = parseInt(translateNumber.getElementsByTagName("input")[0].value, 10),
            inputTmp = input,
            digits = [],
            dictOnes = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"],
            dictTeens = ["", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"],
            dictTens = ["ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];

        if (isNumber(input) && input < 1000) {
            // Input number to digits array.
            do {
                digits[i] = inputTmp % 10;
                inputTmp /= 10;
                inputTmp = Math.floor(inputTmp);
                i--;
            } while (inputTmp > 0);
            // Build answer.
            if (input < 10) {
                answer += dictOnes[digits[2]];
            } else if (input > 10 && input < 20) {
                answer += dictTeens[digits[2]];
            } else if ((input === 10 || input > 20) && input < 100) {
                if (input % 10 === 0) {
                    answer += dictTens[digits[1] - 1];
                } else {
                    answer += dictTens[digits[1] - 1] + " " + dictOnes[digits[2]];
                }
            } else if (input > 100) {
                if (input % 100 === 0) {
                    answer += dictOnes[digits[0]] + " hundred";
                } else if (input % 10 === 0) {
                    answer += dictOnes[digits[0]] + " hundred and " + dictTens[digits[1] - 1];
                } else {
                    answer += dictOnes[digits[0]] + " hundred and ";
                    if (digits[1] > 1) {
                        answer += dictTens[digits[1] - 1] + " " + dictOnes[digits[2]];
                    } else if (digits[1] > 0) {
                        answer += dictTeens[digits[2]];
                    } else {
                        answer += dictOnes[digits[2]];
                    }
                }
            }

            answer = capitaliseFirstLetter(answer);
            printResult(translateNumber, answer);
        } else {
            alert("Incorrect input!");
        }
    };
};