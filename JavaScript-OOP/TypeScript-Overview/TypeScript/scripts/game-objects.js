var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var SnakeGame;
(function (SnakeGame) {
    (function (GameObjects) {
        var GameObject = (function () {
            function GameObject(x, y, size) {
                this._x = x;
                this._y = y;
                this._size = size;
            }
            GameObject.prototype.getPosition = function () {
                return {
                    x: this._x,
                    y: this._y
                };
            };

            GameObject.prototype.getSize = function () {
                return this._size;
            };
            GameObject.partSize = 20;
            return GameObject;
        })();
        GameObjects.GameObject = GameObject;

        var Food = (function (_super) {
            __extends(Food, _super);
            function Food(x, y, size) {
                _super.call(this, x, y, size);
            }
            return Food;
        })(GameObject);
        GameObjects.Food = Food;

        var SnakePart = (function (_super) {
            __extends(SnakePart, _super);
            function SnakePart(x, y, size) {
                _super.call(this, x, y, size);
            }
            return SnakePart;
        })(GameObject);
        GameObjects.SnakePart = SnakePart;

        var Snake = (function () {
            function Snake(x, y, size) {
                var part, i;

                this._direction = 'up';
                this._parts = [];
                this.newDirections = [];
                for (i = size - 1; i >= 0; i -= 1) {
                    part = new SnakePart(x, y + i * GameObject.partSize, GameObject.partSize);
                    this._parts.push(part);
                }
            }
            Snake.prototype.getPosition = function () {
                return this._parts[this._parts.length - 1].getPosition();
            };

            Snake.prototype.getSize = function () {
                return this._parts.length;
            };

            Snake.prototype.getParts = function () {
                return this._parts.slice();
            };

            Snake.prototype.move = function () {
                var headPosition = this.getPosition(), newHeadPosition = {
                    x: headPosition.x + Snake.directions[this._direction].dx * GameObject.partSize,
                    y: headPosition.y + Snake.directions[this._direction].dy * GameObject.partSize
                };

                this._parts.push(new SnakePart(newHeadPosition.x, newHeadPosition.y, GameObject.partSize));
                this._parts.shift();
            };

            Snake.prototype.changeDirection = function () {
                var newDirection = this.newDirections.shift();

                if (newDirection === 'up' && this._direction !== 'down') {
                    this._direction = 'up';
                } else if (newDirection === 'down' && this._direction !== 'up') {
                    this._direction = 'down';
                } else if (newDirection === 'right' && this._direction !== 'left') {
                    this._direction = 'right';
                } else if (newDirection === 'left' && this._direction !== 'right') {
                    this._direction = 'left';
                }
            };

            Snake.prototype.grow = function () {
                var theNewPart = new SnakePart(this._parts[0].getPosition().x, this._parts[0].getPosition().y, GameObject.partSize);

                this._parts.unshift(theNewPart);
            };

            Snake.prototype.hasCrashedIntoItself = function () {
                var headPosition = this.getPosition(), partPosition, i;

                for (i = 0; i < this._parts.length - 1; i += 1) {
                    partPosition = this._parts[i].getPosition();
                    if (partPosition.x === headPosition.x && partPosition.y === headPosition.y) {
                        return true;
                    }
                }

                return false;
            };
            Snake.directions = {
                up: { dx: 0, dy: -1 },
                down: { dx: 0, dy: 1 },
                left: { dx: -1, dy: 0 },
                right: { dx: 1, dy: 0 }
            };
            return Snake;
        })();
        GameObjects.Snake = Snake;
    })(SnakeGame.GameObjects || (SnakeGame.GameObjects = {}));
    var GameObjects = SnakeGame.GameObjects;
})(SnakeGame || (SnakeGame = {}));
//# sourceMappingURL=game-objects.js.map
