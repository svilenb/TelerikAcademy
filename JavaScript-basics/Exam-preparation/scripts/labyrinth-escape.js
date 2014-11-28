function Solve(args) {
    var rowsAndCols = args[0].split(' ').map(Number),
        currentRowAndCol = args[1].split(' ').map(Number),
        lab = args.slice(2),
        visited = {},
        sum = 0,
        count = 0,
        currentDirection,
        currentValue,
        directions = {
            u: {
                row: -1,
                col: 0
            },
            r: {
                row: 0,
                col: 1
            },
            d: {
                row: 1,
                col: 0
            },
            l: {
                row: 0,
                col: -1
            }
        };

    function getValue(row, col, colsNumber) {
        return row * colsNumber + col + 1;
    }

    while (true) {
        currentValue = getValue(currentRowAndCol[0], currentRowAndCol[1], rowsAndCols[1]);

        if (currentRowAndCol[0] < 0 || currentRowAndCol[0] >= rowsAndCols[0]
            || currentRowAndCol[1] < 0 || currentRowAndCol[1] >= rowsAndCols[1]) {
            return 'out ' + sum;
        }

        if (visited[currentValue]) {
            return 'lost ' + count;
        }

        sum += currentValue;
        count++;
        visited[currentValue] = true;
        currentDirection = lab[currentRowAndCol[0]][currentRowAndCol[1]];
        currentRowAndCol[0] += directions[currentDirection].row;
        currentRowAndCol[1] += directions[currentDirection].col;
    }
}

function HandleInputOutput() {
    var test1 = [
        "3 4",
        "1 3",
        "lrrd",
        "dlll",
        "rddd"
    ];

    var test2 = [
        "5 8",
         "0 0",
         "rrrrrrrd",
         "rludulrd",
         "durlddud",
         "urrrldud",
         "ulllllll"
    ];

    var test3 = [
        "5 8",
        "0 0",
        "rrrrrrrd",
        "rludulrd",
        "lurlddud",
        "urrrldud",
        "ulllllll"
    ];

    console.log(Solve(test3));
}