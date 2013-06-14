function Solve(args) {
    //var strResult = "1\n2 3\n6 11 20";


    var firstNum = parseInt(args[0]);
    var secondNum = parseInt(args[1]);
    var thirdNum = parseInt(args[2]);
    var rows = parseInt(args[3]);
    var finalSum = 0;
    var strResult = firstNum + "\r\n" + secondNum + " " + thirdNum;
    for (var i = 2; i < rows; i++) {
        strResult += "\r\n";
        for (var j = 0; j < i + 1 ; j++) {
            var temp1 = firstNum;
            var temp2 = secondNum;
            var temp3 = thirdNum;
            var temp4 = finalSum;

            if (j === 0 && i === 2) {
                temp4 = thirdNum;
                temp3 = secondNum;
            }

            finalSum += firstNum + secondNum + thirdNum;

            firstNum = 0;
            secondNum = temp3;
            thirdNum = temp4;

            strResult += "" + finalSum + " ";
        }
    }

    return strResult;
}

console.log(Solve(1,2,3,3));