/// <reference path="_reference.js" />
var renderers = (function () {
    var drawSnakePart = function (canvas, snakePart) {
        var context = canvas.getContext('2d'),
            position = snakePart.getPosition();

        context.fillStyle = 'green';
        context.strokeStyle = 'black';
        context.fillRect(position.x, position.y, snakePart.size, snakePart.size);
        context.strokeRect(position.x, position.y, snakePart.size, snakePart.size);
    };

    var drawFood = function (canvas, food) {
        var context = canvas.getContext('2d'),
            position = food.getPosition();
        context.fillStyle = 'orange';
        context.fillRect(position.x, position.y, food.size, food.size);
    };

    var drawMessage = function (canvas, message) {
        var context = canvas.getContext('2d');

        context.font = '38px Consolas';
        context.fillStyle = 'red';
        context.fillText(message, 100, 100);
    };

    var drawSnake = function (canvas, snake) {
        var i;

        for (i = 0; i < snake.parts.length; i += 1) {
            drawSnakePart(canvas, snake.parts[i]);
        }
    };

    function CanvasRenderer(selector) {
        if (selector instanceof HTMLCanvasElement) {
            this.canvas = selector;
        } else if (String(typeof selector).toLowerCase() === 'string') {
            this.canvas = document.querySelector(selector);
        }
    }

    CanvasRenderer.prototype = {
        draw: function (obj) {
            if (obj instanceof snakes.SnakeType) {
                drawSnake(this.canvas, obj);
            } else if (obj instanceof snakes.SnakePartType) {
                drawSnakePart(this.canvas, obj);
            } else if (obj instanceof snakes.FoodType) {
                drawFood(this.canvas, obj);
            } else if (String(typeof obj).toLowerCase() === 'string') {
                drawMessage(this.canvas, obj);
            }
        },
        clear: function () {
            var context = this.canvas.getContext('2d'),
                width = this.canvas.width,
                height = this.canvas.height;

            context.clearRect(0, 0, width, height);
        },
        getDimensions: function () {
            return {
                minWidth: 0,
                maxWidth: this.canvas.width,
                minHeight: 0,
                maxHeight: this.canvas.height
            };
        }
    };

    return {
        getCanvas: function (selector) {
            return new CanvasRenderer(selector);
        }
    };
}());