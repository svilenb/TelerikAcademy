var specialConsole = (function () {
    var self;

    function replacePlaceholders(string, args) {
        var i,
            argumentsLength,
            placeholder;

        for (i = 1, argumentsLength = args.length; i < argumentsLength; i += 1) {
            placeholder = "{" + (i - 1) + "}";
            while (string.indexOf(placeholder) > -1) {
                string = string.replace(placeholder, arguments[i]);
            }
        }

        return string;
    }

    function writeLine(message, args) {
        message = message.toString();

        if (!args) {
            console.log(message);
        } else {
            console.log(replacePlaceholders(message, args));
        }
    }

    function writeError(message, args) {
        message = message.toString();

        if (!args) {
            console.error(message);
        } else {
            console.error(replacePlaceholders(message, args));
        }
    }

    function writeWarning(message, args) {
        message = message.toString();

        if (!args) {
            console.warn(message);
        } else {
            console.warn(replacePlaceholders(message, args));
        }
    }

    self = {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };

    return self;
}());
