/**
* Return the nth ancestor of e, or null if there is no such ancestor
* or if that ancestor is not an Element (a Document or DocumentFragment e.g.).
* If n is 0 return e itself. If n is 1 (or
* omitted) return the parent. If n is 2, return the grandparent, etc.
*/
function parent(e, n) {
    if (n === undefined) {
        n = 1;
    }

    while (n-- && e) {
        e = e.parentNode;
    }

    if (!e || e.nodeType !== 1) {
        return null;
    }

    return e;
}

/**
* Return the nth sibling element of Element e.
* If n is postive return the nth next sibling element.
* If n is negative, return the -nth previous sibling element.
* If n is zero, return e itself.
*/
function sibling(e, n) {
    // If e is not defined we just return it
    while (e && n !== 0) {
        if (n > 0) {
            // Find next element sibling
            if (e.nextElementSibling) e = e.nextElementSibling;
            else {
                do {
                    e = e.nextSibling;
                } while (e && e.nodeType !== 1);
            }
            n--;
        }
        else {
            // Find the previous element sibling
            if (e.previousElementSibing) {
                e = e.previousElementSibling;
            } else {
                do {
                    e = e.previousSibling
                } while (e && e.nodeType !== 1);
            }
            n++;
        }
    }

    return e;
}

/**
* Return the nth element child of e, or null if it doesn't have one.
* Negative values of n count from the end. 0 means the first child, but
* -1 means the last child, -2 means the second to last, and so on.
*/
function child(e, n) {
    if (e.children) { // If children array exists
        if (n < 0) n += e.children.length; // Convert negative n to array index
        if (n < 0) return null; // If still negative, no child
        return e.children[n]; // Return specified child
    }
    // If e does not have a children array, find the first child and count
    // forward or find the last child and count backwards from there.
    if (n >= 0) { // n is non-negative: count forward from the first child
        // Find the first child element of e
        if (e.firstElementChild) e = e.firstElementChild;
        else {
            for (e = e.firstChild; e && e.nodeType !== 1; e = e.nextSibling)
                /* empty */;
        }
        return sibling(e, n); // Return the nth sibling of the first child
    }
    else { // n is negative, so count backwards from the end
        if (e.lastElementChild) e = e.lastElementChild;
        else {
            for (e = e.lastChild; e && e.nodeType !== 1; e = e.previousSibling)
                /* empty */;
        }
        return sibling(e, n + 1); // +1 to convert child -1 to sib 0 of last
    }
}

// Insert the child node into parent so that it becomes child node n
function insertAt(parent, child, n) {
    if (n < 0 || n > parent.childNodes.length) throw new Error("invalid index");
    else if (n == parent.childNodes.length) parent.appendChild(child);
    else parent.insertBefore(child, parent.childNodes[n]);
}

// Sort the rows in first <tbody> of the specified table according to
// the value of nth cell within each row. Use the comparator function
// if one is specified. Otherwise, compare the values alphabetically.
function sortrows(table, n, comparator) {
    var tbody = table.tBodies[0]; // First <tbody>; may be implicitly created
    var rows = tbody.getElementsByTagName("tr"); // All rows in the tbody
    rows = Array.prototype.slice.call(rows,0); // Snapshot in a true array
    // Now sort the rows based on the text in the nth <td> element
    rows.sort(function(row1,row2) {
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













