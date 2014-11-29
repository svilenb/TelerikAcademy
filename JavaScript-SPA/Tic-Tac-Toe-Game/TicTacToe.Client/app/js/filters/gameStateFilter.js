app.filter('gameState', function () {
    return function (input) {
        input = parseInt(input);
        switch (input) {
            case 0: return "WaitingForSecondPlayer";
            case 1: return "TurnX";
            case 2: return "TurnO";
            case 3: return "WonByX";
            case 4: return "WonByO";
            case 5: return "Draw";
        }
    }
})