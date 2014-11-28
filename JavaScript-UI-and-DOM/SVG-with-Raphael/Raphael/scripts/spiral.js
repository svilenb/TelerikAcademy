(function () {
    //Archimedean spiral r = a + b.angle
    var paper = Raphael(50, 50, 500, 500),
        spiralPoints = [
            {
                x: 250,
                y: 250
            }
        ],
        i,
        a,
        b,
        r,
        rx,
        ry,
        pathPoints = 'M' + spiralPoints[0].x + ' ' + spiralPoints[0].y + ' ';

    function generateSpiralPoints(maxAngle, a, b) {
        var angle;

        for (angle = 1; angle < maxAngle; angle += 0.2) {
            r = a + b * angle;
            rx = spiralPoints[0].x + Math.cos(angle) * r;
            ry = spiralPoints[0].y + Math.sin(angle) * r;
            spiralPoints.push(
                {
                    x: rx,
                    y: ry
                }
            );
        }
    }

    generateSpiralPoints(50, 1, 3);

    for (i = 0; i < spiralPoints.length; i += 1) {
        pathPoints += 'L' + spiralPoints[i].x + ' ' + spiralPoints[i].y + ' ';
    }

    paper.path(pathPoints);
}());