/*jslint browser: true*/
define(['underscore'], function (_) {
    'use strict';
    var highScoresUtils;

    highScoresUtils = (function () {
        var NAME_SCORES_SPLITTER = ' - ',
            MEMBERS_SPLITTER = ';';

        // Converts the string from local storage to array of objects
        // with properties name and score
        var convertStringToObject = function (highScoresStr) {
            var splitInput,
                result;

            splitInput = highScoresStr.split(MEMBERS_SPLITTER);
            result = splitInput.map(function (member) {
                var keyValue = member.split(NAME_SCORES_SPLITTER);

                if (keyValue.length < 2) {
                    return null;
                }

                return {
                    name: keyValue[0].trim(),
                    scores: keyValue[1].trim()
                };
            });

            result = _.chain(result)
                .compact()
                .sortBy(function (member) {
                    return member.scores;
                })
                .value()
                .reverse();

            return result;
        };

        var getName = function () {
            var person;

            person = prompt("Please enter your name", "John Doe");

            return person;
        };

        var recordScore = function (name, scores) {
            var previousContent,
                newInput;

            previousContent = localStorage['sheepAndRamsGame'] || '';
            newInput = name + NAME_SCORES_SPLITTER + scores + MEMBERS_SPLITTER;
            localStorage['sheepAndRamsGame'] = previousContent + newInput;

            return null;
        };

        var getHighScores = function () {
            var content,
                result;

            content = localStorage['sheepAndRamsGame'];
            result = convertStringToObject(content);

            return result;
        };

        return {
            getName: getName,
            recordScore: recordScore,
            getHighScores: getHighScores
        }
    }());

    return highScoresUtils;
});