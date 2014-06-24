/*************************************************************
 * Write a script that creates 5 div elements and moves 
them in circular path with interval of 100 milliseconds
 ************************************************************/
/*jslint browser: true*/
window.onload = function() {
    'use strict';
    var rotationAngle = 0;
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
        positionX = getRandomInt(50, 500) + 'px';
        positionY = getRandomInt(50, 300) + 'px';
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

    function rotateDivs() {
        var angle = rotationAngle % 360,
            radians = 0,
            i = 0,
            x = 0, // x = a + r * cos t
            y = 0, // y = b + r * sin t 
            divElements = document.getElementsByTagName('div');

        radians = angle * Math.PI / 180;
        for (i = divElements.length - 1; i >= 0; i--) {
            x = parseInt(divElements[i].style.left, 10);
            y = parseInt(divElements[i].style.top, 10);
            divElements[i].style.left = (x + 12 * Math.cos(radians)) + 'px';
            divElements[i].style.top = (y + 12 * Math.sin(radians)) + 'px';
        }

        rotationAngle += 5;
    }

    (function createDivs() {
        var i,
            generatedDiv = null,
            numberOfDivs = 5;

        for (i = 0; i < numberOfDivs; i++) {
            generatedDiv = generateDiv();
            document.body.appendChild(generatedDiv);
            generatedDiv = null;
        }
    }());

    setInterval(rotateDivs, 100);
};