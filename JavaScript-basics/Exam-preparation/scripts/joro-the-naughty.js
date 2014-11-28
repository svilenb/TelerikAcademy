function Solve(args) {
    function buildJump(row, col) {
        return {
            row: row,
            col: col
        };
    }

    function hasEscaped(row, col) {
        if (row < 0 || row >= N || col < 0 || col >= M) {
            return true;
        } else {
            return false;
        }
    }

    function isCaught(row, col) {
        if (field[row][col] === 'visited') {
            return true;
        } else {
            return false;
        }
    }

    var firstLine = args[0].split(' ').map(Number),
        N = firstLine[0],
        M = firstLine[1],
        J = firstLine[2],
        currentRowAndCol = args[1].split(' ').map(Number),
        jumps = [],
        i,
        j,
        currentLine,
        field = [],
        counter = 1,
        sumOfNumbers = 0,
        numberOfJumps = 0;

    for (i = 2; i < args.length; i++) {
        currentLine = args[i].split(' ').map(Number);
        jumps.push(buildJump(currentLine[0], currentLine[1]));
    }

    for (i = 0; i < N; i++) {
        field[i] = [];
        for (j = 0; j < M; j++) {
            field[i].push(counter);
            counter += 1;
        }
    }

    counter = 0;
    while (true) {
        if (hasEscaped(currentRowAndCol[0], currentRowAndCol[1])) {
            return 'escaped' + ' ' + sumOfNumbers;
        }

        if (isCaught(currentRowAndCol[0], currentRowAndCol[1])) {
            return 'caught' + ' ' + numberOfJumps;
        }

        sumOfNumbers += field[currentRowAndCol[0]][currentRowAndCol[1]];
        field[currentRowAndCol[0]][currentRowAndCol[1]] = 'visited';
        numberOfJumps += 1;
        currentRowAndCol[0] += jumps[counter].row;
        currentRowAndCol[1] += jumps[counter].col;
        counter = (counter + 1) % jumps.length;
    }
}

function HandleIO() {
    var args = [];
    args[0] = '6 7 3';
    args[1] = '0 0';
    args[2] = '2 2';
    args[3] = '-2 2';
    args[4] = '3 -1';
    console.log(Solve(args));
}