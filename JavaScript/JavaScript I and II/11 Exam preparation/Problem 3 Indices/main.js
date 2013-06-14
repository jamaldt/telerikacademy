function Solve(args) {

    args[1] = "1 2 3 5 7 8";

    var indices = args[1].split(' ');

    var resultNumbers = [];
    var visited = {};

    var currentIndex = 0;
    while (currentIndex >= 0 && currentIndex < indices.legth) {
        resultNumbers.push(indices[currentIndex]);
        

        currentIndex = indices[currentIndex];

    }

    console.log(resultNumbers.join(" "));

    return indices[3];

}