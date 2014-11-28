/// <reference path="../libs/jquery.d.ts" />
var SnakeGame;
(function (SnakeGame) {
    (function () {
        var canvas = document.getElementById('the-canvas'), $startButton = $('#start-button'), $stopButton = $('#stop-button'), $newGameButton = $('#new-game-button'), game, renderer;

        $startButton.attr('disabled', 'disabled');
        $stopButton.attr('disabled', 'disabled');

        function performNewGame() {
            renderer = new SnakeGame.Renderers.CanvasRenderer(canvas);
            game = new SnakeGame.Games.Game(renderer);
            game.startNew();
            $newGameButton.attr('disabled', 'disabled');
            $startButton.removeAttr('disabled');
            $stopButton.removeAttr('disabled');
        }

        function performGameStart() {
            game.run();
            $startButton.attr('disabled', 'disabled');
            $stopButton.removeAttr('disabled');
        }

        function performGameStop() {
            game.pause();
            $startButton.removeAttr('disabled');
            $stopButton.attr('disabled', 'disabled');
        }

        function performGameOver() {
            renderer = null;
            game = null;
            $newGameButton.removeAttr('disabled');
            $startButton.attr('disabled', 'disabled');
            $stopButton.attr('disabled', 'disabled');
        }

        $('body').on('game-over', performGameOver);

        $newGameButton.on('click', performNewGame);

        $startButton.on("click", performGameStart);

        $stopButton.on("click", performGameStop);

        $(window).on('keydown', function (ev) {
            var keyCode = ev.keyCode;

            if (keyCode === 78) {
                if ($newGameButton.attr('disabled') !== 'disabled') {
                    performNewGame();
                }
            } else if (keyCode === 80) {
                if ($stopButton.attr('disabled') !== 'disabled') {
                    performGameStop();
                }
            } else if (keyCode === 83) {
                if ($startButton.attr('disabled') !== 'disabled' && $stopButton.attr('disabled') === 'disabled') {
                    performGameStart();
                }
            }
        });
    }());
})(SnakeGame || (SnakeGame = {}));
//# sourceMappingURL=main.js.map
