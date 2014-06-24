/*jslint browser: true*/
window.onload = function main() {
    'use strict';
    var svgNS = 'http://www.w3.org/2000/svg',
        svgWrapper = $('#svg-wrapper'),
        mouseDisplay = $('#mouse-monitor'),
        PADDING_LEFT = 75,
        PADDING_TOP = 115,
        SMALL_ICON_WIDTH = 75,
        BIG_ICON_WIDTH = 157,
        ICON_HEIGHT = 75,
        ICON_SPACE = 6;

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
        var DEFAULT_FONT_FAMILY = 'Segoe UI',
            DEFAULT_FONT_SIZE = 36,
            textElement = null,
            input = null;

        textElement = document.createElementNS(ns, 'text');
        input = document.createTextNode(inputText);
        textElement.setAttribute('x', x);
        textElement.setAttribute('y', y);
        textElement.setAttribute('font-size', (fontSize || DEFAULT_FONT_SIZE) + "px");
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

    function insertImage(ns, x, y, path, width, height) {
        // <image width="75" height="67" xlink:href="Pinball.png" id="image3013" x="0" y="0"/>
        var image = null;

        image = document.createElementNS(ns, "image");
        image.setAttribute('width', width);
        image.setAttribute('height', height);
        image.setAttributeNS('http://www.w3.org/1999/xlink', 'href', path);
        image.setAttribute('x', x);
        image.setAttribute('y', y);

        return image;
    }

    $(document).mousemove(mouseMovement);
    $(svgWrapper).css('background-color', '#001941');

    (function drawBackground() {
        $(createPath(svgNS, 'M' + 0 + ' ' + 80 +
            ' C' + 80 + ' ' + 87 +
            ' ' + 177 + ' ' + 169 +
            ' ' + 309 + ' ' + 117 +
            ' S' + 358 + ' ' + 0 +
            ' ' + 358 + ' ' + -50, '1'))
            .css('fill', "none")
            .css('stroke', "rgba(255, 255, 255, 0.2)")
            .appendTo(svgWrapper);

        $(createPath(svgNS, 'M' + 381 + ' ' + 504 +
            ' C' + 322 + ' ' + 440 +
            ' ' + 438 + ' ' + 373 +
            ' ' + 543 + ' ' + 457 +
            ' S' + 696 + ' ' + 478 +
            ' ' + 805 + ' ' + 430, '1'))
            .css('fill', "none")
            .css('stroke', "rgba(255, 255, 255, 0.2)")
            .appendTo(svgWrapper);
    }());

    (function drawHeader() {
        $(createText(svgNS, PADDING_LEFT, 62, 'Start'))
            .css('fill', "rgba(255, 255, 255, 0.7)")
            .appendTo(svgWrapper);

        $(createText(svgNS, 693, 49, 'Richard', 17))
            .css('fill', "rgba(255, 255, 255, 0.7)")
            .appendTo(svgWrapper);

        $(createText(svgNS, 727, 62, 'Perry', 10))
            .css('fill', "rgba(255, 255, 255, 0.7)")
            .appendTo(svgWrapper);

        $(insertImage(svgNS, 753, 36,
            'img/User.png', 26, 25))
            .appendTo(svgWrapper);
    }());

    (function drawIcons() {
        var i = null,
            col = [],
            row = [],
            secondSetX = 590 - PADDING_LEFT,
            labelOffsetX = 10,
            labelOffsetY = 70;

        // Generate columns X coord
        for (i = 0; i < 6; i++) {
            col.push(PADDING_LEFT + i * (SMALL_ICON_WIDTH + ICON_SPACE));
            row.push(PADDING_TOP + i * (ICON_HEIGHT + ICON_SPACE));
        };

        // Store
        $(createRect(svgNS,
            col[0],
            row[0],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#2D86EE"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[0], row[0],
            'img/Icons/store.png', 75, 67))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[0] + labelOffsetX,
            row[0] + labelOffsetY,
            'Store', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // XBox
        $(createRect(svgNS,
            col[1],
            row[0],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#5AA817"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[1], row[0],
            'img/Icons/games.png', 75, 67))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[1] + labelOffsetX,
            row[0] + labelOffsetY,
            'Xbox LIVE Games', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Photos
        $(createRect(svgNS,
            col[2],
            row[0],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#AE1941"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[2], row[0],
            'img/Icons/photos.png', 156, 75))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[2] + labelOffsetX,
            row[0] + labelOffsetY,
            'Photos', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Calendar
        $(createRect(svgNS,
            col[4],
            row[0],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#009A18"))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[4] + labelOffsetX,
            row[0] + labelOffsetY,
            'Calendar', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[4] + 107,
            row[0] + 40,
            '12', 36))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[4] + 107,
            row[0] + 49,
            'Monday', 7))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Maps
        $(createRect(svgNS,
            col[0],
            row[1],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#5D3AB8"))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[0] + labelOffsetX,
            row[1] + labelOffsetY,
            'Maps', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // IE
        $(createRect(svgNS,
            col[1],
            row[1],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#2D86EE"))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[1] + labelOffsetX,
            row[1] + labelOffsetY,
            'Internet Explorer', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Mail
        $(createRect(svgNS,
            col[2],
            row[1],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#5D3AB8"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[2], row[1],
            'img/Icons/mail.png', 156, 75))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[2] + labelOffsetX,
            row[1] + labelOffsetY,
            'Mail', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Social
        $(createRect(svgNS,
            col[4],
            row[1],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#DB532D"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[4], row[1] + 45,
            'img/Icons/contacts.png', 35, 35))
            .appendTo(svgWrapper);

        // Video
        $(createRect(svgNS,
            col[0],
            row[2],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#DB532D"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[0], row[2],
            'img/Icons/video.png', 156, 75))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[0] + labelOffsetX,
            row[2] + labelOffsetY,
            'Video', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Calendar
        $(createRect(svgNS,
            col[2],
            row[2],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#009A18"))
            .appendTo(svgWrapper);

        // Pinball
        $(createRect(svgNS,
            col[4],
            row[2],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "white"))
            .appendTo(svgWrapper);

        // insertImage(ns, x, y, path, width, height)
        $(insertImage(svgNS, col[4], (row[2] + 7),
            'img/Pinball.png', 75, 68))
            .appendTo(svgWrapper);

        // Solitarie
        $(createRect(svgNS,
            col[5],
            row[2],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "white"))
            .appendTo(svgWrapper);

        $(createRect(svgNS,
            col[5],
            row[2] + 7,
            SMALL_ICON_WIDTH,
            ICON_HEIGHT - 7,
            "none", "#2D86EE"))
            .appendTo(svgWrapper);

        // Desktop
        $(createRect(svgNS,
            col[0],
            row[3],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#0D757E"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[0], row[3],
            'img/DesktopFish.png', 156, 75))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[0] + labelOffsetX,
            row[3] + labelOffsetY,
            'Desctop', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Weather
        $(createRect(svgNS,
            col[2],
            row[3],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#2D86EE"))
            .appendTo(svgWrapper);

        // Camera
        $(createRect(svgNS,
            col[4],
            row[3],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#AE1941"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[4], row[3],
            'img/Icons/camera.png', 75, 67))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[4] + labelOffsetX,
            row[3] + labelOffsetY,
            'Camera', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Settings
        $(createRect(svgNS,
            col[5],
            row[3],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#5EA919"))
            .appendTo(svgWrapper);

        // Music
        $(createRect(svgNS,
            col[0] + secondSetX,
            row[0],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#5D3AB8"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[0] + secondSetX, row[0],
            'img/Icons/music.png', 156, 75))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[0] + secondSetX + labelOffsetX,
            row[0] + labelOffsetY,
            'Music', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Finance
        $(createRect(svgNS,
            col[0] + secondSetX,
            row[1],
            BIG_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#009A18"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[0] + secondSetX, row[1],
            'img/Icons/finance.png', 156, 75))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[0] + secondSetX + labelOffsetX,
            row[1] + labelOffsetY,
            'Finance', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Reader
        $(createRect(svgNS,
            col[0] + secondSetX,
            row[2],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#DB532D"))
            .appendTo(svgWrapper);

        $(insertImage(svgNS, col[0] + secondSetX, row[2],
            'img/Icons/reader.png', 75, 67))
            .appendTo(svgWrapper);

        $(createText(svgNS,
            col[0] + secondSetX + labelOffsetX,
            row[2] + labelOffsetY,
            'Reader', 8))
            .css('fill', "#FFF")
            .appendTo(svgWrapper);

        // Windows Explorer
        $(createRect(svgNS,
            col[1] + secondSetX,
            row[2],
            SMALL_ICON_WIDTH,
            ICON_HEIGHT,
            "none", "#002B6F"))
            .appendTo(svgWrapper);
    }());
};