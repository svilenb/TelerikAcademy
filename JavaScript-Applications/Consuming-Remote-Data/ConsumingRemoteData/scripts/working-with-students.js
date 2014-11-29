/// <reference path="E:\Academy-Telerik\Web-Design-And-UI\JavaScript-Applications\ConsumingRemoteData\ConsumingRemoteData\libs/jquery-2.1.1.min.js" />
(function () {
    var $errorMessage, $successMessage, addStudent, reloadStudents, resourceUrl;

    resourceUrl = 'http://localhost:3000/students';

    $successMessage = $('.messages .success');

    $errorMessage = $('.messages .error');

    addStudent = function (data) {
        return $.ajax({
            url: resourceUrl,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                $successMessage
                  .html('' + data.name + ' successfully added')
                  .show()
                  .fadeOut(2000);                
            },
            error: function (err) {
                $errorMessage
                  .html('Error happened: ' + err)
                  .show()
                  .fadeOut(2000);
            }
        });
    };

    reloadStudents = function () {
        $.ajax({
            url: resourceUrl,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                var student, $studentsList, i, len;
                $studentsList = $('<ul/>').addClass('students-list');
                for (i = 0, len = data.students.length; i < len; i++) {
                    console.log(student);
                    student = data.students[i];
                    $('<li />')
                      .addClass('student-item')
                      .append($('<strong /> ')
                        .html(student.name))
                      .append($('<span />')
                        .html(student.grade))
                      .appendTo($studentsList);
                }
                $('#students-container').html($studentsList);
            },
            error: function () {
                $errorMessage
                  .html("Error happened: " + err)
                  .show()
                  .fadeOut(2000);
            }
        });
    };

    deleteStudent = function (id) {
        return $.ajax({
            url: resourceUrl + '/' + id + '/',
            type: 'POST',
            success: function () {
                $successMessage
                 .html('studnet with id:' + id + 'successfully added')
                 .show()
                 .fadeOut(2000);
                reloadStudents();
            },
            error: function (err) {
                $errorMessage
                  .html('Error happened: ' + err)
                  .show()
                  .fadeOut(2000);
            },
            timeout: 5000,
            data: {
                _method: 'delete'
            }
        });
    };

    $(function () {
        reloadStudents();
        $('#btn-add-student').on('click', function () {
            var student;
            student = {
                name: $('#tb-name').val(),
                grade: $('#tb-grade').val()
            };
            addStudent(student);
            reloadStudents();
        });

        $('#btn-delete-student').on('click', function () {
            var id = $('#tb-id').val(),
                studentsLength = $('#students-container .students-list li').length;

            if (id > 0) {
                deleteStudent(id);
                reloadStudents();
            }
        });
    });
}());
