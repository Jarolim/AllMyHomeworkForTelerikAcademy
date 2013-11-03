(function () {
    'use strict';

    var myConsole = (function () {
        var writeLine = function () {
            var args = Array.prototype.slice.call(arguments);
            if (args.length > 0) {
                var outputString = createString(args);
                console.log(outputString);
            }          
        };

        var writeError = function () {
            var args = Array.prototype.slice.call(arguments);
            if (args.length > 0) {
                var outputString = createString(args);
                console.error(outputString);
            }
        };

        function createString(dataArr) {
            var regExp = new RegExp('(\\{(0)\\})', ['gi']);
            var workString = dataArr[0].toString();
            var ocurrArr = workString.match(regExp);
            var count = 1;
            while (ocurrArr) {
                workString = workString.replace(regExp, (dataArr[count] || '').toString());
                regExp = new RegExp('(\\{(' + count + ')\\})', ['gi']);
                ocurrArr = workString.match(regExp);
                count++;
            }

            return workString;
        }

        return {
            writeLine: writeLine,
            writeError: writeError
        };
    })();
    myConsole.writeLine('Myyyy teeessttt!');
    myConsole.writeLine('Placeholders {1} {0}{2}', 'placeholders', 'some', '!');
    myConsole.writeLine('Placeholders with missing params {1} {0}{2} ', 'placeholders', 'some');
    myConsole.writeError('Error test!');
    myConsole.writeError('Error test placeholders {1} {0}{2}', 'placeholders', 'some', '!');
    myConsole.writeError('Error test placeholders with missing params {1} {0}{2}', 'placeholders', 'some');
})();