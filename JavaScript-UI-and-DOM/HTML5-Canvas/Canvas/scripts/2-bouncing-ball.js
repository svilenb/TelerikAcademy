var intervalID,
    x = 100,
    y = 75,
    upgrade = {
        deltaX: 1,
        deltaY: 1
    };

function onStartButtonClick() {
    var canvas = document.getElementById('the-canvas'),
        context = canvas.getContext('2d'),
        ballRadius = 10;

    context.fillStyle = 'green';
    context.strokeStyle = 'black';

    function moveBall() {
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.beginPath();
        context.arc(x, y, ballRadius, 0, 2 * Math.PI);
        context.fill();
        context.stroke();

        if (x >= canvas.width - ballRadius && upgrade.deltaX === 1) {
            upgrade.deltaX = -1;
        } else if (x <= ballRadius && upgrade.deltaX === -1) {
            upgrade.deltaX = 1;
        }

        if (y >= canvas.height - ballRadius && upgrade.deltaY === 1) {
            upgrade.deltaY = -1;
        } else if (y <= ballRadius && upgrade.deltaY === -1) {
            upgrade.deltaY = 1;
        }

        x += upgrade.deltaX;
        y += upgrade.deltaY;
    }

    intervalID = window.setInterval(moveBall, 10);
}

function onEndButtonClick() {
    window.clearInterval(intervalID);
}
