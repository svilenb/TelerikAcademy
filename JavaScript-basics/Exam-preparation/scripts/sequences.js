function Solve(args) {
    var sequenceLength = parseInt(args[0], 10),
        i,
        previousNum = parseInt(args[1], 10),
        currentNum,
        numOfSeq = 1;

    for (i = 2; i <= sequenceLength; i++) {
        currentNum = parseInt(args[i], 10);
        if (currentNum < previousNum) {
            numOfSeq++;
        }

        previousNum = currentNum;
    }

    return numOfSeq;
}

function HandleIO() {
    var args = ['6', '1', '3', '-5', '8', '7', '-6'];
    console.log(Solve(args));
}