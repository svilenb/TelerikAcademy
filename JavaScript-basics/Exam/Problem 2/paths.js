function solve(args) {
    var rowsAndCols = args[0].split(' ').map(Number),
        directions = [],
        i,
        currentRowAndCol = [0, 0],
        sum = 0,
        field = [],
        j,
        direction = {
            dr: {
                row: 1,
                col: 1
            },
            ur: {
                row: -1,
                col: 1
            },
            ul: {
                row: -1,
                col: -1
            },
            dl: {
                row: +1,
                col: -1
            }
        },
        currentDirection = '';


    function isOut(row, col) {
        if (row < 0 || row >= rowsAndCols[0] ||
            col < 0 || col >= rowsAndCols[1]) {
            return true;
        } else {
            return false;
        }
    }

    function twoOnPower(power) {
        var result = 1;

        for (var k = 0; k < power; k++) {
            result *= 2;
        }

        return result;
    }

    for (i = 1; i < args.length; i++) {
        directions[i - 1] = args[i].split(' ');
    }

    for (i = 0; i < rowsAndCols[0]; i++) {
        field[i] = [];
        var startingValue = twoOnPower(i);
        var counter = 0;
        for (j = 0; j < rowsAndCols[1]; j++) {
            field[i][j] = startingValue + counter;
            counter++;
        }
    }

    while (true) {
        if (isOut(currentRowAndCol[0], currentRowAndCol[1])) {
            return 'successed with ' + sum;
        }

        if (field[currentRowAndCol[0]][currentRowAndCol[1]] === 'visited') {
            return 'failed at ' + '(' + currentRowAndCol[0] + ', ' + currentRowAndCol[1] + ')';
        }

        sum += field[currentRowAndCol[0]][currentRowAndCol[1]];
        field[currentRowAndCol[0]][currentRowAndCol[1]] = 'visited';
        currentDirection = directions[currentRowAndCol[0]][currentRowAndCol[1]];
        currentRowAndCol[0] += direction[currentDirection].row;
        currentRowAndCol[1] += direction[currentDirection].col;
    }
}