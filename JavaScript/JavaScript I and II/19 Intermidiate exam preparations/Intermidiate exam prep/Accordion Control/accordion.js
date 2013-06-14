var controls = (function () {
    function Accordion(selector) {
        var items = [];
        var accItem = document.querySelector(selector);
        var itemList = document.createElement("ul");

        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
        }

        this.render = function () {
            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            }

            var thisList = itemList.cloneNode(true);

            for (var i = 0; i < items.length; i++) {
                var domItem = items[i].render();
                thisList.appendChild(domItem);
            }
            accItem.appendChild(thisList);
        }
    }

    function Item(title) {
        this.render = function () {
            var itemNode = document.createElement("div");
            itemNode.innerHTML = title;
            return itemNode;
        }
    }

    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        }
    }

}());