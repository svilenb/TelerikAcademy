/* global $ */
/* exported games */
var games = (function () {
    'use strict';
    function getRandomNumber(min, max) {
        return Math.floor(Math.random() * (max - min) + min);
    }

    var Game = (function () {
        var Game = function (player) {
            this.setPLayer(player);
            this._numberOfTurns = 0;
            this._digits = this.generateDigits();
        };

        Game.prototype.setPLayer = function (value) {
            if ((typeof value).toLowerCase() !== 'string' || value.length < 3) {
                throw {
                    message: "Invalid player name!"
                };
            }

            this._player = value;
        };

        Game.prototype.getPlayer = function () {
            return this._player;
        };

        Game.prototype.generateDigits = function () {
            var digits = [],
                i,
                currentDigit;

            digits.push(getRandomNumber(1, 9));

            for (i = 0; i < 3; i += 1) {
                do {
                    currentDigit = getRandomNumber(0, 9);
                } while (digits.indexOf(currentDigit) !== -1);

                digits.push(currentDigit);
            }

            return digits;
        };

        Game.prototype.getDigits = function () {
            return this._digits.slice();
        };

        Game.prototype.getNumberOfTurns = function () {
            return this._numberOfTurns;
        };

        Game.prototype.makeGuess = function (number) {
            var digits = this.getDigits(),
                userDigits,
                rams = 0,
                sheeps = 0,
                i,
                len;

            if ((typeof number).toLowerCase() !== 'number' || number < 999 || isNaN(number)) {
                throw {
                    message: "Invalid guess number!"
                };
            }

            userDigits = number.toString().split('').map(Number);

            for (i = 0, len = userDigits.length; i < len - 1; i += 1) {
                if (userDigits.indexOf(userDigits[i], i + 1) !== -1) {
                    throw {
                        message: "Invalid guess number!"
                    };
                }
            }

            for (i = 0, len = digits.length; i < len; i += 1) {
                if (digits[i] === userDigits[i]) {
                    rams += 1;
                    digits[i] = -1;
                }
            }

            for (i = 0, len = userDigits.length; i < len; i += 1) {
                if (digits.indexOf(userDigits[i]) !== -1) {
                    sheeps += 1;
                }
            }

            this._numberOfTurns += 1;

            if (rams === 4) {
                $('body').trigger("game-over");
            }

            return {
                rams: rams,
                sheeps: sheeps
            };
        };

        return Game;
    }());

    return {
        Game: Game
    };
}());