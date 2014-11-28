/// <reference path="_reference.js" />
(function () {
    var canvas = document.getElementById('the-canvas'),
        startButton = document.getElementById('start-button'),
        stopButton = document.getElementById('stop-button'),
        newGameButton = document.getElementById('new-game-button'),
        game,
        renderer,
        gameOverEvent = new CustomEvent('gameover');

    startButton.disabled = true;
    stopButton.disabled = true;

    function performNewGame() {
        renderer = renderers.getCanvas(canvas);
        var player = window.prompt('Enter yor name', 'unknown');
        game = games.get(renderer, player);
        game.start(gameOverEvent);
        newGameButton.disabled = true;
        startButton.disabled = false;
        stopButton.disabled = false;
    }

    function performGameStart() {
        game.start(gameOverEvent);
        startButton.disabled = true;
        stopButton.disabled = false;
    }

    function performGameStop() {
        game.stop();
        startButton.disabled = false;
        stopButton.disabled = true;
    }

    function processHighScoreBoard(player, score) {
        var min,
            i,
            highScoreBoard;

        if (window.localStorage.length < 5) {
            window.localStorage.setItem(player, score.toString());
        } else {
            for (i in window.localStorage) {
                if (min === undefined) {
                    min = {
                        player: i,
                        score: window.localStorage[i]
                    };
                } else {
                    if (min.score > parseInt(window.localStorage[i], 10)) {
                        min = {
                            player: i,
                            score: window.localStorage[i]
                        };
                    }
                }
            }

            if (min.score < score) {
                window.localStorage.removeItem(min.player);
                window.localStorage.setItem(player, score.toString());
            }
        }

        highScoreBoard = 'High-score board\n';
        for (i in window.localStorage) {
            highScoreBoard += i + ': ' + window.localStorage[i] + '\n';
        }

        window.alert(highScoreBoard);
    }

    function performGameOver() {
        processHighScoreBoard(game.player, game.score);
        renderer = null;
        game = null;
        newGameButton.disabled = false;
        startButton.disabled = true;
        stopButton.disabled = true;
    }

    document.body.addEventListener('gameover', performGameOver, false);

    newGameButton.addEventListener('click', performNewGame);

    startButton.addEventListener("click", performGameStart);

    stopButton.addEventListener("click", performGameStop);
}());