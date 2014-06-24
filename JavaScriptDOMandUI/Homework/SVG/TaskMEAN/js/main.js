/*jslint browser: true*/
window.onload = function main() {
    'use strict';
    var MONGO_COLOR = "#3E3F37",
        EXPRESS_COLOR = "#231F20",
        ANGULAR_COLOR = "#E23337",
        NODE_COLOR = "#8EC74E",
        LABEL_X = 50,
        CIRCLES_X = LABEL_X + 103,
        CIRCLES_RADIUS = 52,
        FIRST_LETTER_Y = 62,
        FIRST_CIRCLE_Y = FIRST_LETTER_Y - 9,
        LETTER_DISTANCE = 58,
        svgNS = 'http://www.w3.org/2000/svg',
        svgWrapper = $('#svg-wrapper'),
        mouseDisplay = $('#mouse-monitor');

    // Helper function shows current mouse cursor coordinates;
    function mouseMovement(e) {
        setTimeout(function() {
            var x = e.pageX;
            var y = e.pageY;
            mouseDisplay.text("X: " + x + " Y: " + y);
        }, 300);
    }


    function createRect(ns, x, y, width, height, stroke, fill) {
        var rect = null;

        rect = document.createElementNS(ns, 'rect');
        rect.setAttribute('x', x);
        rect.setAttribute('y', y);
        rect.setAttribute('width', width);
        rect.setAttribute('height', height);
        rect.setAttribute('stroke', stroke || 'black');
        rect.setAttribute('fill', fill || 'none');

        return rect;
    }

    function createCircle(ns, cx, cy, radius, fill, stroke) {
        var circle = null;

        circle = document.createElementNS(ns, 'circle');
        circle.setAttribute('cx', cx);
        circle.setAttribute('cy', cy);
        circle.setAttribute('r', radius);
        circle.setAttribute('fill', fill || 'none');
        circle.setAttribute('stroke', stroke || 'none');

        return circle;
    }

    function createPath(ns, points, strokeWidth) {
        var path = null;

        path = document.createElementNS(ns, 'path');
        path.setAttribute('d', points);
        path.setAttribute('stroke-width', strokeWidth || "5");

        return path;
    }

    function createText(ns, x, y, inputText, fontSize, fontFamily) {
        var DEFAULT_FONT_FAMILY = 'Arial',
            DEFAULT_FONT_SIZE = '36px',
            textElement = null,
            input = null;

        textElement = document.createElementNS(ns, 'text');
        input = document.createTextNode(inputText);
        textElement.setAttribute('x', x);
        textElement.setAttribute('y', y);
        textElement.setAttribute('font-size', fontSize || DEFAULT_FONT_SIZE);
        textElement.setAttribute('font-family', fontFamily || DEFAULT_FONT_FAMILY);
        textElement.appendChild(input);

        return textElement;
    }

    function createHexagon(ns, cx, cy, height, fill, strokeWidth) {
        var hexagon = null,
            points = null,
            generatedPoints = null;

        function generateHexagonPoints() {
            /*x = a + r * cos t
            y = b + r * sin t */
            var i = 0,
                angle = 30,
                pointX = null,
                pointY = null,
                radius = height / 2,
                result = [];

            for (i = 5; i >= 0; i--) {
                pointX = cx + radius * Math.cos(angle * Math.PI / 180);
                pointY = cy + radius * Math.sin(angle * Math.PI / 180);
                result.push(pointX, pointY);
                angle += 60;
            }

            return result;
        }

        generatedPoints = generateHexagonPoints();

        points = 'M' + generatedPoints[0] + ' ' + generatedPoints[1] +
            ' L' + generatedPoints[2] + ' ' + generatedPoints[3] +
            ' L' + generatedPoints[4] + ' ' + generatedPoints[5] +
            ' L' + generatedPoints[6] + ' ' + generatedPoints[7] +
            ' L' + generatedPoints[8] + ' ' + generatedPoints[9] +
            ' L' + generatedPoints[10] + ' ' + generatedPoints[11] + ' Z';

        hexagon = document.createElementNS(ns, 'path');
        hexagon.setAttribute('d', points);
        hexagon.setAttribute('fill', fill || "black");
        hexagon.setAttribute('stroke-width', strokeWidth || "1");

        return hexagon;
    }

    $(document).mousemove(mouseMovement);

    (function drawLabel() {
        $(createText(svgNS, LABEL_X, FIRST_LETTER_Y, 'M'))
            .css('stroke-width', "3.5")
            .css('stroke', MONGO_COLOR)
            .css('fill', MONGO_COLOR)
            .appendTo(svgWrapper);

        $(createText(svgNS, LABEL_X, FIRST_LETTER_Y + LETTER_DISTANCE, 'E'))
            .css('stroke-width', "3.5")
            .css('stroke', EXPRESS_COLOR)
            .css('fill', EXPRESS_COLOR)
            .appendTo(svgWrapper);

        $(createText(svgNS, LABEL_X, FIRST_LETTER_Y + 2 * LETTER_DISTANCE, 'A'))
            .css('stroke-width', "3.5")
            .css('stroke', ANGULAR_COLOR)
            .css('fill', ANGULAR_COLOR)
            .appendTo(svgWrapper);

        $(createText(svgNS, LABEL_X, FIRST_LETTER_Y + 3 * LETTER_DISTANCE, 'N'))
            .css('stroke-width', "3.5")
            .css('stroke', NODE_COLOR)
            .css('fill', NODE_COLOR)
            .appendTo(svgWrapper);
    }());

    (function drawMongoLogo() {
        var mPointX = CIRCLES_X,
            mPointY = FIRST_CIRCLE_Y - 30,
            leftQPointX = CIRCLES_X - CIRCLES_RADIUS / 1.5,
            rightQPointX = CIRCLES_X + CIRCLES_RADIUS / 1.5,
            qPointY = FIRST_CIRCLE_Y,
            ePointX = CIRCLES_X,
            ePointY = FIRST_CIRCLE_Y + 30;
        $(createCircle(svgNS, CIRCLES_X, FIRST_CIRCLE_Y, CIRCLES_RADIUS, MONGO_COLOR))
            .appendTo(svgWrapper);
        $(createPath(svgNS, 'M' + mPointX + ' ' + mPointY + ' Q' + leftQPointX + ' ' + qPointY + ' ' + ePointX + ' ' + ePointY + ' Z'))
            .css('fill', "#5EB14A")
            .appendTo(svgWrapper);
        $(createPath(svgNS, 'M' + mPointX + ' ' + mPointY + ' Q' + rightQPointX + ' ' + qPointY + ' ' + ePointX + ' ' + ePointY + ' Z'))
            .css('fill', "#449644")
            .appendTo(svgWrapper);
    }());

    (function drawExpressLogo() {
        $(createCircle(svgNS, CIRCLES_X, FIRST_CIRCLE_Y + 53, CIRCLES_RADIUS, EXPRESS_COLOR))
            .appendTo(svgWrapper);
        $(createText(svgNS, CIRCLES_X - 45, FIRST_CIRCLE_Y + 62, 'express', '24px', 'Consolas'))
            .css('fill', "white")
            .css('stroke', "white")
            .css('stroke-width', "0.5")
            .appendTo(svgWrapper);
    }());

    (function drawAngularLogo() {
        var logoMainX = CIRCLES_X,
            logoMainY = FIRST_CIRCLE_Y + 84;

        $(createCircle(svgNS, CIRCLES_X, FIRST_CIRCLE_Y + 114, CIRCLES_RADIUS, ANGULAR_COLOR))
            .appendTo(svgWrapper);
        $(createPath(svgNS, 'M' + logoMainX + ' ' + logoMainY +
            ' L' + (logoMainX - 31) + ' ' + (logoMainY + 11) +
            ' L' + (logoMainX - 26) + ' ' + (logoMainY + 52) +
            ' L' + logoMainX + ' ' + (logoMainY + 65) +
            ' L' + (logoMainX + 26) + ' ' + (logoMainY + 52) +
            ' L' + (logoMainX + 31) + ' ' + (logoMainY + 11) + ' Z'))
            .css('fill', ANGULAR_COLOR)
            .css('stroke', "#B3B3B3")
            .css('stroke-width', "3")
            .appendTo(svgWrapper);
        $(createPath(svgNS, 'M' + logoMainX + ' ' + (logoMainY + 2) +
            ' V' + (logoMainY + 63) +
            ' L' + (logoMainX + 25) + ' ' + (logoMainY + 51) +
            ' L' + (logoMainX + 30) + ' ' + (logoMainY + 12) + ' Z'))
            .css('fill', "#B63032")
            .css('stroke', "none")
            .css('stroke-width', "1")
            .appendTo(svgWrapper);
        $(createPath(svgNS, 'M' + logoMainX + ' ' + (logoMainY + 5) +
            ' L' + (logoMainX - 20) + ' ' + (logoMainY + 49) +
            ' H' + (logoMainX - 13) +
            ' L' + (logoMainX - 8) + ' ' + (logoMainY + 38) +
            ' H' + logoMainX +
            ' V' + (logoMainY + 33) +
            ' H' + (logoMainX - 6) +
            ' L' + logoMainX + ' ' + (logoMainY + 19) + ' Z'))
            .css('fill', "white")
            .css('stroke', "none")
            .css('stroke-width', "1")
            .appendTo(svgWrapper);
        $(createPath(svgNS, 'M' + logoMainX + ' ' + (logoMainY + 5) +
            ' L' + (logoMainX + 20) + ' ' + (logoMainY + 49) +
            ' H' + (logoMainX + 13) +
            ' L' + (logoMainX + 8) + ' ' + (logoMainY + 38) +
            ' H' + logoMainX +
            ' V' + (logoMainY + 33) +
            ' H' + (logoMainX + 6) +
            ' L' + logoMainX + ' ' + (logoMainY + 19) + ' Z'))
            .css('fill', "#B3B3B4")
            .css('stroke', "none")
            .css('stroke-width', "1")
            .appendTo(svgWrapper);
    }());

    (function drawNodeLogo() {
        var LOGO_COLOR = '#47493F';

        $(createCircle(svgNS, CIRCLES_X, FIRST_CIRCLE_Y + 168, CIRCLES_RADIUS, NODE_COLOR))
            .appendTo(svgWrapper);

        // N
        $(createHexagon(svgNS, (CIRCLES_X - 34), FIRST_CIRCLE_Y + 168, 20, LOGO_COLOR))
            .appendTo(svgWrapper);
        $(createHexagon(svgNS, (CIRCLES_X - 34), FIRST_CIRCLE_Y + 172, 20, LOGO_COLOR))
            .appendTo(svgWrapper);
        $(createHexagon(svgNS, (CIRCLES_X - 34), FIRST_CIRCLE_Y + 168, 7, NODE_COLOR))
            .appendTo(svgWrapper);
        $(createHexagon(svgNS, (CIRCLES_X - 34), FIRST_CIRCLE_Y + 171, 7, NODE_COLOR))
            .appendTo(svgWrapper);
        $(createHexagon(svgNS, (CIRCLES_X - 34), FIRST_CIRCLE_Y + 181, 21, NODE_COLOR))
            .appendTo(svgWrapper);

        // O
        $(createHexagon(svgNS, (CIRCLES_X - 11), FIRST_CIRCLE_Y + 168, 20, 'white'))
            .appendTo(svgWrapper);

        // D
        $(createHexagon(svgNS, (CIRCLES_X + 11), FIRST_CIRCLE_Y + 168, 20, LOGO_COLOR))
            .appendTo(svgWrapper);
        $(createHexagon(svgNS, (CIRCLES_X + 11), FIRST_CIRCLE_Y + 168, 7, NODE_COLOR))
            .appendTo(svgWrapper);
        $(createPath(svgNS, 'M' + (CIRCLES_X + 14) + ' ' + (FIRST_CIRCLE_Y + 165) +
            ' V' + (FIRST_CIRCLE_Y + 144) +
            ' L' + (CIRCLES_X + 19.7) + ' ' + (FIRST_CIRCLE_Y + 148) +
            ' V' + (FIRST_CIRCLE_Y + 173) + ' Z'))
            .css('fill', LOGO_COLOR)
            .appendTo(svgWrapper);

        // E
        $(createHexagon(svgNS, (CIRCLES_X + 34), FIRST_CIRCLE_Y + 168, 20, LOGO_COLOR))
            .appendTo(svgWrapper);
        $(createHexagon(svgNS, (CIRCLES_X + 34), FIRST_CIRCLE_Y + 168, 7, NODE_COLOR))
            .appendTo(svgWrapper);
        $(createHexagon(svgNS, (CIRCLES_X + 34), FIRST_CIRCLE_Y + 168, 4, 'white'))
            .appendTo(svgWrapper);
        (function() {
            var x1 = (CIRCLES_X + 34) + 3.5 * Math.cos(0.5 * Math.PI),
                y1 = (FIRST_CIRCLE_Y + 168) + 3.5 * Math.sin(0.5 * Math.PI),
                x2 = (CIRCLES_X + 43) + 3 * Math.cos(1.5 * Math.PI),
                y2 = (FIRST_CIRCLE_Y + 168) + 3 * Math.sin(1.5 * Math.PI),
                x3 = (CIRCLES_X + 45) + 10 * Math.cos(0.5 * Math.PI),
                y3 = (FIRST_CIRCLE_Y + 168) + 10 * Math.sin(0.5 * Math.PI);

            console.log(x1, y1);

            $(createPath(svgNS, 'M' + x1 + ' ' + y1 +
                ' L' + x2 + ' ' + y2 +
                ' L' + x3 + ' ' + y3 + ' Z'))
                .css('fill', NODE_COLOR)
                .appendTo(svgWrapper);
        }());
    }());
};