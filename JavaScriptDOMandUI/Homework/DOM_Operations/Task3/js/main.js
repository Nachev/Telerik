/*************************************************
 *Create a text area and two inputs with type="color"
 * Make the font color of the text area as the value of the
 *first color input
 * Make the background color of the text area as the
 *value of the second input
 **************************************************/
window.onload = function() {
    var fontColorSelector = document.getElementById('font-color'),
        bgColorSelector = document.getElementById('bg-color'),
        textArea = document.getElementById('txt-area');

    function changeFontColor() {
        textArea.style.color = fontColorSelector.value;
    }

    function changeBGColor() {
        textArea.style.backgroundColor = bgColorSelector.value;
    }

    fontColorSelector.addEventListener('change', changeFontColor)
    bgColorSelector.addEventListener('change', changeBGColor);
}