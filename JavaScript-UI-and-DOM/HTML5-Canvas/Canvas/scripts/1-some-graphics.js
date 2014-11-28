window.onload = function () {
    var canvas = document.getElementById('the-canvas'),
        context = canvas.getContext('2d');

    function drawHumanHead() {
        var eyeYPosition = 150;

        function drawFaceWithEyes() {
            var faceRadius = 60,
                eyeRadius = 10,
                retinaRadius = 5;

            context.save();
            context.strokeStyle = 'darkblue';
            context.fillStyle = 'skyblue';
            context.arc(170, 170, faceRadius, 0, 360 * Math.PI / 180);
            context.fill();
            context.stroke();
            context.beginPath();
            context.scale(1, 0.5);
            context.arc(180, eyeYPosition / 0.5, eyeRadius, 0, 360 * Math.PI / 180);
            context.moveTo(140 + eyeRadius, 150 / 0.5);
            context.arc(140, eyeYPosition / 0.5, eyeRadius, 0, 360 * Math.PI / 180);
            context.fill();
            context.stroke();
            context.beginPath();

            context.fill();
            context.stroke();
            context.beginPath();
            context.scale(0.5, 2);
            context.fillStyle = 'darkblue';
            context.arc(136 / 0.5, eyeYPosition, retinaRadius, 0, 360 * Math.PI / 180);
            context.fill();
            context.stroke();
            context.beginPath();
            context.arc(176 / 0.5, eyeYPosition, retinaRadius, 0, 360 * Math.PI / 180);
            context.fill();
            context.stroke();
            context.beginPath();
            context.restore();
        }

        function drawMouth() {
            context.save();
            context.lineWidth = '2';
            context.strokeStyle = 'darkblue';
            context.rotate(15 * Math.PI / 180);
            context.scale(1, 0.3);
            context.arc(205, 270 / 0.5, 20, 0, 360 * Math.PI / 180);
            context.stroke();
            context.restore();
        }

        function drawNose() {
            context.save();
            context.strokeStyle = 'darkblue';
            context.beginPath();
            context.moveTo(160, eyeYPosition);
            context.lineTo(145, eyeYPosition + 30);
            context.lineTo(155, eyeYPosition + 30);
            context.stroke();
            context.restore();
        }

        function drawHat() {
            context.save();
            context.strokeStyle = 'darkblue';
            context.lineWidth = '2';
            context.fillStyle = 'rgb(0, 128, 192)';
            context.save();
            context.scale(1, 0.3);
            context.beginPath();
            context.arc(165, (eyeYPosition - 30) / 0.3, 60, 0, 2 * Math.PI);
            context.fill();
            context.stroke();
            context.beginPath();
            context.restore();
            context.moveTo(130, eyeYPosition - 100);
            context.lineTo(130, eyeYPosition - 42);
            context.quadraticCurveTo(165, eyeYPosition - 30, 200, eyeYPosition - 42);
            context.lineTo(200, eyeYPosition - 100);
            context.fill();
            context.stroke();
            context.scale(1, 0.3);
            context.beginPath();
            context.arc(165, (eyeYPosition - 100) / 0.3, 35, 0, 2 * Math.PI);
            context.fill();
            context.stroke();
            context.restore();
        }

        drawFaceWithEyes();
        drawMouth();
        drawNose();
        drawHat();
    }

    function drawBike() {
        function drawWheels() {
            context.save();
            context.strokeStyle = 'rgb(50, 130, 148)';
            context.fillStyle = 'rgb(144, 202, 215)';
            context.beginPath();
            context.arc(350, 170, 50, 0, 2 * Math.PI);
            context.moveTo(600, 170);
            context.arc(550, 170, 50, 0, 2 * Math.PI);
            context.fill();
            context.stroke();
            context.restore();
        }

        function drawFrame() {
            context.save();
            context.lineWidth = '2';
            context.strokeStyle = 'rgb(50, 130, 148)';
            context.beginPath();
            context.moveTo(350, 170);
            context.lineTo(440, 170);
            context.lineTo(520, 100);
            context.lineTo(410, 100);
            context.lineTo(350, 170);
            context.moveTo(440, 170);
            context.lineTo(410, 100);
            context.lineTo(404, 85);
            context.moveTo(390, 85);
            context.lineTo(420, 85);
            context.moveTo(550, 170);
            context.lineTo(510, 80);
            context.lineTo(480, 85);
            context.moveTo(510, 80);
            context.lineTo(530, 60);
            context.stroke();
            context.beginPath();
            context.arc(440, 170, 15, 0, 2 * Math.PI);
            context.moveTo(465, 190);
            context.lineTo(451, 178);
            context.moveTo(413, 150);
            context.lineTo(427, 163);
            context.stroke();
            context.restore();
        }

        drawWheels();
        drawFrame();
    }

    function drawHouse() {
        context.fillStyle = '975B5B';
        context.strokeStyle = 'black';

        function drawWalls() {
            context.beginPath();
            context.lineWidth = '2';
            context.fillRect(650, 150, 250, 200);
            context.strokeRect(650, 150, 250, 200);
            context.fill();
            context.stroke();
        }

        function drawWindows() {
            context.beginPath();
            context.lineWidth = '2';
            context.fillStyle = 'black';
            context.strokeStyle = '975B5B';
            context.fillRect(670, 180, 95, 65);
            context.moveTo(670, 212);
            context.lineTo(765, 212);
            context.moveTo(717, 180);
            context.lineTo(717, 245);
            context.moveTo(755, 180);
            context.fillRect(785, 180, 95, 65);
            context.moveTo(785, 212);
            context.lineTo(880, 212);
            context.moveTo(832, 180);
            context.lineTo(832, 245);
            context.moveTo(785, 265);
            context.fillRect(785, 265, 95, 65);
            context.moveTo(785, 297);
            context.lineTo(880, 297);
            context.moveTo(832, 265);
            context.lineTo(832, 330);
            context.fill();
            context.stroke();
        }

        function drawDoor() {
            context.beginPath();
            context.strokeStyle = 'black';
            context.lineWidth = '2';
            context.moveTo(680, 350);
            context.lineTo(680, 285);
            context.bezierCurveTo(695, 255, 735, 255, 750, 285);
            context.lineTo(750, 350);
            context.moveTo(715, 350);
            context.lineTo(715, 262);
            context.stroke();
            context.beginPath();
            context.arc(705, 325, 4, 0, 2 * Math.PI);
            context.stroke();
            context.beginPath();
            context.arc(725, 325, 4, 0, 2 * Math.PI);
            context.stroke();
        }

        function drawRoof() {
            context.fillStyle = '975B5B';
            context.strokeStyle = 'black';
            context.lineWidth = '2';
            context.beginPath();
            context.moveTo(650, 150);
            context.lineTo(775, 40);
            context.lineTo(900, 150);
            context.closePath();
            context.fill();
            context.stroke();
            context.beginPath();
            context.moveTo(830, 120);
            context.lineTo(830, 60);
            context.lineTo(850, 60);
            context.lineTo(850, 120);
            context.fill();
            context.save();
            context.scale(1, 0.2);
            context.arc(840, 60 / 0.2, 10, 0, 2 * Math.PI);
            context.fill();
            context.stroke();
            context.restore();
        }

        drawWalls();
        drawWindows();
        drawDoor();
        drawRoof();
    }

    drawHumanHead();
    drawBike();
    drawHouse();
};