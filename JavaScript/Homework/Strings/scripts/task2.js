/*jslint browser: true*/
/*global alert, jsConsole */

/*2. Write a JavaScript function to check if in a given expression the brackets 
are put correctly. 
Example of correct expression: ((a+b)/5-d). 
Example of incorrect expression: )(a+b)).*/
(function () {
    var incorrectExpression = ')(a+b))',
        correctExpression = '((a+b)/5-d)';

    function inspectBrackets(expression) {
        var i,
            openBracketCount = 0,
            closeBracketCount = 0;

        for (i = 0; i < expression.length; i++) {
            if (expression[i] === '(') {
                openBracketCount += 1;
            } else if (expression[i] === ')') {
                closeBracketCount += 1;
                if (openBracketCount === 0) {
                    return 'incorrect expression';
                }
            }
        }

        if (openBracketCount === closeBracketCount) {
            return 'correct expression';
        }

        return 'incorrect expression';
    }

    console.log(incorrectExpression + ' is ' + inspectBrackets(incorrectExpression));
    console.log(correctExpression + ' is ' + inspectBrackets(correctExpression));
}());