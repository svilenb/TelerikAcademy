/// <reference path="../libs/underscore-min.js" />
(function () {
    'use strict';
    function Book(title, author) {
        this.setTitle(title);
        this.setAuthor(author);
    }

    Book.prototype.getTitle = function () {
        return this._title;
    };

    Book.prototype.setTitle = function (value) {
        if ((typeof value).toLowerCase() !== 'string') {
            throw {
                message: "Invalid title!"
            };
        }

        this._title = value;
    };

    Book.prototype.getAuthor = function () {
        return this._author;
    };

    Book.prototype.setAuthor = function (value) {
        if ((typeof value).toLowerCase() !== 'string') {
            throw {
                message: "Invalid author!"
            };
        }

        this._author = value;
    };

    var books = [
        new Book("Harry Potter and the Philosopher's Stone", "J. K. Rowling"),
        new Book("Harry Potter and the Chamber of Secrets", "J. K. Rowling"),
        new Book("Harry Potter and the Prisoner of Azkaban", "J. K. Rowling"),
        new Book("Harry Potter and the Order of the Phoenix", "J. K. Rowling"),
        new Book("Harry Potter and the Philosopher's Stone", "J. K. Rowling"),
        new Book("A Game of Thrones", "George R. R. Martin"),
        new Book("A Clash of Kings", "George R. R. Martin"),
        new Book("A Storm of Swords", "George R. R. Martin"),
        new Book("A Feast for Crows", "George R. R. Martin"),
        new Book("A Dance with Dragons", "George R. R. Martin"),
        new Book("The Winds of Winter", "George R. R. Martin"),
        new Book("Neizvestna", "Bai Stefan")
    ];

    var biggestGroup = _.chain(books)
        .groupBy(function (book) {
            return book.getAuthor();
        })
        .sortBy(function (group) {
            return group.length;
        })
        .last();

    console.log("Most popular author: " + biggestGroup.value()[0].getAuthor());
}());