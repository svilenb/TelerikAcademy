function Solve(args) {
    var functions = {},
    result,
    lineNumber,
    dividedByZero = false;

    function isOperator(ch) {
        switch (ch) {
            case '+':
                return true;
            case '-':
                return true;
            case '/':
                return true;
            case '*':
                return true;
            default:
                return false;
        }
    }

    function isDigit(ch) {
        if (isFinite(ch) && ch !== ' ') {
            return true;
        }

        return false;
    }

    function processOperation(operator, numbers) {
        var result,
            i;

        switch (operator) {
            case '+':
                result = 0;
                for (i = 0; i < numbers.length; i++) {
                    result += numbers[i];
                }

                return result;
            case '-':
                result = numbers[0];
                for (i = 1; i < numbers.length; i++) {
                    result -= numbers[i];
                }

                return result;
            case '/':
                result = numbers[0];
                for (i = 1; i < numbers.length; i++) {
                    if (numbers[i] === 0) {
                        dividedByZero = true;
                        return 0;
                    }

                    result = parseInt(result / numbers[i], 10);
                }

                return result;
            case '*':
                result = 1;
                for (i = 0; i < numbers.length; i++) {
                    result *= numbers[i];
                }

                return result;
            default:
                break;
        }
    }

    function processLine(line) {
        var i,
            currentChar,
            buildedNumber = '',
            nestedNumbers = [],
            funcNameOrDef = '',
            definingFunc = '',
            isNested = false,
            operators = [],
            numbers = [],
            currentResult,
            currentFunc;

        for (i = 1; i < line.length; i += 1) {
            currentChar = line[i];
            if (currentChar === ' ') {
                continue;
            } else if (isOperator(currentChar)) {
                operators.push(currentChar);
            } else if (currentChar === '(') {
                isNested = true;
            } else if (currentChar === ')') {
                if (definingFunc.length !== 0 && isNested) {
                    functions[definingFunc] = processOperation(operators.pop(), nestedNumbers);
                    nestedNumbers = [];
                    isNested = false;
                } else if (!isNested && operators.length > 0) {
                    return processOperation(operators.pop(), numbers);
                } else if (isNested) {
                    currentResult = processOperation(operators.pop(), nestedNumbers);
                    numbers.push(currentResult);
                    nestedNumbers = [];
                    isNested = false;
                }
            } else if (isDigit(currentChar) && funcNameOrDef === '') {
                buildedNumber += currentChar;
                if (!isDigit(line[i + 1])) {
                    if (isNested) {
                        nestedNumbers.push(parseInt(buildedNumber, 10));
                    } else if (definingFunc.length !== 0) {
                        functions[definingFunc] = parseInt(buildedNumber, 10);
                        definingFunc = '';
                    } else {
                        numbers.push(parseInt(buildedNumber, 10));
                    }

                    buildedNumber = '';
                }
            } else {
                funcNameOrDef += currentChar;
                if (line[i + 1] === ' ' && funcNameOrDef === 'def') {
                    funcNameOrDef = '';
                } else if ((line[i + 1] === ' ' || line[i + 1] === ')') && funcNameOrDef !== 'def') {
                    currentFunc = funcNameOrDef;
                    funcNameOrDef = '';
                    if (functions[currentFunc] !== undefined) {
                        if (isNested) {
                            nestedNumbers.push(functions[currentFunc]);
                        } else if (!isNested) {
                            numbers.push(functions[currentFunc]);
                        }
                    } else {
                        definingFunc = currentFunc;
                        currentFunc = '';
                    }
                }
            }
        }
    }

    for (lineNumber = 0; lineNumber < args.length; lineNumber += 1) {
        result = processLine(args[lineNumber].trim());
        if (dividedByZero) {
            return 'Division by zero! At Line:' + (lineNumber + 1);
        }
    }

    return result;
}

function handleIO() {
    var test1 = [
        '(def func 10)',
        '(def newFunc (+  func 2))',
        '(def sumFunc (+ func func newFunc 0 0 0))',
        '(* sumFunc 2)'
    ];

    var test2 = [
        '(def func (+ 5 2))',
        '(def func2 (/  func 5 2 1 0))',
        '(def func3 (/ func 2))',
        '(+ func3 func)'
    ];

    console.log(Solve(test1));
}