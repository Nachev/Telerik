/*jslint browser: true*/
window.onload = function () {
    'use strict';
    var WIDTH = 800,
        HEIGHT = 600,
        stage = new Kinetic.Stage({
            container: 'canvas-container',
            width: WIDTH,
            height: HEIGHT
        }),
        layer = new Kinetic.Layer(),
        SKY_COLOR = "#72CDFF",
        imageObj = new Image(),
        paper = Raphael('svg-container', WIDTH, HEIGHT);

    function drawCloud(x, y, raphPaper) {
        var outline = raphPaper.path('M' + x + ' ' + y +
                ' Q' + (x + 30) + ' ' + (y - 35) + ' ' + (x + 70) + ' ' + (y - 1) +
                ' Q' + (x + 98) + ' ' + (y - 4) + ' ' + (x + 101) + ' ' + (y + 21) +
                ' C' + (x + 123) + ' ' + (y + 30) + ' ' + (x + 111) + ' ' + (y + 65) +
                ' ' + (x + 88) + ' ' + (y + 62) +
                ' Q' + (x + 71) + ' ' + (y + 76) + ' ' + (x + 54) + ' ' + (y + 68) +
                ' Q' + (x + 35) + ' ' + (y + 76) + ' ' + (x + 16) + ' ' + (y + 67) +
                ' C' + (x - 34) + ' ' + (y + 78) + ' ' + (x - 41) + ' ' + (y + 8) +
                ' ' + x + ' ' + y).attr({
                stroke: "#7DB2F5",
                fill: "#B5D8FE"
            }),
            innerLine = outline.clone();
        innerLine.attr({
            stroke: "none",
            fill: "#D4E9FF"
        });
        innerLine.transform('s 0.9,0.9');
    }

    function drawLand(raphPaper) {
        var block = raphPaper.image('sprite/Land.png', 0, 549, 64, 51),
            xOffset = 63,
            xCoord = xOffset;
        while (xCoord < WIDTH) {
            block.clone().transform('t' + xCoord + ',0');
            xCoord += xOffset;
        }
    }

    function drawBricks(x, y, raphPaper, count) {
        var block = raphPaper.image('sprite/Bricks.png', x, y, 64, 51),
            xOffset = 63,
            xCoord = xOffset,
            i;
        for (i = 1; i < count; i += 1) {
            xCoord = i * xOffset;
            block.clone().transform('t' + xCoord + ',0');
        }
    }

    imageObj.onload = function () {
        var sprite = new Kinetic.Sprite({
            x: 130,
            y: 460,
            image: imageObj,
            animation: 'moving',
            animations: {
                standing: [
                    // x, y, width, height
                    3, 245, 56, 92
                ],
                moving: [
                    // x, y, width, height
                    61, 245, 59, 92,
                    120, 245, 63, 92,
                    185, 245, 63, 92
                ]
            },
            frameRate: 4,
            frameIndex: 0,
        });

        layer.add(sprite);
        stage.add(layer);
        sprite.start();

        setInterval(function () {
            sprite.setX(sprite.attrs.x += 30);
            if (sprite.attrs.x > WIDTH) {
                sprite.attrs.x = 0;
            }
            sprite.attrs.animation = 'moving';
        }, 200);
    };

    imageObj.src = 'sprite/Mario.png';

    paper.rect(0, 0, paper.width, paper.height)
        .attr('fill', SKY_COLOR);

    drawLand(paper);

    drawCloud(50, 43, paper);
    drawCloud(90, 64, paper);
    drawCloud(250, 43, paper);
    drawCloud(550, 73, paper);

    drawBricks(320, 350, paper, 5);
};