function Solve(args) {
    var digits = ['-!', '**', '!!!', '&&', '&-', '!-', '*!!!', '&*!', '!!**!-'],
        numSystBase = digits.length,
        i,
        j,
        digitsInNumber = [],
        funnyNumber = args[0],
        currentDigit = '',
        digitPos = 0,
        result = 0;

    for (i = 0; i < funnyNumber.length; i++) {
        currentDigit += funnyNumber[i];
        for (j = 0; j < digits.length; j++) {
            if (currentDigit === digits[j]) {
                digitsInNumber.push(j);
                currentDigit = '';
                break;
            }
        }
    }

    for (i = digitsInNumber.length - 1; i >= 0; i--) {
        result += digitsInNumber[i] * Math.pow(numSystBase, digitPos);
        digitPos++;
    }

    return result;
}

function handleIO() {
    var args = [];
    args[0] = '!!**!-';
    console.log(Solve(args));
}