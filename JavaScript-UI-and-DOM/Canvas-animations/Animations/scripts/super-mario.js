(function () {
    var stage, marioLayer, sprite, movingAnimation, mario, paper, size, i, set;

    size = 500;
    paper = Raphael(300, 10, size, size);

    paper.rect(0, 0, size, size).attr({
        fill: '#63FFEF'
    });

    paper.path("M30 470 L100 330 C125 300 155 300 180 330 L250 470").
        attr({
            fill: '#286933'
        });

    paper.image('../images/cloud.png', 350, 80, 90, 50);
    paper.image('../images/cloud.png', 220, 280, 90, 50);
    paper.image('../images/cloud.png', 120, 180, 90, 50);

    paper.setStart();
    for (i = 0; i < 500; i += 20) {
        paper.rect(i, 470, 20, 30);
    }

    set = paper.setFinish();
    set.attr({
        fill: '#FF4D3D',
        stroke: '#234D3D',
        'stroke-width': 2
    });

    stage = new Kinetic.Stage({
        container: 'container',
        width: size,
        height: size
    });

    marioLayer = new Kinetic.Layer();
    sprite = new Image();

    sprite.onload = function () {
        mario = new Kinetic.Sprite({
            x: stage.width / 2,
            y: 420,
            image: sprite,
            animation: 'walk',
            animations: {
                walk: [
                  19, 10, 33, 45,
                  140, 6, 46, 48,
                  58, 6, 37, 48
                ]
            },
            frameRate: 10,
            frameIndex: 4
        });

        marioLayer.add(mario);
        stage.add(marioLayer);
        mario.start();

        movingAnimation = new Kinetic.Animation(function () {
            var speed = 2;

            if (mario.x() + speed < stage.width()) {
                mario.setX(mario.x() + speed);
            } else {
                mario.setX(0);
            }
        }, marioLayer);

        movingAnimation.start();
    };

    sprite.src = '../images/walk-sprite.png';
}());