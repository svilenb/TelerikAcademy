/// <reference path="_reference.js" />
var gameObjects = (function () {
    var partSize = 20,
        direction = {
            up: {
                dx: 0,
                dy: -1
            },
            down: {
                dx: 0,
                dy: 1
            },
            left: {
                dx: -1,
                dy: 0
            },
            right: {
                dx: 1,
                dy: 0
            }
        };

    var GameObject = (function () {
        var GameObject = function (x, y, size) {
            this._x = x;
            this._y = y;
            this._size = size;
        };

        GameObject.prototype.getPosition = function () {
            return {
                x: this._x,
                y: this._y
            };
        };

        GameObject.prototype.getSize = function () {
            return this._size;
        };

        return GameObject;
    }());

    var SnakePart = (function () {
        var SnakePart = function (x, y, size) {
            GameObject.call(this, x, y, size);
        };

        SnakePart.prototype = new GameObject();
        SnakePart.prototype.constructor = SnakePart;

        return SnakePart;
    }());

    var Snake = (function () {
        var Snake = function (x, y, size) {
            var part = null,
                i;

            this.direction = 'up';
            this.parts = [];
            this.newDirections = [];
            for (i = size - 1; i >= 0; i -= 1) {
                part = new SnakePart(x, y + i * partSize, partSize);
                this.parts.push(part);
            }
        };

        Snake.prototype = new GameObject();
        Snake.prototype.constructor = Snake;

        Snake.prototype.move = function () {
            var headPosition = this.getPosition(),
                newHeadPosition = {
                    x: headPosition.x + direction[this.direction].dx * partSize,
                    y: headPosition.y + direction[this.direction].dy * partSize
                };

            this.parts.push(new SnakePart(newHeadPosition.x, newHeadPosition.y, partSize));
            this.parts.shift();
        };

        Snake.prototype.changeDirection = function () {
            var newDirection = this.newDirections.shift();

            if (newDirection === 'up' && this.direction !== 'down') {
                this.direction = 'up';
            } else if (newDirection === 'down' && this.direction !== 'up') {
                this.direction = 'down';
            } else if (newDirection === 'right' && this.direction !== 'left') {
                this.direction = 'right';
            } else if (newDirection === 'left' && this.direction !== 'right') {
                this.direction = 'left';
            }
        };

        Snake.prototype.getPosition = function () {
            return this.parts[this.parts.length - 1].getPosition();
        };

        Snake.prototype.grow = function () {
            var theNewPart = new SnakePart(
                this.parts[0].getPosition().x,
                this.parts[0].getPosition().y,
                partSize
                );

            this.parts.unshift(theNewPart);
        };

        Snake.prototype.hasCrashedIntoItslef = function () {
            var headPosition = this.getPosition(),
                partPosition,
                answer = false,
                i;

            for (i = 0; i < this.parts.length - 1; i += 1) {
                partPosition = this.parts[i].getPosition();
                if (partPosition.x === headPosition.x && partPosition.y === headPosition.y) {
                    answer = true;
                }
            }

            return answer;
        };

        return Snake;
    }());

    var Food = (function () {
        var Food = function (x, y, size) {
            GameObject.call(this, x, y, size);
        };

        Food.prototype = new GameObject();
        Food.prototype.constructor = Food;

        return Food;
    }());

    return {
        getSnake: function (x, y, size) {
            return new Snake(x, y, size);
        },
        getFood: function (x, y, size) {
            return new Food(x, y, size);
        },
        SnakeType: Snake,
        SnakePartType: SnakePart,
        FoodType: Food,
        partSize: partSize
    };
}());