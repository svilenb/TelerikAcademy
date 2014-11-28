module SnakeGame.GameObjects {
    export interface IMovable {
        move(): void;
    }

    export interface IGameObject {
        getPosition(): { x: number; y: number };
        getSize(): number;
    }

    export class GameObject implements IGameObject {
        static partSize: number = 20;
        private _x: number;
        private _y: number;
        private _size: number;

        constructor(x: number, y: number, size: number) {
            this._x = x;
            this._y = y;
            this._size = size;
        }

        getPosition(): { x: number; y: number } {
            return {
                x: this._x,
                y: this._y
            };
        }

        getSize(): number {
            return this._size;
        }
    }

    export class Food extends GameObject {
        constructor(x: number, y: number, size: number) {
            super(x, y, size);
        }
    }

    export class SnakePart extends GameObject {
        constructor(x: number, y: number, size: number) {
            super(x, y, size);
        }
    }

    export class Snake implements IGameObject, IMovable {
        static directions = {
            up: { dx: 0, dy: -1 },
            down: { dx: 0, dy: 1 },
            left: { dx: -1, dy: 0 },
            right: { dx: 1, dy: 0 }
        };
        newDirections: string[];
        private _direction: string;
        private _parts: SnakePart[];

        constructor(x: number, y: number, size: number) {
            var part: GameObjects.SnakePart,
                i: number;

            this._direction = 'up';
            this._parts = [];
            this.newDirections = [];
            for (i = size - 1; i >= 0; i -= 1) {
                part = new SnakePart(x, y + i * GameObject.partSize, GameObject.partSize);
                this._parts.push(part);
            }
        }

        getPosition(): { x: number; y: number } {
            return this._parts[this._parts.length - 1].getPosition()
        }

        getSize(): number {
            return this._parts.length;
        }

        getParts() {
            return this._parts.slice();
        }

        move(): void {
            var headPosition = this.getPosition(),
                newHeadPosition = {
                    x: headPosition.x + Snake.directions[this._direction].dx * GameObject.partSize,
                    y: headPosition.y + Snake.directions[this._direction].dy * GameObject.partSize
                };

            this._parts.push(new SnakePart(newHeadPosition.x, newHeadPosition.y, GameObject.partSize));
            this._parts.shift();
        }

        changeDirection(): void {
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
        }

        grow(): void {
            var theNewPart = new SnakePart(
                this._parts[0].getPosition().x,
                this._parts[0].getPosition().y,
                GameObject.partSize
                );

            this._parts.unshift(theNewPart);
        }

        hasCrashedIntoItself(): boolean {
            var headPosition = this.getPosition(),
                partPosition,
                i: number;

            for (i = 0; i < this._parts.length - 1; i += 1) {
                partPosition = this._parts[i].getPosition();
                if (partPosition.x === headPosition.x && partPosition.y === headPosition.y) {
                    return true;
                }
            }

            return false;
        }
    }
}