/*jslint browser: true*/
window.onload = function() {
    var logo = null,
        copyright = null,
        paper = Raphael(0, 0, 849, 305);

    logo = paper.path('M52 92 L84 62 L159 138 L122 175 L86 138 L161 62 L192 92');
    logo.attr({
        stroke: '#5CE600',
        'stroke-width': 21
    });

    paper.text(440, 130, 'Telerik')
        .attr({
            fill: '#282828',
            'font-size': 148,
            'font-family': 'Segoe UI',
            stroke: '#282828',
            'stroke-width': 7
        });

    paper.setStart();
    paper.circle(685, 122, 15);
    paper.text(685, 122, 'R');
    copyright = paper.setFinish();
    copyright.attr({
        'font-size': 17,
        stroke: '#282828',
        'stroke-width': 3
    });

    paper.text(536, 230, 'Develop experiences')
        .attr({
            fill: '#282828',
            'font-size': 63,
            'font-family': 'Segoe UI',
        });
};