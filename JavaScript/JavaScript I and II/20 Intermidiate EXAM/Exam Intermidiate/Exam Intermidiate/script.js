window.addEventListener("load", function () {
    var schoolsGrid = controls.getGridView("#grid-view-holder");
    schoolsGrid.addHeader("Name", "Location", "Total Students", "Specialty");
    schoolsGrid.addRow("PMG", "Burgas", 400, "Math");
    schoolsGrid.addRow("TUES", "Sofia", 500, "IT");
    var academyRow = schoolsGrid.addRow("Telerik Academy", "Sofia", 5000, "IT");

    var academyGrid = academyRow.getNestedGridView();
    academyGrid.addHeader("Title", "Start Date", "Total Students");
    academyGrid.addRow("JS 2", "11-april-2013", 400);
    var seoRow = academyGrid.addRow("SEO", "15-may-2013", 1300);
    academyGrid.addRow("Slice and Dice", "05-april-2013", 500);

    var testGrid = seoRow.getNestedGridView();
    testGrid.addHeader("Basi", "kefa");
    testGrid.addRow("az sum", "pich");
    testGrid.addRow("ama ne mi stigna", "vremeto za podgotovka");


    var containerEl = document.querySelector("#grid-view-holder");
    containerEl.appendChild(schoolsGrid.render());


    handleClick = function (event) {
        event.stopPropagation();
        event.preventDefault();
        var tr = event.currentTarget;
        tr.nextElementSibling.classList.toggle("hide");
    };

    // attach click events for main grid view
    attachExpandGridEvents(containerEl);

    function attachExpandGridEvents(element) {
        // attach click events to all rows next to wich is row with table inside
        var rows = element.getElementsByTagName("tr");
        for (var i = 0; i < rows.length; i++) {
            var curRow = rows[i];
            var nextRow = curRow.nextElementSibling;
            if (nextRow instanceof HTMLTableRowElement) {
                var firstTd = nextRow.firstElementChild;
                if (firstTd.firstElementChild instanceof HTMLTableElement) {
                    curRow.classList.toggle("handPointer");
                    // attach event to curRow to display nextRow
                    nextRow.classList.toggle("hide");
                    //nextRow.style.display = "none";
                    curRow.addEventListener("click", handleClick, false);
                }
            }
        }
    }

    // Save GridView
    var saveWholeGrid = schoolsGrid.serialize();
    // Put the object into storage
    localStorage.setItem('schoolGrid', JSON.stringify(saveWholeGrid));

    // Retrieve the object from storage
    var retrievedObject = localStorage.getItem('schoolGrid');
    var data = JSON.parse(retrievedObject);
    rebuildGridView = controls.buildGridView("#grid-view-holder-storage", data);
    var rebuildGridViewContainer = document.querySelector("#grid-view-holder-storage");
    rebuildGridViewContainer.appendChild(rebuildGridView.render());

    // attach click events for main grid view
    attachExpandGridEvents(rebuildGridViewContainer);


    // Sort the rows in first <tbody> of the specified table according to
    // the value of nth cell within each row. Use the comparator function
    // if one is specified. Otherwise, compare the values alphabetically.
    function sortrows(table, n, comparator) {
        var tbody = table.tBodies[0];
        var rows = tbody.getElementsByTagName("tr");
        rows = Array.prototype.slice.call(rows, 0); // Snapshot in a true array
        // Now sort the rows based on the text in the nth <td> element
        rows.sort(function (row1, row2) {
            var cell1 = row1.getElementsByTagName("td")[n]; // Get nth cell
            var cell2 = row2.getElementsByTagName("td")[n]; // of both rows
            var val1 = cell1.textContent || cell1.innerText; // Get text content
            var val2 = cell2.textContent || cell2.innerText; // of the two cells
            if (comparator) return comparator(val1, val2); // Compare them!
            if (val1 < val2) return -1;
            else if (val1 > val2) return 1;
            else return 0;
        });

        // Now append the rows into the tbody in their sorted order.
        // This automatically moves them from their current location, so there
        // is no need to remove them first. If the <tbody> contains any
        // nodes other than <tr> elements, those nodes will float to the top.
        for (var i = 0; i < rows.length; i++) tbody.appendChild(rows[i]);
    }
    // Find the <th> elements of the table (assuming there is only one row of them)
    // and make them clickable so that clicking on a column header sorts
    // by that column.
    function makeSortable(table) {
        var headers = table.getElementsByTagName("th");
        for (var i = 0; i < headers.length; i++) {
            (function (n) { // Nested funtion to create a local scope
                headers[i].onclick = function () { sortrows(table, n); };
            }(i)); // Assign value of i to the local variable n
        }
    }

    // TODO: sort adjacment tables with rows!!!
    /*
    var tables = containerEl.getElementsByTagName("table");
    for (var i = 0; i < tables.length; i++) {
        makeSortable(tables[i]);
    }
    */
   
}, false);


(function () {
    if (!Storage.prototype.setObject) {
        Storage.prototype.setObject = function (key, obj) {
            this.setItem(key, JSON.stringify(obj));
        }
    }

    if (!Storage.prototype.getObject) {
        Storage.prototype.getObject = function (key) {
            return JSON.parse(this.getItem(key));
        }
    }
}());