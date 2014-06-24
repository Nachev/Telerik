/*jslint browser: true*/
window.onload = function() {
    var canvas = null,
        context = null,
        ball = null;

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function Ball() {
        this.x = getRandomInt(0, context.canvas.width);
        this.y = getRandomInt(0, context.canvas.height);
        this.speedX = 1;
        this.speedY = 1;
        this.RADIUS = 2;
        this.move = function move() {
            if (this.y > 0 && this.y < context.canvas.height) {
                this.y += this.speedY;
                if (this.y >= context.canvas.height) {
                    this.speedY *= -1;
                    this.y = context.canvas.height - 1;
                } else if (this.y <= 0) {
                    this.speedY *= -1;
                    this.y = 1;
                }
            }

            if (this.x > 0 && this.x < context.canvas.width) {
                this.x += this.speedX;
                if (this.x >= context.canvas.width) {
                    this.speedX *= -1;
                    this.x = context.canvas.width - 1;
                } else if (this.x <= 0) {
                    this.speedX *= -1;
                    this.x = 1;
                }
            }
        };
        this.draw = function draw() {
            context.beginPath();
            context.strokeStyle = 'black';
            context.lineWidth = 3;
            context.arc(this.x, this.y, this.RADIUS, 0, Math.PI * 2, false);
            context.stroke();
        };
    }

    function draw() {
        context.clearRect(0, 0, canvas.width, canvas.height);
        ball.draw();
    }

    function update() {
        ball.move();
    }

    function animate() {
        update();
        draw();

        setTimeout(animate, 10);
    }

    function init() {
        canvas = document.getElementById('the-canvas');
        context = canvas.getContext('2d');
        ball = new Ball();

        draw();
        animate();
    }

    init();
};