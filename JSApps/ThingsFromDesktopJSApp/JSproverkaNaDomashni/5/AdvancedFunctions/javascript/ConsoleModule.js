var myConsole = (function () {
    function writeLine(value, params) {
        var result = formatString.apply(null, arguments);
        console.log(result);
    }

    function writeError(value, params) {
        var result = formatString.apply(null, arguments);
        console.error(result);
    }

    function writeWarning(value, params) {
        var result = formatString.apply(null, arguments);
        console.warn(result);
    }

    function formatString(value, params) {
        var result = "";

        if (value) {
            result = value.toString();

            if (params) {
                var argsCount = arguments.length;

                for (var i = 0; i < argsCount - 1; i++) {
                    var pattern = "\\{" + i + "\\}";
                    var regex = new RegExp(pattern, "g");

                    result = result.replace(regex, arguments[i + 1].toString());
                }
            }
        }

        return result;


    }
    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };

})();

myConsole.writeLine("javasript rocks");
myConsole.writeLine("Hello: {0}", "javascript");
myConsole.writeError("Error: {0}", "a lot of errors in javascript");
myConsole.writeWarning("Warning: {0}", "this is javascript");

var array = [1231, 1232, 321, 12, 123, 32];

myConsole.writeLine("Array: {0}", array);
myConsole.writeLine("Number: {0}", 12341.2134);
