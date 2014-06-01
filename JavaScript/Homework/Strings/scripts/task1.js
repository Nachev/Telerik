/*jslint browser: true*/
/*global alert, jsConsole */

/*1. Write a JavaScript function reverses string and returns it Example: "sample"  "elpmas". */
(function () {
    function reverseString(str) {
        var i,
            result = '';
        for (i = str.length - 1; i >= 0; i--) {
            result += str[i];
        }

        return result;
    }

    var sampleString = 'sample';
    jsConsole.writeLine(sampleString + ' reversed is ' + reverseString(sampleString));
}());