var controls = (function () {
    function object(o) {
        function F() { }
        F.prototype = o;
        return new F();
    }

    function inheritPrototype(subType, superType) {
        var prototype = object(superType.prototype); //create object
        prototype.constructor = subType; //augment object
        subType.prototype = prototype; //assign object
    }

    function isNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    function GridViewControler(selector) {
        var container = document.querySelector(selector);
        var gridView = new GridView();

        return {
            addHeader: function () {
                gridView.addHeader(arguments);
            },
            addRow: function () {
                return gridView.addRow(arguments);
            },
            render: function () {
                gridView.render();
            }
        }
    }

    function GridView() {
        this.header = null;
        this.rows = [];
        this.display = false;
    }

    GridView.prototype = {
        constructor: GridView,
        addHeader: function () {
            this.header = new TableHeader();
            for (var i = 0; i < arguments.length; i++) {
                this.header.addColumnValues(arguments[i]);
            }
        },
        addHeaderFromStorage: function(arr) {
            this.header = new TableHeader();
            for (var i = 0; i < arr.length; i++) {
                this.header.addColumnValues(arr[i]);
            }
        },
        addRow: function () {
            var row = new TableRow();
            for (var i = 0; i < arguments.length; i++) {
                row.addColumnValues(arguments[i]);
            }

            this.rows.push(row);
            return row;
        },
        addRowFromStorage: function (arr) {
            var row = new TableRow();
            for (var i = 0; i < arr.length; i++) {
                row.addColumnValues(arr[i]);
            }

            this.rows.push(row);
            return row;
        },
        render: function () {
            var table = document.createElement("table");
            //table.style.border = "1px solid red";
            /*
            if (this.display) {
                table.style.display = "";
            } else {
                table.style.display = "none";
            }
            */
            var tbody = document.createElement("tbody");
            var tr;

            if (this.header !== null) {                var thead = document.createElement("thead");
                tr = document.createElement("tr");
                tr.innerHTML = this.header.render();
                thead.appendChild(tr);
                table.appendChild(thead);
            }

            for (var i = 0; i < this.rows.length; i++) {
                tr = document.createElement("tr");
                tr.innerHTML = this.rows[i].render();
                tbody.appendChild(tr);

                // if current row has GridView draw it.
                if (this.rows[i].gridView !== null) {
                    tr = document.createElement("tr");
                    var td = document.createElement("td");
                    td.colSpan = this.rows[i].columnValue.length;
                    td.appendChild(this.rows[i].gridView.render());
                    tr.appendChild(td);
                    tbody.appendChild(tr);
                }
            }

            table.appendChild(tbody);
            return table;
        },
        serialize: function () {
            var serializedItems = [];


            if (this.header !== null) {
                serializedItems.push(this.header.serialize());
            } else {
                serializedItems.push(null);
            }
            
            var serializedRows = [];
            for (var i = 0; i < this.rows.length; i++) {
                serializedRows.push(this.rows[i].serialize());
            }
            serializedItems.push(serializedRows);
            return serializedItems;
        }

    };


    function Row(openTag, closeTag) {
        this.columnValue = [];
        this.openTag = openTag;
        this.closeTag = closeTag;
    }

    Row.prototype = {
        constructor: Row,
        addColumnValues: function (value) {
            var input = "" + value;
            input = input.replace(/</g, "&lt;").replace(/>/g, "&gt;");
            this.columnValue.push(input);
        },
        render: function () {
            var output = "";
            for (var i = 0; i < this.columnValue.length; i++) {
                output += this.openTag;
                output += this.columnValue[i];
                output += this.closeTag;
            }

            return output;
        },
        serialize: function () {
            //var serializedItems = [];
            //serializedItems.push(this.columnValue);

            //return serializedItems;
            return this.columnValue;
        }
    };

    function TableHeader() {
        Row.call(this, "<th>", "</th>");
    }

    inheritPrototype(TableHeader, Row);

    function TableRow() {
        Row.call(this, "<td>", "</td>");

        this.gridView = null;
    }

    inheritPrototype(TableRow, Row);

    TableRow.prototype.getNestedGridView = function () {
        this.gridView = new GridView();
        return this.gridView;
    };

    TableRow.prototype.serialize = function () {
        var serializedItems = [];
        serializedItems.push(this.columnValue);
        if (this.gridView !== null) {
            serializedItems.push(this.gridView.serialize());
        } else {
            serializedItems.push(null);
        }

        return serializedItems;
    };

    function addRow(grid, row) {

    }

    function addItems(grid, data) {
        if (data[0] !== null) {
            grid.addHeaderFromStorage(data[0]);
        }

        if (data[1] !== null) {
            var rows = data[1];
            for (var i = 0; i < rows.length; i++) {
                var row = rows[i][0];
                var newRow = grid.addRowFromStorage(row);

                var newGridData = rows[i][1];
                if (newGridData !== null) {
                    var newGrid = newRow.getNestedGridView();
                    addItems(newGrid, newGridData);
                }

            }
        }
    }

    return {
        getGridView: function (selector) {
            //return new GridViewControler(selector);
            var grid = new GridView(selector);
            grid.display = true;
            return grid;
        },
        buildGridView: function (selector, data) {
            var gridView = this.getGridView(selector);

            if (data) {
                addItems(gridView, data);
            }

            return gridView;
        }
    }
}());





