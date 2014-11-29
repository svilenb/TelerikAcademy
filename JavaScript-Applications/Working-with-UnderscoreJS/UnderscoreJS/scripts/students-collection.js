/// <reference path="../libs/underscore-min.js" />
(function () {
    'use strict';
    function Student(firstName, lastName, age, marks) {
        this.setFirstName(firstName);
        this.setLastName(lastName);
        this.setAge(age);
        this.setMarks(marks);
    }

    Student.prototype.setFirstName = function (value) {
        if ((typeof value).toLowerCase() !== 'string') {
            throw {
                message: "Invalid first name!"
            };
        }

        this._firstName = value;
    };

    Student.prototype.getFirstName = function () {
        return this._firstName;
    };

    Student.prototype.setLastName = function (value) {
        if ((typeof value).toLowerCase() !== 'string') {
            throw {
                message: "Invalid last name!"
            };
        }

        this._lastName = value;
    };

    Student.prototype.getLastName = function () {
        return this._lastName;
    };

    Student.prototype.getFullName = function () {
        return this._firstName + " " + this._lastName;
    };

    Student.prototype.setAge = function (value) {
        if ((typeof value).toLowerCase() !== 'number') {
            throw {
                message: "Invalid age!"
            };
        }

        this._age = value;
    };

    Student.prototype.getAge = function () {
        return this._age;
    };

    Student.prototype.setMarks = function (marks) {
        var i,
            len;
        this._marks = [];

        for (i = 0, len = marks.length; i < len; i += 1) {
            if ((typeof marks[i]).toLowerCase() !== 'number') {
                throw {
                    message: "Invalid marks!"
                };
            }

            this._marks.push(marks[i]);
        }
    };

    Student.prototype.getMarks = function () {
        return this._marks.slice();
    };

    var students = [
        new Student("Peter", "Ivanov", 16, [2, 3, 4, 5]),
        new Student("Ivan", "Todorov", 23, [4, 6, 3, 4]),
        new Student("Todor", "Ivanov", 20, [5, 6, 5, 6]),
        new Student("Georgi", "Petrov", 24, [3, 2, 4, 3]),
        new Student("Stamina", "Staminova", 30, [3, 4, 3, 5])
    ];

    _.chain(students)
        .filter(function (student) {
            return student.getFirstName().toLowerCase() < student.getLastName().toLowerCase();
        })
        .sortBy(function (student) {
            return student.getFullName().toLowerCase();
        })
        .each(function (student) {
            console.log(student.getFirstName() + " " + student.getLastName());
        });

    console.log('----------------------------------');

    _.chain(students)
        .filter(function (student) {
            return (18 <= student.getAge() && student.getAge() <= 24);
        })
        .map(function (student) {
            return {
                firstName: student.getFirstName(),
                lastName: student.getLastName()
            };
        })
        .each(function (student) {
            console.log(student.firstName + " " + student.lastName);
        });

    console.log('----------------------------------');

    var student = _.max(students, function (student) {
        var marks = student.getMarks(),
            averageMark = 0,
            i,
            len;

        for (i = 0, len = marks.length; i < len; i += 1) {
            averageMark += marks[i];
        }

        averageMark /= marks.length;
        return averageMark;
    });

    console.log(student);
}());
