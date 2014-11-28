var domModule = (function () {
    var self,
        buffer = [];

    function appendElement(element, selector) {
        document.querySelector(selector).appendChild(element);
        return self;
    }

    function removeElement(selector) {
        var element = document.querySelector(selector);
        element.parentNode.removeChild(element);
        return self;
    }

    function attachEvent(selector, eventType, eventHandler) {
        var elements = document.querySelectorAll(selector),
            i;

        for (i = 0; i < elements.length; i += 1) {
            elements[i].addEventListener(eventType, eventHandler);
        }
    }

    function appendToBuffer(selector, element) {
        if (!buffer[selector]) {
            buffer[selector] = document.createDocumentFragment();
        }

        buffer[selector].appendChild(element);

        if (buffer[selector].childNodes.length === 100) {
            document.querySelector(selector).appendChild(buffer[selector]);

            buffer[selector] = null;
        }
    }

    self = {
        append: appendElement,
        remove: removeElement,
        attach: attachEvent,
        appendToBuffer: appendToBuffer
    };

    return self;
}());
