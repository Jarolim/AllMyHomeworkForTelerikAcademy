if (!document.querySelector || !document.querySelectorAll) {
    document.querySelectorAll = function (selector) {
        if (selector[0] === '#') {
            return document.getElementById(1, selector.length);
        }
        else if (selector[0] === '.') {
            return document.getElementsByClassName(1, selector.length);
        }
        else {
            return document.getElementsByTagName(selector);
        }
    }

    document.querySelector = function (selector) {
        if (selector[0] === '#') {
            return document.getElementById(1, selector.length)[0];
        }
        else if (selector[0] === '.') {
            return document.getElementsByClassName(1, selector.length)[0];
        }
        else {
            return document.getElementsByTagName(selector)[0];
        }
    }
}
