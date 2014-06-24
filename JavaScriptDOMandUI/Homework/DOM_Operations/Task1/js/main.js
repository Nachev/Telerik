/*************************************************************
 * Write a script that creates a number of div elements. 
Each div element must have the following:
- Random width and height between 20px and 100px
- Random background color
- Random font color
- Random position on the screen (position:absolute)
- A strong element with text "div" inside the div
- Random border radius
- Random border color
- Random border width between 1px and 20px
 ************************************************************/
/*jslint browser: true*/
window.onload = function() {
    'use strict';
    var input = document.getElementById('input'),
        button = document.getElementById('button'),
        inputValue = null;
    // Returns a random integer between min and max
    // Using Math.round() will give you a non-uniform distribution!
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function getRandomColor() {
        return 'rgb(' + getRandomInt(0, 255) + ', ' +
            getRandomInt(0, 255) + ', ' + getRandomInt(0, 255) + ')';
    }

    function generateDiv() {
        var width = null,
            height = null, // between 20px and 100px
            backgroundColor = null,
            fontColor = null,
            positionX = null,
            positionY = null, //(position:absolute)
            borderRadius = null,
            borderColor = null,
            borderWidth = null,
            resultDiv = null,
            TEXT = 'div',
            innerContent = null; // between 1px and 20px

        width = getRandomInt(20, 100);
        height = getRandomInt(20, 100);
        backgroundColor = getRandomColor();
        fontColor = getRandomColor();
        positionX = getRandomInt(0, window.innerWidth) + 'px';
        positionY = getRandomInt(0, window.innerHeight) + 'px';
        borderRadius = getRandomInt(0, width) + 'px ' +
            getRandomInt(0, width) + 'px';
        borderColor = getRandomColor();
        borderWidth = getRandomInt(1, 20) + 'px';

        innerContent = document.createElement('strong');
        innerContent.innerHTML = TEXT;

        resultDiv = document.createElement('div');
        resultDiv.style.width = width + 'px';
        resultDiv.style.height = height + 'px';
        resultDiv.style.backgroundColor = backgroundColor;
        resultDiv.style.color = fontColor;
        resultDiv.style.position = 'absolute';
        resultDiv.style.left = positionX;
        resultDiv.style.top = positionY;
        resultDiv.style.borderRadius = borderRadius;
        resultDiv.style.border = borderWidth + ' solid ' + borderColor;
        resultDiv.appendChild(innerContent);

        return resultDiv;
    }

    function createDivs() {
        var i,
            generatedDiv = null,
            inputValue = null,
            numberOfDivs = null;

        inputValue = input.value;
        numberOfDivs = parseInt(inputValue, 10); // || 10;
        //numberOfDivs = numberOfDivs > 10 ? 10 : numberOfDivs;
        for (i = 0; i < numberOfDivs; i++) {
            generatedDiv = generateDiv();
            document.body.appendChild(generatedDiv);
            generatedDiv = null;
        }
    }

    button.addEventListener('click', createDivs);
};