/*jslint browser: true*/
window.onload = function() {
    var theCanvas = document.getElementById("the-canvas"),
        ctx = theCanvas.getContext("2d"),
        LINES_WIDTH = 2,
        HAT_COLOR = '#3F6C98',
        FACE_BIKE_FILL_COLOR = '#95CDD9',
        FACE_BIKE_STROKE_COLOR = '#275A65';

    // Helper function shows current mouse cursor coordinates;
    document.onmousemove = function(e) {
        var x = e.pageX ;
        var y = e.pageY ;
        e.target.title = "X: " + x + " Y: " + y;
    };

    /*function drawEllipse(centerX, centerY, width, height, color) {

        ctx.beginPath();

        ctx.moveTo(centerX - (width / 2), centerY); // A1

        ctx.bezierCurveTo(
            centerX - width / 2,
            centerY - height / 2,
            centerX + width / 2,
            centerY - height / 2,
            centerX + width / 2,
            centerY
        );

        ctx.bezierCurveTo(
            centerX + width / 2,
            centerY + height / 2,
            centerX - width / 2,
            centerY + height / 2,
            centerX - width / 2,
            centerY
        );

        ctx.fillStyle = color;
        ctx.fill();
        ctx.stroke();
        ctx.closePath();

        return this;
    }

    function drawEllipsePoints(centerX, centerY, width, height, color) {
        //x = a * cos t; y = b * sin t; 0 < t < 2 * PI
        var angle = 0,
            x = 0, // x coordinate
            y = 0, // y coordinate
            a = width / 2, // half width
            b = height / 2, // half height
            endAngle = 2 * Math.PI; // 360 degrees in radians

        ctx.beginPath();

        ctx.moveTo(centerX + a, centerY); // A1

        while (angle <= endAngle) {
            x = a * Math.cos(angle) + centerX;
            y = b * Math.sin(angle) + centerY;
            ctx.lineTo(x, y);
            angle += 0.01;
        }

        ctx.fillStyle = color;
        ctx.closePath();
        ctx.fill();
        ctx.stroke();

        return this;
    }*/

    function drawEllipse(context, centerX, centerY, width, height, fillColor, strokeColor) {
        var radius = width > height ? width / 2 : height / 2,
            xScale = 1,
            yScale = 1,
            newCenterX = 0,
            newCenterY = 0;

        context.save();
        context.beginPath();
        context.lineWidth = LINES_WIDTH;

        // Calculate scaling
        xScale = (width / height) > 1 ? 1 : (width / height);
        yScale = (height / width) > 1 ? 1 : (height / width);

        // Calculate new center
        newCenterX = centerX * (1 - xScale);
        newCenterY = centerY * (1 - yScale);

        context.translate(newCenterX, newCenterY); // Removes the effect of jumping of the object while scaling.
        context.scale(xScale, yScale);

        context.arc(centerX, centerY, radius, 0, Math.PI * 2, false);
        context.closePath();

        context.fillStyle = fillColor;
        context.fill();

        context.strokeStyle = strokeColor;
        context.stroke();

        context.restore();

        return this;
    }

    ctx.lineWidth = LINES_WIDTH; // All lines width;

    (function drawFace() {
        drawEllipse(ctx, 141, 255, 145, 128, FACE_BIKE_FILL_COLOR, FACE_BIKE_STROKE_COLOR); // draws face oval
        drawEllipse(ctx, 97, 233, 24, 16, FACE_BIKE_FILL_COLOR, FACE_BIKE_STROKE_COLOR); // left eye
        drawEllipse(ctx, 92, 233, 6, 12, FACE_BIKE_STROKE_COLOR, FACE_BIKE_STROKE_COLOR); // left eye iris
        drawEllipse(ctx, 153, 233, 24, 16, FACE_BIKE_FILL_COLOR, FACE_BIKE_STROKE_COLOR); // right eye
        drawEllipse(ctx, 148, 233, 6, 12, FACE_BIKE_STROKE_COLOR, FACE_BIKE_STROKE_COLOR); // right eye iris

        // Draw nose
        ctx.beginPath();
        ctx.moveTo(124, 232);
        ctx.lineTo(109, 265);
        ctx.lineTo(124, 265);
        ctx.strokeStyle = FACE_BIKE_STROKE_COLOR;
        ctx.stroke();

        // Draw mouth
        ctx.moveTo(153, 293);
        //setTransform(X_scale, X_skew, Y_skew, Y_scale, dx, dy)
        ctx.save();
        ctx.transform(1, 0.18, 0, 0.28, 0, 185);
        ctx.arc(125, 288, 28, 0, Math.PI * 2, false);
        ctx.stroke();
        ctx.restore();

        // Draw hat
        ctx.strokeStyle = 'black';
        drawEllipse(ctx, 134, 198, 160, 29, HAT_COLOR, 'black'); // draws hat bottom
        drawEllipse(ctx, 141, 110, 85, 30, HAT_COLOR, 'black'); // draws hat top

        ctx.lineTo(183, 189);
        ctx.bezierCurveTo(168, 205, 116, 205, 98, 189);
        ctx.lineTo(98, 110);
        ctx.fillStyle = HAT_COLOR;
        ctx.fill();
        ctx.stroke();
    }());

    (function drawBicycle() {
        ctx.beginPath();

        ctx.strokeStyle = FACE_BIKE_STROKE_COLOR;

        // Draw pedals
        ctx.moveTo(155, 451);
        ctx.lineTo(197, 500);
        ctx.stroke();

        // Draw crankset
        ctx.beginPath();
        ctx.arc(177, 475, 18, 0, Math.PI * 2, false);
        ctx.fillStyle = 'white';
        ctx.fill();
        ctx.stroke();

        // Draw left wheel
        ctx.beginPath();
        ctx.arc(73, 476, 60, 0, Math.PI * 2, false);
        ctx.fillStyle = FACE_BIKE_FILL_COLOR;
        ctx.fill();
        ctx.stroke();

        // Draw right wheel
        ctx.beginPath();
        ctx.arc(301, 479, 60, 0, Math.PI * 2, false);
        ctx.fillStyle = FACE_BIKE_FILL_COLOR;
        ctx.fill();

        // Draw frame
        ctx.moveTo(102, 375);
        ctx.lineTo(150, 375);
        ctx.moveTo(127, 375);
        ctx.lineTo(178, 474);
        ctx.lineTo(73, 476);
        ctx.moveTo(73, 476);
        ctx.lineTo(144, 404);
        ctx.lineTo(288, 403);
        ctx.moveTo(288, 403);
        ctx.lineTo(177, 475);

        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(234, 377);
        ctx.lineTo(280, 361);
        ctx.lineTo(312, 324);
        ctx.moveTo(280, 361);
        ctx.lineTo(300, 474);

        ctx.stroke();
        ctx.closePath();
    }());

    (function drawHouse() {
        var HOUSE_COLOR = '#9C6161';

        function drawWindow(topLeftX, topLeftY) {
            var WINDOW_WIDTH = 101,
                WINDOW_HEIGHT = 67,
                WINDOW_FRAME_WIDTH = 2,
                horizontalFrameX = topLeftX,
                horizontalFrameY = topLeftY + WINDOW_HEIGHT / 2,
                verticalFrameX = topLeftX + WINDOW_WIDTH / 2,
                verticalFrameY = topLeftY;

            ctx.beginPath();
            ctx.rect(topLeftX, topLeftY, WINDOW_WIDTH, WINDOW_HEIGHT);
            ctx.fillStyle = 'black';

            ctx.fill();
            ctx.closePath();

            ctx.beginPath();
            ctx.lineWidth = WINDOW_FRAME_WIDTH;
            ctx.moveTo(horizontalFrameX, horizontalFrameY);
            ctx.lineTo(horizontalFrameX + WINDOW_WIDTH, horizontalFrameY);
            ctx.moveTo(verticalFrameX, verticalFrameY);
            ctx.lineTo(verticalFrameX, verticalFrameY + WINDOW_HEIGHT);
            ctx.strokeStyle = HOUSE_COLOR;

            ctx.stroke();
            ctx.closePath();
        }

        ctx.beginPath();
        ctx.strokeStyle = '#000000';
        ctx.fillStyle = HOUSE_COLOR;
        ctx.rect(489, 222, 289, 216);
        ctx.lineTo(633, 62);
        ctx.lineTo(778, 222);

        ctx.fill();
        ctx.stroke();

        // Draw chimney
        ctx.beginPath();
        ctx.moveTo(689, 182);
        ctx.lineTo(689, 101);
        ctx.moveTo(722, 101);
        ctx.lineTo(722, 182);
        ctx.stroke();

        ctx.rect(690, 101, 31, 73);
        ctx.fillStyle = HOUSE_COLOR;
        ctx.fill();

        drawEllipse(ctx, 705.5, 101, 33, 10, HOUSE_COLOR, 'black');
        ctx.closePath();

        // Draw windows
        drawWindow(511, 249);
        drawWindow(651, 249);
        drawWindow(651, 338);

        // Draw door
        ctx.beginPath();
        ctx.strokeStyle = 'black';
        ctx.moveTo(521, 438);
        ctx.lineTo(521, 366);
        ctx.bezierCurveTo(525, 331, 595, 331, 601, 366);
        ctx.lineTo(601, 438);
        ctx.moveTo(561, 340);
        ctx.lineTo(561, 437);
        ctx.stroke();

        ctx.beginPath();
        ctx.strokeStyle = 'black';
        ctx.arc(550, 408, 5, 0, Math.PI * 2, false);
        ctx.stroke();

        ctx.beginPath();
        ctx.strokeStyle = 'black';
        ctx.arc(572, 408, 5, 0, Math.PI * 2, false);
        ctx.stroke();
    }());
};