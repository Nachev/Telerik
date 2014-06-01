function Solve(input) {
    var currentNumb = '',
        expression = input,
        method = {},
        methodName = '',
        numbersArr = [],
        output = 0,
        symCount = 0,
        symbol,
        sumFlag = false,
        subFlag = false,
        multFlag = false,
        divFlag = false,
        defFlag = false;

    function isNumber(n) {
        return !isNaN(n - 0) && isFinite(n) && n !== null && n !== '' && n !== false && n !== ' ';
    }

    function sum(args) {
        var i,
            result = 0;
        for (i = 0; i < args.length; i += 1) {
            result += args[i];
        }

        return result;
    }

    function subtract(args) {
        var i,
            result = args[0];
        for (i = 1; i < args.length; i += 1) {
            result -= args[i];
        }

        return result;
    }

    function multiply(args) {
        var i,
            result = 1;
        for (i = 0; i < args.length; i += 1) {
            result *= args[i];
        }

        return result;
    }

    function divide(args) {
        var i,
            result = args[0];
        for (i = 1; i < args.length; i += 1) {
            result /= args[i];
            result = parseInt(result, 10);
        }

        return result;
    }

    function toggleFlag(flag) {
        return !flag;
    }

    function doTheMath(numbers) {
        //console.log(numbers);
        if (numbers.length < 2) {
            return numbers[0];
        }
        if (sumFlag) {
            sumFlag = toggleFlag(sumFlag);
            return sum(numbers);
        }
        if (subFlag) {
            subFlag = toggleFlag(subFlag);
            return subtract(numbers);
        }
        if (multFlag) {
            multFlag = toggleFlag(multFlag);
            return multiply(numbers);
        }
        if (divFlag) {
            divFlag = toggleFlag(divFlag);
            return divide(numbers);
        }
        // TODO: More operations
    }

    function openingBracket() {
        return null;
    }

    while (true) {
        symbol = expression[symCount];
        //console.log(symbol);
        switch (symbol) {
        case undefined:
            //console.log('output: ' + output); 
            return output;
        case '+':
            sumFlag = toggleFlag(sumFlag);
            break;
        case '-':
            subFlag = toggleFlag(subFlag);
            break;
        case '*':
            multFlag = toggleFlag(multFlag);
            break;
        case '/':
            divFlag = toggleFlag(divFlag);
            break;
        case ')':
            if (currentNumb.length > 0) {
                numbersArr.push(parseInt(currentNumb, 10));
                //console.log('--' + numbersArr);
                currentNumb = '';
            }
            output = doTheMath(numbersArr);
            break;
        case '(':
            openingBracket();
            break;
        case 'd':
            if (expression.substr(symCount, 4) === 'def ') {
                toggleFlag(defFlag);
                break;
            }
        default:
            if (isNumber(symbol)) {
                //console.log(symbol);
                currentNumb += symbol;
                //console.log(currentNumb);
            } else if (symbol !== ' ') {
                methodName += symbol;
            } else if (defFlag) {
                method[methodName] = 0;
            } else if (symbol === ' ') {
                if (currentNumb.length > 0) {
                    numbersArr.push(parseInt(currentNumb, 10));
                    //console.log(numbersArr);
                    currentNumb = '';
                }
            }
        }

        symCount++;
    }
}

var testCase1 = '(+ 1 2) ',
    testCase2 = '(+ 5 2 7 1) ',
    testCase3 = '(- 4 2)',
    testCase4 = '(- 4) ',
    testCase5 = '(/ 2) ',
    testCase6 = '(* 5 7)',
    testCase7 = '(/ 10 3)',
    testCase8 = '(/ 10 3 2) ',
    testCase9 = '(/ 5 0)';
Solve(testCase9);