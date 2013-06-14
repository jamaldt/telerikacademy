function allocateIntArray(len) {
    var arr = new Array(len);
    for (var i = 0; i < arr.length; i++) {
        arr[i] = i * 5;
    }
    for (var i = 0; i < arr.length; i++) {
        jsConsole.writeLine(arr[i]);
    }
}

function compareCharArraysLexicographically(arr1, arr2) {
    var length = arr1.length < arr2.length ? arr1.length : arr2.length;
    for (var i = 0; i < length; i++) {
        if (arr1[i] < arr2[i])
            return -1;
        else if (arr1[i] > arr2[i])
            return 1;
    }
    return 0;
}