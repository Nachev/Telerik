/*jslint browser: true*/
define(['sheepAndRamsUtils', 'highScoresUtils'], function (sheepAndRamsUtils, highScoresUtils) {
    'use strict';
    var sheepAndRamsGame;

    sheepAndRamsGame = (function () {
        var run;

        run = function run(secretId, inputId, resultId, pointsId, optionsId) {
            var HIDE_COLOR = '#000',
                DEFAULT_COLOR = '#fff',
                POINTS_PENALTY = 10,
                penaltyPointsCount,
                $input,
                $result,
                $secret,
                $points,
                $options,
                secretNumber;

            $secret = $(secretId);
            $input = $(inputId);
            $result = $(resultId);
            $points = $(pointsId);
            $options = $(optionsId);

            secretNumber = sheepAndRamsUtils.secretNumberGenerator();
            $secret.html(secretNumber)
                .css('color', HIDE_COLOR)
                .css('background-color', HIDE_COLOR);

            penaltyPointsCount = 0;
            $points.html(penaltyPointsCount);
            $input.focus();

            // Handles success condition.
            var handleSuccess = function () {
                var playerName;

                $result.html('Success!');
                $secret.css('background-color', DEFAULT_COLOR);
                playerName = highScoresUtils.getName();

                if (playerName !== null) {
                    highScoresUtils.recordScore(playerName, penaltyPointsCount);
                }
            };

            // On change in input executes game logic.
            var onChangeExecute = function () {
                var playerNumber,
                    compareResult;

                try {
                    playerNumber = sheepAndRamsUtils.playerInputHandler.call(this);
                    compareResult = sheepAndRamsUtils.handleComparison(secretNumber, playerNumber);

                    if (compareResult.rams === 4) {
                        handleSuccess();
                    } else {
                        penaltyPointsCount += POINTS_PENALTY;
                        $result.html('Sheep: ' + compareResult.sheep + ' Rams: ' + compareResult.rams);
                        $points.html(penaltyPointsCount);
                    }
                }
                catch (Error) {
                    alert('Error: ' + Error.message);
                }
            };

            // Shows the high score on click.
            var onClickShowHighScores =  function (ev) {
                ev.preventDefault();
                var highScoresList,
                    toBeAlerted;

                highScoresList = highScoresUtils.getHighScores();
                toBeAlerted = highScoresList.map(function (member) {
                     return '\n' + member.name + ' ' + member.scores;
                });

                alert('High scores:' + toBeAlerted);
            };

            // Resets the game on click.
            var onClickResetGame = function (ev) {
                ev.preventDefault();

                run.call(null, secretId, inputId, resultId, pointsId, optionsId);
            };

            $input.on('change', onChangeExecute);

            $options.on('click', 'button:first-child', onClickShowHighScores);

            $options.on('click', 'button:last-child', onClickResetGame);
        };

        return {
            run: run
        };
    }());

    return sheepAndRamsGame;
});
