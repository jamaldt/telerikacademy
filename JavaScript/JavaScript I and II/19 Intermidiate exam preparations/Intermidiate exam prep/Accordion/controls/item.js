function Item(name) {
    this.name = name;
    this.items = [];
};

Item.prototype = {
    constructor: Item,
    add: function (name) {
        var newItem = new Item(name);
        this.items.push(newItem);
    }
};