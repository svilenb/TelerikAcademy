function solve(args) {
    var N = parseInt(args[0], 10),
        M = parseInt(args[N + 1], 10),
        dictionary = {},
        sections = {},
        i,
        output = [],
        currentOutput = '',
        outputAsString = '',
        readingSectionValue = false,
        buildedSectionValue = [],
        sectionIndex = 0,
        specialState = false,
        buildedSectionKey = '',
        definingSectionState = false,
        argsLength;

    function isBoolean(input) {
        if (input === 'true' || input === 'false') {
            return true;
        }

        return false;
    }

    function asBoolean(input) {
        if (input === "true") {
            return true;
        } else if (input === 'false') {
            return false;
        }
    }

    function extractKeyValuePair(line) {
        var inKeyState = true,
            inValueState = false,
            buildedKey = '',
            buildedValue = '',
            i,
            lineLength,
            ch,
            arrayValue = false;

        for (i = 0, lineLength = line.length; i < lineLength; i++) {
            ch = line[i];
            if (inKeyState) {
                if (ch !== ':' && ch !== ' ') {
                    buildedKey += ch;
                } else if (ch === ':') {
                    inKeyState = false;
                    inValueState = true;
                }
            } else if (inValueState) {
                if (ch !== ',' && ch !== ' ') {
                    buildedValue += ch;
                } else if (ch === ',') {
                    arrayValue = true;
                    buildedValue += ch;
                }
            }
        }

        if (!arrayValue) {
            if (isBoolean(buildedValue)) {
                dictionary[buildedKey] = asBoolean(buildedValue);
            } else {
                dictionary[buildedKey] = buildedValue;
            }
        } else if (arrayValue) {
            dictionary[buildedKey] = buildedValue.split(',');
        }
    }

    function isInDictionary(input) {
        var key;

        for (key in dictionary) {
            if (input === key) {
                return true;
            }
        }

        return false;
    }

    function renderSection(section, tabs) {
        var i,
            sectionLength,
            output = '';

        for (i = 0, sectionLength = section.length; i < sectionLength - 1; i++) {
            if (i !== sectionLength - 2) {
                output += new Array(tabs).join(' ') + section[i] + '\n';
            } else {
                output += new Array(tabs).join(' ') + section[i];
            }
        }

        return output;
    }

    function parseHTML(line) {
        var renderingSectionState = false,
            buildedResult = '',
            ch,
            buildedKey = '',
            readingSectionKey = false,
            i,
            lineLength,
            tabs;

        for (i = 0, lineLength = line.length; i < lineLength; i++) {
            ch = line[i];
            if (specialState === false && renderingSectionState === false &&
                    definingSectionState === false) {
                if (ch !== '@') {
                    buildedResult += ch;
                } else if (ch === '@') {
                    specialState = true;
                }
            } else if (specialState === true) {
                if (ch === '@' && line[i - 1] === '@') {
                    specialState = false;
                    buildedResult += ch;
                } else if (definingSectionState === false && renderingSectionState === false) {
                    buildedKey += ch;
                    if (isInDictionary(buildedKey)) {
                        buildedResult += dictionary[buildedKey];
                        buildedKey = '';
                        specialState = false;
                    } else if (buildedKey === 'section') {
                        definingSectionState = true;
                        buildedKey = '';
                    } else if (buildedKey === 'renderSection') {
                        renderingSectionState = true;
                        buildedKey = '';
                    }
                } else if (definingSectionState === true) {
                    if (readingSectionKey === false && readingSectionValue === false) {
                        if (ch !== ' ') {
                            buildedKey += ch;
                            readingSectionKey = true;
                        }
                    } else if (readingSectionKey) {
                        if (ch !== ' ') {
                            buildedKey += ch;
                        } else if (ch === ' ') {
                            readingSectionValue = true;
                            buildedSectionValue[sectionIndex] = '';
                            readingSectionKey = false;
                            buildedSectionKey = buildedKey;
                            buildedKey = '';
                        }
                    } else if (readingSectionValue === true) {
                        if (ch !== '}' && ch !== '{') {
                            buildedSectionValue[sectionIndex] += ch;
                            if (i === line.length - 1) {
                                sectionIndex++;
                                buildedSectionValue[sectionIndex] = '';
                            }
                        } else if (ch === '}') {
                            sections[buildedSectionKey] = buildedSectionValue;
                            buildedSectionKey = '';
                            buildedSectionValue = [];
                            sectionIndex = 0;
                            definingSectionState = false;
                            readingSectionValue = false;
                            specialState = false;
                        }
                    }
                } else if (renderingSectionState) {
                    if (readingSectionKey === false) {
                        if (ch === '"') {
                            readingSectionKey = true;
                        } else if (ch === ')') {
                            tabs = line.indexOf('@') + 1;
                            buildedResult = renderSection(sections[buildedSectionKey], tabs);
                            buildedSectionKey = '';
                            renderingSectionState = false;
                            specialState = false;
                        }
                    } else if (readingSectionKey === true) {
                        if (ch !== '"') {
                            buildedSectionKey += ch;
                        } else if (ch === '"') {
                            readingSectionKey = false;
                        }
                    }
                }
            }
        }

        if (definingSectionState === false) {
            return buildedResult;
        } else {
            return '';
        }
    }

    function convertOutputToSting(input) {
        var result = '',
            i;

        for (i = 0; i < input.length - 1; i++) {
            result += input[i] + '\n';
        }

        result += input[input.length - 1];

        return result;
    }

    for (i = 1; i <= N; i++) {
        extractKeyValuePair(args[i]);
    }

    for (i = N + 2, argsLength = args.length; i < argsLength; i++) {
        currentOutput = parseHTML(args[i]);
        if (currentOutput !== '') {
            output.push(currentOutput);
        }
    }

    outputAsString = convertOutputToSting(output);
    return outputAsString;
}