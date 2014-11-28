module SnakeGame.Games {
    export interface IGame {
        startNew(): void;
        pause(): void;
        run(): void;
        finish(): void;
    }

    export class Game implements IGame {
        private _renderer: Renderers.IRenderer;
        private _dimensions: { minWidth; maxWidth; minHeight; maxHeight };
        private _snake: GameObjects.Snake;
        private _food: GameObjects.Food;
        private _timeoutID: number;
        private _score: number;
        private _waitingTime: number;

        constructor(renderer: Renderers.IRenderer) {
            this._renderer = renderer;
            this._dimensions = renderer.getDimensions();
            this._snake = new GameObjects.Snake(renderer.getDimensions().maxWidth / 2, 180, 8);
            this._food = this.createFood();
            this._waitingTime = 150;
            this.bindKeyEvents();
        }

        startNew(): void {
            this.animationFrame.call(this);
        }

        run(): void {
            this.animationFrame.call(this);
        }

        pause(): void {
            window.clearTimeout(this._timeoutID);
        }

        finish(): void {
            window.clearTimeout(this._timeoutID);
            this._renderer.draw('Game Over');
            $('body').trigger("game-over");
        }

        private isOverTheSnake(x: number, y: number): boolean {
            var i,
                partPosiiton,
                snakeParts = this._snake.getParts();

            for (i = 0; i < snakeParts.length; i += 1) {
                partPosiiton = snakeParts[i].getPosition();
                if (partPosiiton.x === x && partPosiiton.y === y) {
                    return true;
                }
            }

            return false;
        }

        private createFood(): GameObjects.Food {
            var randomX,
                randomY,
                foodX,
                foodY,
                size = GameObjects.GameObject.partSize;

            do {
                randomX = (Math.random() * this._renderer.getDimensions().maxWidth) | 0;
                randomY = (Math.random() * this._renderer.getDimensions().maxHeight) | 0;
                foodX = randomX - (randomX % size);
                foodY = randomY - (randomY % size);
            } while (this.isOverTheSnake(foodX, foodY));

            return new GameObjects.Food(foodX, foodY, size);
        }

        private animationFrame(): void {
            var self = this,
                gameOver = false,
                snakePosition = this._snake.getPosition(),
                foodPosition = this._food.getPosition(),
                hasCrashedIntoWall = false,
                hasCrashedIntoItself = false;

            if (snakePosition.x === foodPosition.x && snakePosition.y === foodPosition.y) {
                this._snake.grow();
                this._score += 1;
                this._food = this.createFood();
            }

            hasCrashedIntoWall = (
            snakePosition.x < this._dimensions.minWidth ||
            snakePosition.x >= this._dimensions.maxWidth - 1 ||
            snakePosition.y < this._dimensions.minHeight ||
            snakePosition.y >= this._dimensions.maxHeight - 1
            );

            hasCrashedIntoItself = this._snake.hasCrashedIntoItself();

            if (hasCrashedIntoWall === true || hasCrashedIntoItself === true) {
                gameOver = true;
            }

            if (gameOver === false) {
                if (this._snake.newDirections.length > 0) {
                    this._snake.changeDirection();
                }

                this._snake.move();
                this._renderer.clear();
                this._renderer.draw(this._snake);
                this._renderer.draw(this._food);
                this._timeoutID = window.setTimeout(function () {
                    self.animationFrame.call(self);
                }, self._waitingTime);
            } else {
                this.finish();
            }
        }

        private bindKeyEvents(): void {
            var self = this;

            window.addEventListener("keydown", function (ev) {
                var keyCode = ev.keyCode,
                    newDirections = self._snake.newDirections;

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
    }
} 