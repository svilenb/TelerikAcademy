/// <reference path="_reference.js" />
var games = (function () {
    var timeoutID,
        theSnake,
        theRenderer,
        theDimensions,
        theFood,
        theGame,
        gameOverEvent;

    function createFood(renderer) {
        var foodX = parseInt(Math.random() * renderer.getDimensions().maxWidth, 10),
            foodY = parseInt(Math.random() * renderer.getDimensions().maxHeight, 10);

        return snakes.getFood(
            foodX - (foodX % snakes.partSize),
            foodY - (foodY % snakes.partSize),
            snakes.partSize
        );
    }

    function Game(renderer, player) {
        this.renderer = renderer;
        this.player = player;
        this.snake = snakes.getSnake(200, 200, 10);
        this.food = createFood(renderer);
        this.bindKeyEvents();
        this.score = 0;
    }

    function animationFrame() {
        var gameOver = false,
            snakePosition = theSnake.getPosition(),
            hasCrashedIntoWall = false,
            hasCrashedIntoItself = false;

        if (snakePosition.x === theFood.x && snakePosition.y === theFood.y) {
            theSnake.grow();
            theGame.score += 1;
            theFood = createFood(theRenderer);
        }

        hasCrashedIntoWall = (
            snakePosition.x < theDimensions.minWidth ||
            snakePosition.x >= theDimensions.maxWidth - 1 ||
            snakePosition.y < theDimensions.minHeight ||
            snakePosition.y >= theDimensions.maxHeight - 1
        );

        hasCrashedIntoItself = theSnake.hasCrashedIntoItslef();

        if (hasCrashedIntoWall === true || hasCrashedIntoItself === true) {
            gameOver = true;
        }

        if (gameOver === false) {
            theSnake.move();
            theRenderer.clear();
            theRenderer.draw(theSnake);
            theRenderer.draw(theFood);
            timeoutID = window.setTimeout(animationFrame, 250);
        } else {
            theGame.finish();
        }
    }

    Game.prototype = {
        start: function (ev) {
            theGame = this;
            theDimensions = this.renderer.getDimensions();
            theSnake = this.snake;
            theRenderer = this.renderer;
            theFood = this.food;
            gameOverEvent = ev;
            animationFrame();
        },
        stop: function () {
            window.clearTimeout(timeoutID);
        },
        finish: function () {
            window.clearTimeout(timeoutID);
            theRenderer.draw('Game Over');
            document.body.dispatchEvent(gameOverEvent);
        },
        bindKeyEvents: function () {
            var self = this;

            window.addEventListener("keydown", function (ev) {
                var keyCode = ev.keyCode;

                if (keyCode === 37) {
                    self.snake.changeDirection('left');
                } else if (keyCode === 38) {
                    self.snake.changeDirection('up');
                } else if (keyCode === 39) {
                    self.snake.changeDirection('right');
                } else if (keyCode === 40) {
                    self.snake.changeDirection('down');
                }
            });
        }
    };

    return {
        get: function (renderer, player) {
            return new Game(renderer, player);
        }
    };
}());