/// <reference path="../libs/underscore-min.js" />
(function () {
    'use strict';
    function Animal(name, species, numberOfLegs) {
        this.setName(name);
        this.setSpecies(species);
        this.setNumberOfLegs(numberOfLegs);
    }

    Animal.prototype.getName = function () {
        return this._name;
    };

    Animal.prototype.setName = function (value) {
        if ((typeof value).toLowerCase() !== 'string') {
            throw {
                message: "Invalid name!"
            };
        }

        this._name = value;
    };

    Animal.prototype.getSpecies = function () {
        return this._species;
    };

    Animal.prototype.setSpecies = function (value) {
        if ((typeof value).toLowerCase() !== 'string') {
            throw {
                message: "Invalid species!"
            };
        }

        this._species = value;
    };

    Animal.prototype.getNumberOfLegs = function () {
        return this._numberOfLegs;
    };

    Animal.prototype.setNumberOfLegs = function (value) {
        if ((typeof value).toLowerCase() !== 'number') {
            throw {
                message: "Invalid number of legs!"
            };
        }

        this._numberOfLegs = value;
    };

    var animals = [
        new Animal("kozi4ka", "goat", 4),
        new Animal("bugs", "bunny", 4),
        new Animal("Tom", "cat", 4),
        new Animal("Butch", "cat", 4),
        new Animal("Maimuna", "monkey", 2),
        new Animal("stonojka", "centipede", 100)
    ];

    _.chain(animals)
        .groupBy(function (animal) {
            return animal.getSpecies();
        })
        .sortBy(function (group) {
            return group[0].getNumberOfLegs();
        })
        .each(function (group) {
            var i,
                len,
                animal;

            console.log(group[0].getSpecies() + ":");            
            for (i = 0, len = group.length; i < len; i += 1) {
                animal = group[i];
                console.log(animal.getName() + " " + animal.getSpecies() + " " + animal.getNumberOfLegs());
            }

            console.log("---------------");
        });

    var totalNumberOfLegs = _.chain(animals)
        .reduce(function (memo, animal) {
            return memo + animal.getNumberOfLegs();
        }, 0);

    console.log("Total number of legs: " + totalNumberOfLegs.value());
}());