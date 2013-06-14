window.addEventListener("load", function () {



    function Item(name) {
        this.name = name || "";
        this.items = [];
        this.collapsed = true;
    };

    Item.prototype = {
        constructor: Item,
        add: function (name) {
            var newItem = new Item(name);
            this.items.push(newItem);
            return newItem;
        },
        render: function () {
            var output = this.name;
            if (this.items.length > 0) {
                output += "<ul>";
                for (var i = 0; i < this.items.length; i++) {
                    output += "<li>";
                    output += this.items[i].render();
                    output += "</li>";
                }

                output += "</ul>";
            }

            return output;
        },

    };

    function Accordion(containerElement) {
        this.containerElement = containerElement;
    };

    Accordion.prototype = new Item();

    //var accordion = controls.getAccordion("#accordion-holder");
    var accordion = new Accordion("#accordion-holder");
    var webItem = accordion.add("Web");
    webItem.add("HTML");
    webItem.add("CSS");
    webItem.add("JavaScript");
    var query = webItem.add("jQuery");
    query.add("1");
    query.add("2");
    query.add("3");
    query.add("4");
    webItem.add("ASP.NET MVC");
    accordion.add("Desktop");
    accordion.add("Mobile");
    var embeded = accordion.add("Embedded");
    embeded.add("1");
    embeded.add("2");
    embeded.add("3");
    var string = accordion.render();
    var containerEl = document.querySelector("#accordion-holder");
    containerEl.innerHTML = string;

    // first we have to collapse all menus
    var ulElements = containerEl.firstElementChild.getElementsByTagName("ul");

    for (var i = 0; i < ulElements.length; i++) {
        ulElements[i].classList.toggle("hide");
    };

    handleClick = function (event) {
        event.stopPropagation();
        console.log(event.target);
        var childEl = event.target.firstElementChild;
        console.log(childEl);
        if (childEl instanceof HTMLUListElement) {
            childEl.classList.toggle("hide");
        }
    };

    containerEl.addEventListener("click", handleClick, false);

    /*
 
    */

}, false);