/// <reference path="../libs/underscore-min.js" />
(function () {
    'use strict';
    function Person(firstName, lastName) {
        this.setFirstName(firstName);
        this.setLastName(lastName);
    }

    Person.prototype.setFirstName = function (value) {
        if ((typeof value).toLowerCase() !== 'string') {
            throw {
                message: "Invalid first name!"
            };
        }

        this._firstName = value;
    };

    Person.prototype.getFirstName = function () {
        return this._firstName;
    };

    Person.prototype.setLastName = function (value) {
        if ((typeof value).toLowerCase() !== 'string') {
            throw {
                message: "Invalid last name!"
            };
        }

        this._lastName = value;
    };

    Person.prototype.getLastName = function () {
        return this._lastName;
    };

    Person.prototype.getFullName = function () {
        return this._firstName + " " + this._lastName;
    };

    var people = [
        new Person("Peter", "Ivanov"),
        new Person("Ivan", "Todorov"),
        new Person("Todor", "Ivanov"),
        new Person("Georgi", "Petrov"),
        new Person("Stamina", "Staminova"),
        new Person("Peter", "Cekov")
    ];

    var mostCommonFirstName = _.chain(people)
        .countBy(function (person) {
            return person.getFirstName();
        })
        .pairs()
        .sortBy(function (pair) {
            return pair[1];
        })
        .last()
        .value()[0];

    console.log("Most common first name: " + mostCommonFirstName);

    var mostCommonLastName = _.chain(people)
        .countBy(function (person) {
            return person.getLastName();
        })
        .pairs()
        .sortBy(function (pair) {
            return pair[1];
        })
        .last()
        .value()[0];

    console.log("Most common last name: " + mostCommonLastName);
}());