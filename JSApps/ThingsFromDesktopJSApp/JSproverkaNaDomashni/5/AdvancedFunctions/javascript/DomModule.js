var domModule = (function () {

    function getElement(selector) {
        return document.querySelector(selector);
    }

    function getElements(selector) {
        return document.querySelectorAll(selector);
    }

    function appendChildElement(element, selector) {
        getElement(selector).appendChild(element);
    }

    function removeChildElement(element, selector) {
        var elementsToRemove = getElements(element + ' ' + selector);
        var elementsCount = elementsToRemove.length;

        for (var element = 0; element < elementsCount; element += 1) {
            currentElement = elementsToRemove[element].parentNode;
            currentElement.removeChild(elementsToRemove[element]);
        }
    }

    function addEventHandler(selector, event, eventHandler) {
        var elements = getElements(selector);
        var elementsCount = elements.length;

        for (var i = 0 ; i < elementsCount; i += 1) {
            if (elements[i].addEventListener) {
                elements[i].addEventListener(event, eventHandler, false);
            }
            else {
                elements[i].attachEvent("on" + event, eventHandler);
            }
        }
    }

    var buffer = [];
    var BUFFER_SIZE = 100;

    function appendToBuffer(selector, element) {
        if (!buffer[selector]) {
            buffer[selector] = document.createDocumentFragment();
        }
        buffer[selector].appendChild(element);

        if (buffer[selector].childNodes.length === BUFFER_SIZE) {
            var parent = getElement(selector);
            parent.appendChild(buffer[selector]);
            buffer[selector] = null;
        }
    }

    return {
        appendChild: appendChildElement,
        removeChild: removeChildElement,
        addHandler: addEventHandler,
        appendToBuffer: appendToBuffer
    };
})();
