/*jslint browser: true*/
jQuery(document).ready(function() {
    'use strict';
    var testArray = null,
        $this = $(this);

    function Student(initFname, initLname, initGrade) {
        this.firstName = initFname;
        this.lastName = initLname;
        this.grade = initGrade;
    }

    function fillTable(testArray) {
        var i = 0,
            prop = null,
            $wrapper = $this.find('#wrapper'),
            $table = $('<table>'),
            $tableHead = $('<thead>'),
            $tableBody = $('<tbody>'),
            $tableRow = null,
            $tableData = null;

        $tableHead.html('<th>First name</th><th>Last name</th><th>Grade</th>');
        $tableHead.children().css('border', '1px solid black');
        $table.append($tableHead);

        for (i = testArray.length - 1; i >= 0; i--) {
            $tableRow = $('<tr>');
            for (prop in testArray[i]) {
                if (testArray[i].hasOwnProperty(prop)) {
                    $tableData = $('<td>');
                    $tableData.text(testArray[i][prop]).css('border', '1px solid black');
                    $tableRow.append($tableData);
                }
            }
            $tableBody.append($tableRow);
            $tableRow = null;
        }

        $tableBody.appendTo($table);
        $table.appendTo($wrapper);
    }

    testArray = [
        new Student('Peter', 'Ivanov', 3),
        new Student('Milena', 'Grigorova', 6),
        new Student('Gergana', 'Borisova', 12),
        new Student('Boyko', 'Petrov', 7)
    ];

    $('button').click(function(event) {
        event.preventDefault();
        fillTable(testArray);
    });
});