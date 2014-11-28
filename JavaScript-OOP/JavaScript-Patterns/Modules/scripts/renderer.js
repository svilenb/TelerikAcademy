/// <reference path="_reference.js" />
var renderers = (function () {
    var CanvasRenderer = (function () {
        var drawSnakePart = function (snakePart) {
            var context = this._canvas.getContext('2d'),
                position = snakePart.getPosition(),
                size = snakePart.getSize();

            context.fillStyle = 'green';
            context.strokeStyle = 'black';
            context.fillRect(position.x, position.y, size, size);
            context.strokeRect(position.x, position.y, size, size);
        };

        var drawFood = function (food) {
            var context = this._canvas.getContext('2d'),
                position = food.getPosition(),
                size = food.getSize();

            context.fillStyle = 'orange';
            context.fillRect(position.x, position.y, size, size);
        };

        var drawMessage = function (message) {
            var context = this._canvas.getContext('2d');

            context.font = '38px Consolas';
            context.fillStyle = 'red';
            context.fillText(message, this._canvas.width / 6, this._canvas.height / 2);
        };

        var drawSnake = function (snake) {
            var i;

            for (i = 0; i < snake.parts.length; i += 1) {
                drawSnakePart.call(this, snake.parts[i]);
            }
        };

        var CanvasRenderer = function (selector) {
            if (selector instanceof HTMLCanvasElement) {
                this._canvas = selector;
            } else if (String(typeof selector).toLowerCase() === 'string') {
                this._canvas = document.querySelector(selector);
            }
        };

        CanvasRenderer.prototype = {
            draw: function (obj) {
                if (obj instanceof gameObjects.SnakeType) {
                    drawSnake.call(this, obj);
                } else if (obj instanceof gameObjects.SnakePartType) {
                    drawSnakePart.call(this, obj);
                } else if (obj instanceof gameObjects.FoodType) {
                    drawFood.call(this, obj);
                } else if (String(typeof obj).toLowerCase() === 'string') {
                    drawMessage.call(this, obj);
                }
            },
            clear: function () {
                var context = this._canvas.getContext('2d'),
                    width = this._canvas.width,
                    height = this._canvas.height;

                context.clearRect(0, 0, width, height);
            },
            getDimensions: function () {
                return {
                    minWidth: 0,
                    maxWidth: this._canvas.width,
                    minHeight: 0,
                    maxHeight: this._canvas.height
                };
            }
        };

        return CanvasRenderer;
    }());

    return {
        getCanvasRenderer: function (selector) {
            return new CanvasRenderer(selector);
        }
    };
}());