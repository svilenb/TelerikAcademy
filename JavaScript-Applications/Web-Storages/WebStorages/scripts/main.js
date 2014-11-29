/// <reference path="_reference.js" />
/* global window, $, games */

(function () {
    'use strict';
    var $newGameButton = $('#new-game-button'),
        $checkButton = $('#check-button'),
        $highScoreButton = $('#high-score-button'),
        $guessNumber = $('#guess'),
        $winningMessage = $('#winning-message'),
        $exception = $('#exception'),
        $rams = $('#rams'),
        $sheeps = $('#sheeps'),
        $highScoreboard = $('#high-score-board'),
        game;

    $checkButton.attr('disabled', 'disabled');

    function performNewGame() {
        var player = window.prompt('Enter yor name', 'unknown');
        try {
            game = new games.Game(player);
            $newGameButton.attr('disabled', 'disabled');
            $checkButton.removeAttr('disabled');
        } catch (ex) {
            $exception.html(ex.message);
            window.setTimeout(function myfunction() {
                $exception.html("");
            }, 3000);
        }
    }

    function processHighScoreBoard(player, numberOfTurns) {
        var min,
            i;

        if (window.localStorage.length < 5) {
            window.localStorage.setItem(player, numberOfTurns.toString());
        } else {
            for (i in window.localStorage) {
                if (min === undefined) {
                    min = {
                        player: i,
                        numberOfTurns: window.localStorage[i]
                    };
                } else {
                    if (min.numberOfTurns < parseInt(window.localStorage[i], 10)) {
                        min = {
                            player: i,
                            numberOfTurns: window.localStorage[i]
                        };
                    }
                }
            }

            if (min.numberOfTurns > numberOfTurns) {
                window.localStorage.removeItem(min.player);
                window.localStorage.setItem(player, numberOfTurns.toString());
            }
        }
    }

    function performGameOver() {
        $winningMessage.html("You guessed the number!");
        window.setTimeout(function myfunction() {
            $winningMessage.html("");
        }, 3000);
        processHighScoreBoard(game.getPlayer(), game.getNumberOfTurns());
        game = null;
        $newGameButton.removeAttr('disabled');
        $checkButton.attr('disabled', 'disabled');
    }

    function performCheck() {
        var result;

        try {
            result = game.makeGuess(parseInt($guessNumber.val(), 10));
            $rams.html(result.rams);
            $sheeps.html(result.sheeps);
        } catch (ex) {
            $exception.html(ex.message);
            window.setTimeout(function myfunction() {
                $exception.html("");
            }, 3000);
        }
    }

    function showHighScoreBoard() {
        var $h2 = $('<h2>'),
            $dl = $('<dl>'),
            $dt = $('<dt>').css('width', '40%'),
            $dd = $('<dd>').css('width', '40%'),
            list = [],
            i,
            len;

        $highScoreboard.html('');
        $h2.html('High-score board').appendTo($dl);
        for (i in window.localStorage) {
            list.push({
                name: i,
                turns: window.localStorage[i]
            });
        }

        list.sort(function (a, b) {
            return (a.turns === b.turns) ? 0 : (a.turns > b.turns) ? 1 : -1;
        });

        for (i = 0, len = list.length; i < len; i += 1) {
            $dt.clone().html(list[i].name).appendTo($dl);
            $dd.clone().html(list[i].turns).appendTo($dl);
        }

        $highScoreboard.append($dl);
    }

    $('body').on('game-over', performGameOver);

    $newGameButton.on('click', performNewGame);

    $checkButton.on('click', performCheck);

    $highScoreButton.on('click', showHighScoreBoard);
}());