module SnakeGame.Renderers {
    export interface IRenderer {
        draw(obj: any): void;
        clear(): void;
        getDimensions(): {
            minWidth: number;
            maxWidth: number;
            minHeight: number;
            maxHeight: number
        };
    }

    export class CanvasRenderer implements IRenderer {
        private _canvas;
        private _context;

        constructor(selector: any) {
            if (selector instanceof HTMLCanvasElement) {
                this._canvas = selector;
            } else if (String(typeof selector).toLowerCase() === 'string') {
                this._canvas = document.querySelector(selector);
            }

            this._context = this._canvas.getContext('2d');
        }

        draw(obj: any): void {
            if (obj instanceof GameObjects.Snake) {
                this.drawSnake(obj);
            } else if (obj instanceof GameObjects.SnakePart) {
                this.drawSnakePart(obj);
            } else if (obj instanceof GameObjects.Food) {
                this.drawFood(obj);
            } else if (String(typeof obj).toLowerCase() === 'string') {
                this.drawMessage(obj);
            }
        }

        clear(): void {
            var width: number = this._canvas.width,
                height: number = this._canvas.height;

            this._context.clearRect(0, 0, width, height);
        }

        getDimensions() {
            return {
                minWidth: 0,
                maxWidth: this._canvas.width,
                minHeight: 0,
                maxHeight: this._canvas.height
            };
        }

        private drawSnakePart(snakePart: GameObjects.SnakePart) {
            var position = snakePart.getPosition(),
                size = snakePart.getSize();

            this._context.fillStyle = 'green';
            this._context.strokeStyle = 'black';
            this._context.fillRect(position.x, position.y, size, size);
            this._context.strokeRect(position.x, position.y, size, size);
        }

        private drawSnake(snake: GameObjects.Snake) {
            var i: number,
                parts = snake.getParts();

            for (i = 0; i < parts.length; i += 1) {
                this.drawSnakePart(parts[i]);
            }
        }

        private drawFood(food: GameObjects.Food) {
            var position = food.getPosition(),
                size: number = food.getSize();

            this._context.fillStyle = 'orange';
            this._context.fillRect(position.x, position.y, size, size);
        }

        private drawMessage(message: string): void {
            this._context.font = '38px Consolas';
            this._context.fillStyle = 'red';
            this._context.fillText(message, this._canvas.width / 6, this._canvas.height / 2);
        }
    }
}