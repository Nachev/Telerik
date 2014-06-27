/*jslint browser: true*/
/*globals console*/
window.onload = function thirdTask() {
    'use strict';
    var specialConsole = (function specialConsole() {
        var format = null,
            writeLine = null,
            writeError = null,
            writeWarning = null;

        format = function format(input) {
            var strToPrint,
                placeholder,
                count = 0;

            strToPrint = input;
            if (arguments.length > 1) {
                placeholder = '{' + count + '}';
                while (strToPrint.indexOf(placeholder) >= 0) {
                    while (strToPrint.indexOf(placeholder) >= 0) {
                        strToPrint = strToPrint.replace(placeholder, arguments[count + 1].toString());
                    }

                    count += 1;
                    placeholder = '{' + count + '}';
                }
            }

            return strToPrint;
        };

        writeLine = function writeLine() {
            var strToPrint = format.apply(null, arguments);
            console.log(strToPrint);
        };

        writeError = function writeError() {
            var strToPrint = format.apply(null, arguments);
            console.error(strToPrint);
        };

        writeWarning = function writeWarning() {
            var strToPrint = format.apply(null, arguments);
            console.warn(strToPrint);
        };

        return {
            writeLine: writeLine,
            writeError: writeError,
            writeWarning: writeWarning
        };
    }());

    specialConsole.writeLine("Test {0}, test {0}, test {1}", "YYY", "XXX");
    specialConsole.writeError("Error {0}", 'something bad happened');
    specialConsole.writeWarning("Warning: Sample warning.");
};