function Solve(args) {
    function Pos(rowPos, colPos) {
        this.row = rowPos;
        this.col = colPos;
    }

    function handleStringInput(str) {
        var result = [];
        result = str.split(' ').map(Number);
        return result;
    }

    function parseJumps(jumpsAsStrArr) {
        var i = 0,
            values = [],
            result = [];

        for (i = 0; i < jumpsAsStrArr.length; i++) {
            values = handleStringInput(jumpsAsStrArr[i]);
            result.push(
                new Pos(
                    values[0],
                    values[1]
                )
            );
            //console.log(result[i].row, result[i].col);
        }

        return result;
    }

    function initField(n, m) {
        var result = [],
            row = 0,
            col = 0,
            colValues = [],
            count = 1;
        for (row = 0; row < n; row++) {
            for (col = 0; col < m; col++) {
                colValues.push(count);
                count += 1;
            }
            result.push(colValues);
            colValues = [];
        }

        return result;
    }

    function isOutsideTheField(rows, cols, position) {
        if (position.row < 0 || position.row >= rows) {
            return true;
        }
        if (position.col < 0 || position.col >= cols) {
            return true;
        }

        //console.log(rows, cols);
        return false;
    }

    function extractFieldValue(field, position) {
        var result = field[position.row][position.col];
        //console.log(position.row, position.col);
        field[position.row][position.col] = 0;
        //console.log('--' + result);
        return result;
    }

    var i,
        n = 0,
        m = 0,
        j = 0,
        nmj = handleStringInput(args[0]),
        startPos = handleStringInput(args[1]),
        currentPos = {},
        jumps = [],
        field = [],
        sumOfNumbers = 0;

    n = nmj[0];
    m = nmj[1];
    j = nmj[2];
    currentPos = new Pos(startPos[0], startPos[1]);

    field = initField(n, m); // Initialize field
    //console.log(field);

    sumOfNumbers = extractFieldValue(field, currentPos); // Initialize start sum  
    //console.log(sumOfNumbers);

    for (i = 2; i < 2 + j; i++) {
        jumps.push(args[i]);
    }

    //console.log(n, m, j, jumps);
    jumps = parseJumps(jumps);
    //console.log(jumps);

    for (i = 0; i < j; i++, i %= j) {
        //console.log('-- ' + jumps[i].row, jumps[i].col);
        currentPos.row += jumps[i].row;
        currentPos.col += jumps[i].col;
        //console.log(currentPos.row, currentPos.col);
        if (isOutsideTheField(n, m, currentPos)) {
            //console.log('escaped ' + sumOfNumbers);
            return 'escaped ' + sumOfNumbers;
        }
        if (field[currentPos.row][currentPos.col] === 0) {
            //console.log('caught ' + (i + 1));
            return 'caught ' + (i + 1);
        }
        sumOfNumbers += extractFieldValue(field, currentPos);
        //console.log("---" + sumOfNumbers);
    }

    console.log('Error');
}

var test1 = ['6 7 3', '0 0', '2 2', '-2 2', '3 -1'];
var test2 = ['5', '2', '-3', '4', '4', '0', '1'];

Solve(test1);