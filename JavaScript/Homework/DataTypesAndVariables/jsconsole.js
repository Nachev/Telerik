/*jslint browser: true*/
var consoleElement = document.createElement("div");
consoleElement.id = "console";
consoleElement.style.height = "700px";
consoleElement.style.width = "1024px";
consoleElement.style.fontFamily = "Consolas, monaco, monospace";
consoleElement.style.backgroundColor = "black";
consoleElement.style.color = "white";
document.body.appendChild(consoleElement);

function jsConsoleWriteLine(inputText) {
  var paragraph = document.createElement("p");
  if (inputText === null || inputText === undefined) {
    inputText = "";
    paragraph.style.height = "10px";
  }
  var text = document.createTextNode(inputText);
  paragraph.appendChild(text);
  paragraph.style.margin = "5px 0 0 5px";
  document.getElementById("console").appendChild(paragraph);
}