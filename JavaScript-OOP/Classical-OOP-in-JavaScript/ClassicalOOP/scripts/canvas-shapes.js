var CanvasDrawer = (function () {
    function CanvasDrawer(containerID) {
        this.canvas = document.getElementById(containerID);
        this.context = this.canvas.getContext('2d');
    }

    CanvasDrawer.prototype.drawRect = function (x, y, width, height) {
        this.context.strokeRect(x, y, width, height);
    };

    CanvasDrawer.prototype.drawCircle = function (x, y, radius) {
        this.context.arc(x, y, radius, 2 * Math.PI, 0);
        this.context.stroke();
    };

    CanvasDrawer.prototype.drawLine = function (x1, y1, x2, y2) {
        this.context.beginPath();
        this.context.moveTo(x1, y1);
        this.context.lineTo(x2, y2);
        this.context.stroke();
    }

    return CanvasDrawer;
}());