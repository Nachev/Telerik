/*jslint browser: true*/
/*global jsConsoleWriteLine*/
var arrayLiteral = ["French Roast", "Colombian", "Kona"],
  numberLiteral = 42,
  booleanLiteral = true,
  floatLiteral = -42.1E12,
  objectLiteral = {
    myObject: "SampleObject",
    special: numberLiteral
  },
  stringLiteral = "some string";
jsConsoleWriteLine("1.Assign all the possible JavaScript literals to different variables:");
jsConsoleWriteLine("arrayLiteral = ['French Roast', 'Colombian', 'Kona'];");
jsConsoleWriteLine(arrayLiteral);
jsConsoleWriteLine("numberLiteral = 42,");
jsConsoleWriteLine(numberLiteral);
jsConsoleWriteLine("booleanLiteral = true,");
jsConsoleWriteLine(booleanLiteral);
jsConsoleWriteLine("floatLiteral = -42.1E12,");
jsConsoleWriteLine(floatLiteral);
jsConsoleWriteLine("objectLiteral = { myObject: 'SampleObject', special: numberLiteral };");
jsConsoleWriteLine(objectLiteral + " " + objectLiteral.myObject + " " + objectLiteral.special);
jsConsoleWriteLine("stringLiteral = 'some string';");
jsConsoleWriteLine(stringLiteral);
jsConsoleWriteLine();