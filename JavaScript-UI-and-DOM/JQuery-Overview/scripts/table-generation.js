(function () {
    var students = [{
        firstName: "Peter",
        lastName: "Ivanov",
        grade: 3
    }, {
        firstName: "Milena",
        lastName: "Grigorova",
        grade: 6
    }, {
        firstName: "Gergana",
        lastName: "Borisova",
        grade: 12
    }, {
        firstName: "Boyko",
        lastName: "Petrov",
        grade: 7
    }
    ];

    function generateTable(students) {
        var $table = $('<table />'),
            $thead = $('<thead />'),
            $tr = $('<tr />');

        $tr.append($('<th />').html('First name'));
        $tr.append($('<th />').html('Last name'));
        $tr.append($('<th />').html('Grade'));
        $thead.append($tr);
        $table.append($thead);

        var i;
        for (i = 0; i < students.length; i += 1) {
            var $studentRow = $('<tr />'),
                $firstName = $('<td />').html(students[i].firstName),
                $lastName = $('<td />').html(students[i].lastName),
                $grade = $('<td />').html(students[i].grade);

            $studentRow.append($firstName);
            $studentRow.append($lastName);
            $studentRow.append($grade);
            $table.append($studentRow);
        }

        return $table;
    }

    $('#wrapper').append(generateTable(students));
}());