var SnakeGame;
(function (SnakeGame) {
    (function (Renderers) {
        var CanvasRenderer = (function () {
            function CanvasRenderer(selector) {
                if (selector instanceof HTMLCanvasElement) {
                    this._canvas = selector;
                } else if (String(typeof selector).toLowerCase() === 'string') {
                    this._canvas = document.querySelector(selector);
                }

                this._context = this._canvas.getContext('2d');
            }
            CanvasRenderer.prototype.draw = function (obj) {
                if (obj instanceof SnakeGame.GameObjects.Snake) {
                    this.drawSnake(obj);
                } else if (obj instanceof SnakeGame.GameObjects.SnakePart) {
                    this.drawSnakePart(obj);
                } else if (obj instanceof SnakeGame.GameObjects.Food) {
                    this.drawFood(obj);
                } else if (String(typeof obj).toLowerCase() === 'string') {
                    this.drawMessage(obj);
                }
            };

            CanvasRenderer.prototype.clear = function () {
                var width = this._canvas.width, height = this._canvas.height;

                this._context.clearRect(0, 0, width, height);
            };

            CanvasRenderer.prototype.getDimensions = function () {
                return {
                    minWidth: 0,
                    maxWidth: this._canvas.width,
                    minHeight: 0,
                    maxHeight: this._canvas.height
                };
            };

            CanvasRenderer.prototype.drawSnakePart = function (snakePart) {
                var position = snakePart.getPosition(), size = snakePart.getSize();

                this._context.fillStyle = 'green';
                this._context.strokeStyle = 'black';
                this._context.fillRect(position.x, position.y, size, size);
                this._context.strokeRect(position.x, position.y, size, size);
            };

            CanvasRenderer.prototype.drawSnake = function (snake) {
                var i, parts = snake.getParts();

                for (i = 0; i < parts.length; i += 1) {
                    this.drawSnakePart(parts[i]);
                }
            };

            CanvasRenderer.prototype.drawFood = function (food) {
                var position = food.getPosition(), size = food.getSize();

                this._context.fillStyle = 'orange';
                this._context.fillRect(position.x, position.y, size, size);
            };

            CanvasRenderer.prototype.drawMessage = function (message) {
                this._context.font = '38px Consolas';
                this._context.fillStyle = 'red';
                this._context.fillText(message, this._canvas.width / 6, this._canvas.height / 2);
            };
            return CanvasRenderer;
        })();
        Renderers.CanvasRenderer = CanvasRenderer;
    })(SnakeGame.Renderers || (SnakeGame.Renderers = {}));
    var Renderers = SnakeGame.Renderers;
})(SnakeGame || (SnakeGame = {}));
//# sourceMappingURL=renderers.js.map
