function solve(args) {
    var s = parseInt(args[0], 10),
        count = 0,//i  j  k
        vehicles = [3, 4, 10],
        maxNumOfCars = s / vehicles[0] + 10,
        currentSum;


    for (var i = 0; i < maxNumOfCars; i++) {
        for (var j = 0; j < maxNumOfCars; j++) {
            for (var k = 0; k < maxNumOfCars; k++) {
                currentSum = i * vehicles[0] + j * vehicles[1] + k * vehicles[2];

                if (currentSum === s) {
                    count++;
                }
            }
        }
    }


    return count;
}
