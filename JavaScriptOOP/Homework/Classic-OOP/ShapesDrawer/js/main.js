window.onload = function standartOOP() {
    var drawShape = function drawShape() {
        var canvas = document.getElementById('the-canvas'),
            ctx = null,
            rect = null,
            circle = null,
            line = null;

        if (canvas.getContext) {
            ctx = canvas.getContext('2d');
        } else {
            throw Error("There is no canvas element in the HTML.");
        }

        var rect = function rect(posX, posY, width, height) {
            ctx.beginPath();
            ctx.fillRect(posX, posY, width, height);
            ctx.stroke();
        }

        var circle = function circle(posX, posY, radius) {
            ctx.beginPath();
            ctx.arc(posX, posY, radius, 0, Math.PI * 2, true);
            ctx.stroke();
        }

        var line = function line(startPosX, startPosY, endPosX, endPosY) {
            ctx.beginPath();
            ctx.moveTo(startPosX, startPosY);
            ctx.lineTo(endPosX, endPosY);
            ctx.stroke();
        }

        return {
            rect: rect,
            circle: circle,
            line: line
        };
    }();

    drawShape.rect(10, 20, 50, 60);
    drawShape.circle(70, 230, 50);
    drawShape.line(20, 50, 392, 94);
};