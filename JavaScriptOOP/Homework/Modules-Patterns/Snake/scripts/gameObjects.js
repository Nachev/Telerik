/*jslint browser: true*/
var gameObjects = (function () {
    'use strict';
    var snake = (function () {
        var SNAKE_SEG_RADIUS = 5,
            SNAKE_COLOR = '#10BB10',
            INITIAL_BODY_LENGTH = 3,
            segmentDiameter,
            _direction,
            _body,
            _position,
            i,
            previousElement;

        segmentDiameter = 2 * SNAKE_SEG_RADIUS;
        _body = [];
        _direction = {
            up: {x: 0, y: -1},
            down: {x: 0, y: 1},
            left: {x: -1, y: 0},
            right: {x: 1, y: 0}
        };
        _position = {
            x: INITIAL_BODY_LENGTH * segmentDiameter,
            y: 300
        };
        _body.push({
            x: _position.x,
            y: _position.y
        });

        for (i = 1; i < INITIAL_BODY_LENGTH; i += 1) {
            previousElement = _body[i - 1];
            _body.push({
                x: previousElement.x - segmentDiameter,
                y: previousElement.y
            });
        }

        var getHeadBoundingBox = function () {
            return {
                x: _body[0].x - SNAKE_SEG_RADIUS,
                y: _body[0].y - SNAKE_SEG_RADIUS,
                width: segmentDiameter,
                height: segmentDiameter
            };
        };

        var eat = function () {
            var lastElement = _body[_body.length - 1];
            _body.push({x: lastElement.x, y: lastElement.y});
        };

        var update = function (inputDirection) {
            var i,
                previousElement,
                previousDirection;

            previousDirection = previousDirection || 'right';
            inputDirection = inputDirection || previousDirection;

            if (!(_direction.hasOwnProperty(inputDirection))) {
                throw new {
                    message: "Unknown input direction received!"
                };
            }

            for (i = _body.length - 1; i > 0; i -= 1) {
                previousElement = _body[i - 1];
                _body[i].x = previousElement.x;
                _body[i].y = previousElement.y;
            }

            _body[0].x += _direction[inputDirection].x * segmentDiameter;
            _body[0].y += _direction[inputDirection].y * segmentDiameter;
            previousDirection = inputDirection;
        };

        return {
            _type: 'snake',
            _position: _position,
            _body: _body,
            getHeadBox: getHeadBoundingBox,
            eat: eat,
            update: update,
            length: _body.length * segmentDiameter,
            SEGMENT_RADIUS: SNAKE_SEG_RADIUS,
            COLOR: SNAKE_COLOR
        }
    }());

    var Apple = (function () {
        var APPLE_COLOR = '#EE0505',
            APPLE_SIZE = 10,
            _position;

        function Apple(initX, initY) {
            if (!(this instanceof Apple)) {
                return new Apple(arguments);
            }

            _position = {
                x: initX,
                y: initY
            };

            this._type = 'apple';
            this._box = {
                x: _position.x,
                y: _position.y,
                width: APPLE_SIZE,
                height: APPLE_SIZE
            };
            this.COLOR = APPLE_COLOR;
        }

        return Apple;
    }());

    var Obstacle = (function () {
        var OBSTACLE_COLOR = '#0505CC',
            OBSTACLE_SEGMENT_DIMENSION = 20,
            _width,
            _height,
            _position;

        function Obstacle(initX, initY, numberOfSegmentsHorizontal, numberOfSegmentsVertical) {
            if (!(this instanceof Obstacle)) {
                return new Obstacle(arguments);
            }

            _position = {
                x: initX,
                y: initY
            };
            _width = numberOfSegmentsHorizontal * OBSTACLE_SEGMENT_DIMENSION;
            _height = numberOfSegmentsVertical * OBSTACLE_SEGMENT_DIMENSION;

            this._type = 'obstacle';
            this._box = {
                x: _position.x,
                y: _position.y,
                width: _width,
                height: _height
            };

            this.COLOR = OBSTACLE_COLOR;
        }

        return Obstacle;
    }());

    var border = {
        _type: 'border',
        width: 10,
        COLOR: '#602F1A'
    };

    return {
        snake: snake,
        border: border,
        Apple: Apple,
        Obstacle: Obstacle
    };
}());