/*jslint browser: true*/
/*global jsConsoleWriteLine*/

var nullVariable = null,
  undefinedVariable = undefined;
jsConsoleWriteLine("4.Create null, undefined variables and try typeof on them.");
jsConsoleWriteLine("nullVariable: " + typeof nullVariable);
jsConsoleWriteLine("undefinedVariable: " + typeof undefinedVariable);
jsConsoleWriteLine();