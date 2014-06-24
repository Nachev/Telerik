window.onload = function() {
    var paper = Raphael(0, 0, 1024, 548),
        cx = 1024 / 2,
        cy = 548 / 2,
        angle = 0,
        radian = 0,
        x = cx,
        y = cy,
        r = 1;

    while (x > 0 && x < 1024 && y > 0 && y < 548) {
        /*x = a + r * cos t
        y = b + r * sin t */
        radian = angle * Math.PI / 180;
        x = cx + r * Math.cos(radian);
        y = cy + r * Math.sin(radian);
        r += 0.1;
        angle += 0.5;

        paper.circle(x, y, 1).attr({
            fill: 'black',
            stroke: 'black'
        });
    }
};