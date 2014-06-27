/*jslint browser: true*/
window.onload = function secondTask() {
    'use strict';
    var movingShapes = (function movingShapes() {
        var ELEMENT_WIDTH = 60,
            ELEMENT_HEIGHT = 45,
            STEP_PX = 2,
            STEP_ANGLE = 1,
            MAX_BORDER_RADIUS = 50,
            MAX_BORDER_WIDTH = 10,
            MIN_RANGE = 50,
            MAX_RANGE = 350,
            INTERVAL_DELAY = 20,
            rectMovement = null,
            maxTopPositionOffset = window.innerHeight / 2,
            maxLeftPositionOffset = window.innerWidth / 2,
            originDiv = null,
            generateNewMovingDiv = null,
            moveInShape = null,
            rectangularMovement = null,
            circularMovement = null,
            changeDirection = null;

        function getRandomInt(min, max) {
            return Math.floor(Math.random() * (max - min + 1)) + min;
        }

        function getRandomRGBColor() {
            var r = getRandomInt(0, 255),
                g = getRandomInt(0, 255),
                b = getRandomInt(0, 255);

            return 'rgb(' + r + ', ' + g + ', ' + b + ')';
        }

        generateNewMovingDiv = function generateNewMovingDiv(originDiv) {
            var newMovingDiv = originDiv.cloneNode(true);
            newMovingDiv.style.top = getRandomInt(0, maxTopPositionOffset) + 'px';
            newMovingDiv.style.left = getRandomInt(0, maxLeftPositionOffset) + 'px';
            newMovingDiv.style.backgroundColor = getRandomRGBColor();
            newMovingDiv.style.borderStyle = 'solid';
            newMovingDiv.style.borderWidth = getRandomInt(0, MAX_BORDER_WIDTH) + 'px';
            newMovingDiv.style.borderColor = getRandomRGBColor();
            newMovingDiv.style.borderRadius = getRandomInt(0, MAX_BORDER_RADIUS) + '%';

            return newMovingDiv;
        };

        (function initializeRectangularMovement() {
            rectMovement = rectMovement || {
                right: {
                    top: 0,
                    left: STEP_PX
                },
                down: {
                    top: STEP_PX,
                    left: 0
                },
                left: {
                    top: 0,
                    left: -STEP_PX
                },
                up: {
                    top: -STEP_PX,
                    left: 0
                }
            };

            changeDirection = function changeDirection(currentDirection) {
                if (currentDirection === 'right') {
                    return 'down';
                }
                if (currentDirection === 'down') {
                    return 'left';
                }
                if (currentDirection === 'left') {
                    return 'up';
                }
                if (currentDirection === 'up') {
                    return 'right';
                }

                throw new Error('Direction is not recognized!');
            };
        }());

        rectangularMovement = function rectangularMovement(element) {
            var moveRectangular = null,
                currentDirection = 'up',
                rangeLeft = parseInt(element.style.left, 10),
                rangeRight = rangeLeft + getRandomInt(MIN_RANGE, MAX_RANGE),
                rangeTop = parseInt(element.style.top, 10),
                rangeBottom = rangeTop + getRandomInt(MIN_RANGE, MAX_RANGE);

            moveRectangular = function moveRectangular() {
                var elementPositionTop = parseInt(element.style.top, 10),
                    elementPositionLeft = parseInt(element.style.left, 10);

                if ((elementPositionLeft >= rangeRight ||
                        elementPositionLeft <= rangeLeft) &&
                        (elementPositionTop >= rangeBottom ||
                        elementPositionTop <= rangeTop)) {
                    currentDirection = changeDirection(currentDirection);
                }

                element.style.top = elementPositionTop +
                    rectMovement[currentDirection].top + 'px';
                element.style.left = elementPositionLeft +
                    rectMovement[currentDirection].left + 'px';
            };

            setInterval(moveRectangular, INTERVAL_DELAY);
        };

        circularMovement = function circularMovement(element) {
            var moveCircular,
                angle = 0,
                radiusX = getRandomInt(MIN_RANGE, MAX_RANGE),
                radiusY = getRandomInt(MIN_RANGE, MAX_RANGE),
                elementPositionTop = parseInt(element.style.top, 10),
                elementPositionLeft = parseInt(element.style.left, 10),
                centerX = elementPositionLeft + ELEMENT_WIDTH,
                centerY = elementPositionTop + ELEMENT_HEIGHT;

            moveCircular = function moveCircular() {
                /*
                * x = a + r * cos angle,
                * y = b + r * sin angle,
                * */
                elementPositionLeft = centerX + radiusX * Math.cos(angle * Math.PI / 180);
                elementPositionTop = centerY + radiusY * Math.sin(angle * Math.PI / 180);
                angle += STEP_ANGLE;
                element.style.top = elementPositionTop + 'px';
                element.style.left = elementPositionLeft + 'px';
            };

            setInterval(moveCircular, INTERVAL_DELAY);
        };

        moveInShape = function moveInShape(element, shape) {
            switch (shape) {
            case 'rect':
                rectangularMovement(element);
                break;
            case 'ellipse':
                circularMovement(element);
                break;
            default:
                throw new RangeError("Unknown shape!");
            }
        };

        function add(shape) {
            var newMovingDiv;

            if (!originDiv) { // If origin Div is still not created, create it.
                originDiv = document.createElement('div');
                originDiv.style.width = ELEMENT_WIDTH + 'px';
                originDiv.style.height = ELEMENT_HEIGHT + 'px';
                originDiv.style.position = 'absolute';
            }

            newMovingDiv = generateNewMovingDiv(originDiv);
            document.body.appendChild(newMovingDiv);
            moveInShape(newMovingDiv, shape);
        }

        return {
            add: add
        };
    }());

    movingShapes.add('rect');
    movingShapes.add('ellipse');
};