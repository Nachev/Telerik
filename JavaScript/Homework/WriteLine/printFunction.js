function Global() {

   function Write(element) {
        var result = element;
        var container = document.getElementById("conteiner");
        var node = document.getElementById("write").cloneNode(true);
        document.body.appendChild(node);
        return node.innerHTML = result.toString();
    }
    function WriteLine(element) {
        var result = element;
        var container = document.getElementById("conteiner");
        var node = document.getElementById("writeLine").cloneNode(true);
        document.body.appendChild(node);
        return node.innerHTML = result.toString();
    }
    //---------------------------------------------------------------------------
    //test the Write() and WriteLine() functions
    var intNumber = 33333;
    var stringVar = "Test string";
    Write(stringVar);
    Write(", " + intNumber)
    WriteLine("Telerik");
    Write(true);
    Write(" reallyyyyyy");
    //--------------------------------------



}