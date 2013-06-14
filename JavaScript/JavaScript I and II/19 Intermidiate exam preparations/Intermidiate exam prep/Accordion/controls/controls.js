var controls = {
    getAccordion: function (elementId) {
        var accordionContainerElement = document.querySelector(elementId);
    }
}

function inheritPrototype(subType, superType) {
    var prototype = object(superType.prototype); //create object
    prototype.constructor = subType; //augment object
    subType.prototype = prototype; //assign object
}