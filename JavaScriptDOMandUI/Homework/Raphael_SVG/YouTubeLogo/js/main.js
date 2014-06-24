/*jslint browser: true*/
window.onload = function() {
    var oval = null,
        paper = Raphael(0, 0, 1366, 548);

    paper.text(310, 287, 'You')
        .attr({
            'font-family': "Franklin Gothic Medium Cond",
            'font-size': 390,
            fill: "#4B4B4B"
        });

    oval = paper.path('M560 108 Q560 18 658 8 Q955 0 1262 8 Q1346 25 1360 109 Q1370 284 1360 443 Q1346 526 1260 541 Q955 550 660 541 Q581 520 561 443 Q543 280 560 108');
    oval.attr({
        fill: '#EC2727',
        stroke: 'none'
    });

    paper.text(960, 287, 'Tube')
        .attr({
            'font-family': "Franklin Gothic Medium Cond",
            'font-size': 390,
            fill: "#FFFFFF"
        });
}