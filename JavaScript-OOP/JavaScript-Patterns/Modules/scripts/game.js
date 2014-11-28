/// <reference path="_reference.js" />
var games = (function () {
    var timeoutID,
        theSnake,
        theRenderer,
        theDimensions,
        theFood,
        theGame,
        gameOverEvent;

    function isOverTheSnake(x, y, snake) {
        var i,
            partPosiiton;

        for (i = 0; i < snake.parts.length; i += 1) {
            partPosiiton = snake.parts[i].getPosition();
            if (partPosiiton.x === x && partPosiiton.y === y) {
                return true;
            }
        }

        return false;
    }

    function createFood(renderer) {
        var randomX,
            randomY,
            foodX,
            foodY,
            size = gameObjects.partSize;

        do {
            randomX = parseInt(Math.random() * renderer.getDimensions().maxWidth, 10);
            randomY = parseInt(Math.random() * renderer.getDimensions().maxHeight, 10);
            foodX = randomX - (randomX % size);
            foodY = randomY - (randomY % size);
        } while (isOverTheSnake(foodX, foodY, this.snake));

        return gameObjects.getFood(foodX, foodY, size);
    }

    function animationFrame() {
        var gameOver = false,
            snakePosition = theSnake.getPosition(),
            foodPosition = theFood.getPosition(),
            hasCrashedIntoWall = false,
            hasCrashedIntoItself = false;        

        if (snakePosition.x === foodPosition.x && snakePosition.y === foodPosition.y) {
            theSnake.grow();
            theGame.score += 1;
            theFood = createFood.call(theGame, theRenderer);
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
            if (theSnake.newDirections.length > 0) {
                theSnake.changeDirection();
            }

            theSnake.move();
            theRenderer.clear();
            theRenderer.draw(theSnake);
            theRenderer.draw(theFood);
            timeoutID = window.setTimeout(animationFrame, theGame.waitingTime);
        } else {
            theGame.finish();
        }
    }

    var Game = (function () {
        var Game = function (renderer, player) {
            this.renderer = renderer;
            this.player = player;
            this.snake = gameObjects.getSnake(renderer.getDimensions().maxWidth / 2, 180, 8);
            this.food = createFood.call(this, renderer);
            this.bindKeyEvents();
            this.score = 0;
            this.waitingTime = 150;
        };

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
            pause: function () {
                window.clearTimeout(timeoutID);
            },
            run: function () {
                animationFrame();
            },
            finish: function () {
                window.clearTimeout(timeoutID);
                theRenderer.draw('Game Over');
                document.body.dispatchEvent(gameOverEvent);
            },
            bindKeyEvents: function () {
                var self = this;

                window.addEventListener("keydown", function (ev) {
                    var keyCode = ev.keyCode,
                        newDirections = self.snake.newDirections;

                    if (keyCode === 37) {
                        if (newDirections.length < 2) {
                            newDirections.push('left');
                        }

                    } else if (keyCode === 38) {
                        if (newDirections.length < 2) {
                            newDirections.push('up');
                        }
                    } else if (keyCode === 39) {
                        if (newDirections.length < 2) {
                            newDirections.push('right');
                        }
                    } else if (keyCode === 40) {
                        if (newDirections.length < 2) {
                            newDirections.push('down');
                        }
                    }
                });
            }
        };

        return Game;
    }());     
    
    return {
        get: function (renderer, player) {
            return new Game(renderer, player);
        }
    };
}());