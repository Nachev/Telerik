/*jslint browser: true*/
window.onload = (function main() {
    gameManager.initialize();

     var gameInterval = setInterval(function () {
        gameManager.update(gameInterval);
        gameManager.draw();
    }, 250);
}());