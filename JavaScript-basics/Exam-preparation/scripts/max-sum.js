function Solve(args) {
    var numbers = args.map(Number),
        i,
        j,
        bestSum = -2000000,
        currentSum = 0;

    for (i = 1; i < numbers.length; i++) {
        currentSum = 0;
        for (j = i; j < numbers.length; j++) {
            currentSum += numbers[j];
            if (currentSum > bestSum) {
                bestSum = currentSum;
            }
        }
    }

    return bestSum;
}

function handleInputOutput() {
    var test1 = ['8', '1', '6', '-9', '4', '4', '-2', '10', '-1'],
        test2 = ['6', '1', '3', '-5', '8', '7', '-6'],
        test3 = ['9', '-9', '-8', '-8', '-7', '-6', '-5', '-1', '-7', '-6'];

    console.log(Solve(test3));
}