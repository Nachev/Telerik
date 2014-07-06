/*jslint browser: true*/
var displayManager = (function () {
    var self;

    var drawSnake = function (ctx) {
        for (var i = 0; i < self._body.length; i++) {
            var segment = self._body[i];
            ctx.beginPath();
            ctx.arc(
                segment.x,
                segment.y,
                self.SEGMENT_RADIUS,
                0,
                Math.PI * 2
            );
            ctx.fillStyle = self.COLOR;
            ctx.fill();
            ctx.stroke();
        }
    };

    var drawApple = function (ctx) {
        var cx,
            cy;

        cx = self._box.x;
        cy = self._box.y;
        ctx.beginPath();
        ctx.moveTo(cx, cy - 5);
        ctx.bezierCurveTo(cx - 13, cy - 13, cx - 10, cy + 13, cx, cy + 5);
        ctx.bezierCurveTo(cx + 10, cy + 13, cx + 13, cy - 13, cx, cy - 5);
        ctx.lineTo(cx, cy - 9);
        ctx.stroke();
        ctx.fillStyle = self.COLOR;
        ctx.fill();
    };

    var drawObstacle = function (ctx) {
        ctx.beginPath();
        ctx.fillStyle = self.COLOR;
        ctx.fillRect(self._box.x, self._box.y, self._box.width, self._box.height);
    };

    var drawBorder = function (ctx) {
        ctx.beginPath();
        ctx.fillStyle = self.COLOR;
        ctx.fillRect(0, 0, ctx.canvas.width, ctx.canvas.height);
        ctx.clearRect(self.width, self.width, ctx.canvas.width - 2 * self.width, ctx.canvas.height - 2 * self.width)
    };

    var draw = function (canvasContext) {
        self = this;

        switch (self._type) {
            case 'snake':
                drawSnake(canvasContext);
                break;
            case 'apple':
                drawApple(canvasContext);
                break;
            case 'obstacle':
                drawObstacle(canvasContext);
                break;
            case 'border':
                drawBorder(canvasContext);
                break;
            default:
                throw new Error("Unknown object received.");
        }
    };

    return {
        draw: draw
    };
}());
