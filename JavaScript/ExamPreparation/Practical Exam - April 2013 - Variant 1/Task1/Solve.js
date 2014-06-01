function Solve(params) {
    var i,
        inputArray = params.map(Number),
        answer = 1;
    //console.log(inputArray);
    for (i = 2; i < inputArray.length; i++) {
        if (inputArray[i] < inputArray[i - 1]) {
            answer += 1;
        }
    }
    console.log(answer);
    return answer;
}

var test1 = ['2', '3', '5', '2', '-1', '0', '3'];
var test2 = ['5', '2', '-3', '4', '4', '0', '1'];

Solve(test2);