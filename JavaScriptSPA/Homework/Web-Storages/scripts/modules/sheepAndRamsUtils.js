/*jslint browser: true*/
define(['underscore', 'jQuery'], function (_, $) {
    'use strict';

    var sheepAndRamsUtils;

    sheepAndRamsUtils = (function () {
        var MIN_NUMBER = 1000,
            MAX_NUMBER = 9999;

        // Generates secret number as array of digits.
        var secretNumberGenerator = function () {
            var numberArr,
                number;

            number = [];
            numberArr = _.range(10);

            while (!_.first(number)) {
                number = _.chain(numberArr)
                    .shuffle()
                    .sample(4)
                    .value();
            }

            return number;
        };

        // Handles validations.
        var inputValueValidator = function (value) {
            if (!_.isNumber(value) || (value % 1 !== 0)) {
                throw new Error('Entered value is not a correct number');
            } else if (value < MIN_NUMBER || value > MAX_NUMBER) {
                throw  new Error('Entered value is out of the range: ' + MIN_NUMBER + ' - ' + MAX_NUMBER);
            }

            return null;
        };

        // Converts input number to array of digits.
        var convertInputValueToArray = function (inputValue) {
            var currentDigit,
                result;

            result = [];
            while (inputValue > 0) {
                currentDigit = inputValue % 10;
                inputValue = parseInt(inputValue / 10, 10);
                result.push(currentDigit);
            }

            return result.reverse(); // For this program first digit is element 0 of the array
        };

        // Handles input from the player.
        var playerInputHandler = function () {
            var value,
                result;

            value = parseInt(this.value, 10);
            inputValueValidator(value);
            // Should check if number has unique digits only.
            result = convertInputValueToArray(value);
            if (_.unique(result).length < 4) {
                throw  new Error('Entered digits must be unique in the set.');
            }

            return result;
        };

        // Compares two arrays of digits. Returns object with sheep and rams.
        var handleComparison = function (secretNumber, playerNumber) {
            var sheep,
                rams,
                currentSecretDigit,
                currentPlayerDigit,
                i,
                j,
                lenPlayer,
                lenSecret;

            sheep = 0;
            rams = 0;

            for (i = 0, lenSecret = secretNumber.length; i < lenSecret; i += 1) {
                currentSecretDigit = secretNumber[i];
                for (j = 0, lenPlayer = playerNumber.length; j < lenPlayer; j += 1) {
                    currentPlayerDigit = playerNumber[j];
                    if (currentPlayerDigit === currentSecretDigit) {
                        if (i === j) {
                            rams += 1;
                        } else {
                            sheep += 1;
                        }
                    }
                }
            }

            return {
                sheep: sheep,
                rams: rams
            }
        };

        return {
            secretNumberGenerator: secretNumberGenerator,
            playerInputHandler: playerInputHandler,
            handleComparison: handleComparison
        }
    }());

    return sheepAndRamsUtils;
});