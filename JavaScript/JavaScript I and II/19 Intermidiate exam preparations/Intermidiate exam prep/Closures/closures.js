window.addEventListener("load", function () {
    closure.init()
}, false);

var closure = {
    init: function () {
        console.log("initialization");
        this.createDivs();
        this.addHandlers(document.getElementsByTagName("div"));
        this.btnAddHandler();
    },

    createDivs: function (count) {
        var frag = document.createDocumentFragment();
        var i;
        var element;
        for (i = 0; i < 10; i++) {
            element = document.createElement("div");
            element.style.width = "50px";
            element.style.height = "50px";
            element.style.border = "1px solid red";
            element.style.display = "inline-block";
            frag.appendChild(element);
        }

        document.body.appendChild(frag);
    },

    addHandlers: function (nodes) {
        var i;
        for (i = 0; i < nodes.length; i++) {
            nodes[i].addEventListener("click", (function (e) {
                return function () {
                    alert(e);
                }
            }(i)));
        }
    },
    btnAddHandler: function () {
        var btn = document.getElementById("btn");
        btn.addEventListener("click", function (event) {
            alert(event.target === this);
            event.stopImmediatePropagation();
        }, false);
        document.body.addEventListener("click", function () {
            alert("i'm in body bitch");
        }, false);
    }
}



Function.prototype.method = function (name, func) {
    this.prototype[name] = func;
    return this;
};

Function.method('inherits', function (Parent) {
    this.prototype = new Parent();
    return this;
});

var isNumber = function isNumber(value) {
    return typeof value === 'number' &&
    isFinite(value);
}

var Constants = {
    INVALID_VALUE_MSG: "Invalid value!",
    INVALID_VALUE_URL: "/errors/invalid.php"
};

var app = {
    constants: {
        test: "test1"
    }
};

app.constants.teest = "test";


console.log(app.constants.teest);
console.log(app.constants.test);








