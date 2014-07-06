/*jslint browser: true*/
var gameManager = (function () {
    'use strict';
    var CELL_SIZE = 10,
        cellCountWidth,
        cellCountHeight,
        canvas,
        canvasContext,
        snake,
        apple,
        border,
        obstacles,
        currentDirection,
        controlAllowed,
        directions,
        gameInterval;

    var doRectCollide = function doRectCollide(firstRect, secondRect) {
        var outsideBottom,
            outsideTop,
            outsideLeft,
            outsideRight;

        outsideBottom = firstRect.y + firstRect.height < secondRect.y;
        outsideTop = firstRect.y > secondRect.y + secondRect.height;
        outsideLeft = firstRect.x > secondRect.x + secondRect.width;
        outsideRight = firstRect.x + secondRect.width < secondRect.x;

        return !(outsideBottom || outsideTop || outsideLeft || outsideRight);
    };

    var checkSnakeCollision = function (currentObjectBox) {
        var i,
            len,
            segmentBox,
            doSegmentCollide;

        for (i = 0, len = snake._body.length; i < snake._body.length; i += 1) {
            segmentBox = {
                x: snake._body[i].x,
                y: snake._body[i].y,
                width: snake.SEGMENT_RADIUS * 2,
                height: snake.SEGMENT_RADIUS * 2
            };

            doSegmentCollide = doRectCollide(currentObjectBox, segmentBox);
            if (doSegmentCollide) {
                return true;
            }
        }

        return false;
    };

    var doObjectCollide = function (currentObjectBox, checkSnakeCollision) {
        var isOverSnake,
            isOverBorder,
            isOverObstacle;

        if (checkSnakeCollision) {
            isOverSnake = checkSnakeCollision(currentObjectBox);
        } else {
            isOverSnake = false;
        }

        isOverBorder = (
            currentObjectBox.x < border.width ||
            currentObjectBox.y < border.width ||
            currentObjectBox.x + currentObjectBox.width > canvas.width - border.width ||
            currentObjectBox.y + currentObjectBox.height > canvas.height - border.width
            );

        isOverObstacle = function () {
            var currentObstacle;

            for (var i = 0; i < obstacles.length; i++) {
                currentObstacle = obstacles[i];
                if (doRectCollide(currentObstacle._box, currentObjectBox)) {
                    return true;
                }
            }

            return false;
        };

        return isOverSnake || isOverBorder || isOverObstacle();
    };

    var randomGenerator = function (max, min) {
        min = min || 0;
        return Math.floor(Math.random() * (max - min + 1)) + min;
    };

    var onKeyDownHandler = function (e) {
        e = e || event;
        if (controlAllowed) {
            switch (e.keyCode) {
                case 37: // left
                    if (currentDirection !== directions[2]) {
                        currentDirection = directions[0];
                        controlAllowed = false;
                    }
                    return;
                case 38: // up
                    if (currentDirection !== directions[3]) {
                        currentDirection = directions[1];
                        controlAllowed = false;
                    }
                    return;
                case 39: // right
                    if (currentDirection !== directions[2]) {
                        currentDirection = directions[2];
                        controlAllowed = false;
                    }
                    return;
                case 40: // down
                    if (currentDirection !== directions[1]) {
                        currentDirection = directions[3];
                        controlAllowed = false;
                    }
                    return;
                case 27: // exit
                    clearInterval(gameInterval);
                    return;
            }
        }
    };

    var generateNewApple = function () {
        var resultApple;

        do {
            resultApple = new gameObjects.Apple(
                    randomGenerator(cellCountWidth - 1, 1) * CELL_SIZE,
                    randomGenerator(cellCountHeight - 1, 1) * CELL_SIZE
            );
        } while(doObjectCollide(resultApple._box, checkSnakeCollision));

        return resultApple;
    };

    var initialize = function () {
        var MAX_NUMBER_OF_OBSTACLES = 20,
            MAX_NUMBER_OF_CHAINED_OBSTACLES = 3;

        controlAllowed = true;
        directions = ['left', 'up', 'right', 'down'];
        currentDirection = directions[2];
        canvas = document.getElementById('the-canvas');
        canvasContext = canvas.getContext('2d');
        cellCountWidth = canvas.width / CELL_SIZE;
        cellCountHeight = canvas.height / CELL_SIZE;
        border = gameObjects.border;
        snake = gameObjects.snake;
        obstacles = [];
        obstacles = (function () {
            var i,
                len,
                newObstacle,
                result;

            result = [];
            for (i = 0, len = randomGenerator(MAX_NUMBER_OF_OBSTACLES - 5) + 5; i < len; i++) {
                do {
                    newObstacle = new gameObjects.Obstacle(
                        randomGenerator(cellCountWidth - 1, 1) * CELL_SIZE,
                        randomGenerator(cellCountHeight - 1, 1) * CELL_SIZE,
                        randomGenerator(MAX_NUMBER_OF_CHAINED_OBSTACLES, 1),
                        randomGenerator(MAX_NUMBER_OF_CHAINED_OBSTACLES, 1)
                    );
                } while (doObjectCollide(newObstacle._box, checkSnakeCollision));

                result.push(newObstacle);
            }

            return result;
        }());
        apple = generateNewApple();

        document.body.addEventListener('keydown', onKeyDownHandler);
    };

    var update = function (initGameInterval) {
        var doSnakeHitObstacle,
            doSnakeEatApple,
            snakeHeadBox;

        gameInterval = initGameInterval;
        controlAllowed = true;
        snake.update(currentDirection);
        snakeHeadBox = snake.getHeadBox();
        doSnakeHitObstacle = doObjectCollide(snakeHeadBox);
        if (doSnakeHitObstacle) {
            // Dead
            console.log("Dead");
        }

        doSnakeEatApple = doRectCollide(snakeHeadBox, apple._box);

        if (doSnakeEatApple) {
            snake.eat();
            apple = generateNewApple();
        }
    };

    var draw = function () {
        displayManager.draw.call(border, canvasContext);
        displayManager.draw.call(snake, canvasContext);
        displayManager.draw.call(apple, canvasContext);
        for (var i = 0; i < obstacles.length; i++) {
            var currentObstacle = obstacles[i];
            displayManager.draw.call(currentObstacle, canvasContext);
        }
    };

    return {
        initialize: initialize,
        update: update,
        draw: draw
    }
}());