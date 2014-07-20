/*jslint browser: true*/
(function () {
    'use strict';

    require.config({
        paths: {
            jQuery: 'libs/jquery.min',
            underscore: 'libs/underscore',
            sheepAndRamsUtils: 'modules/sheepAndRamsUtils',
            sheepAndRamsGame: 'modules/sheepAndRamsGame',
            highScoresUtils: 'modules/highScoresUtils'
        }
    });

    require(['sheepAndRamsGame'], function (sheepAndRamsGame) {
        sheepAndRamsGame.run('#secret-number','#player-input', '#result', '#points', '#options');
    });
}());