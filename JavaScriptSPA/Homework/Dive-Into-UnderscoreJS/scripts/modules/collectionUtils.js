/*jslint browser: true*/
define(['underscore'], function (_) {
    'use strict';

    var collectionUtils = (function () {
        var selectFNameBeforeLastSortDescendingByName = function (studentsCollection) {
            /*Write a method that from a given array of students
             finds all students whose first name is before its last
             name alphabetically . Print the students in
             descending order by full name. Use Underscore.js*/
            var filtered;

            filtered = _.chain(studentsCollection)
                .filter(function (student) {
                    return student.fName.toUpperCase() < student.lName.toUpperCase();
                })
                .sortBy('lName')
                .sortBy('fName')
                .reverse()
                .value();

            return filtered;
        };

        var filterByAgeExtractName = function (studentsCollection, minAge, maxAge) {
            /*Write function that finds the first name and last
             name of all students with age between 18 and 24.
             Use Underscore.js*/
            var filtered;

            minAge = minAge || 18;
            maxAge = maxAge || 24;

            filtered = _.chain(studentsCollection)
                .filter(function (student) {
                    return minAge <= student.age && student.age <= maxAge;
                })
                .map(function (student) {
                    return student.fName + ' ' + student.lName;
                })
                .value();

            return filtered;
        };

        var findHighestMarks = function (studentsCollection) {
            /*Write a function that by a given array of students
             finds the student with highest marks*/
            var wanted;

            wanted = _.max(studentsCollection, function (student) {
                var currentMark;

                currentMark = _.reduce(student.marks, function (memo, mark) {
                    return memo + mark;
                });

                return currentMark;
            });

            return wanted;
        };

        var groupBySpeciesSortByLegs = function (animalsCollection) {
            /*Write a function that by a given array of animals,
             groups them by species and sorts them by number of
             legs*/
            var result;

            result = _.chain(animalsCollection)
                .each(function (animal, key) {
                    animal['type'] = key;
                })
                .groupBy(function (animal) {
                    return animal.class;
                })
                .sortBy(function (animal) {
                    return animal.numberOfLegs;
                })
                .value();

            return result;
        };

        var calculateNumberOfLegs = function (animalsCollection) {
            /*By a given array of animals, find the total number of
             legs
              Each animal can have 2, 4, 6, 8 or 100 legs*/
            var countedLegs;

            countedLegs = _.chain(animalsCollection)
                .pluck('numberOfLegs')
                .reduce(function (memo, num) {
                    num = _.indexOf([2, 4, 6, 8, 100], num) > -1 ? num : 0;
                    return memo + num;
                })
                .value();

            return countedLegs;
        };

        var findMostPopularAuthor = function (booksCollection) {
            /*By a given collection of books, find the most popular
             author (the author with the highest number of
             books)*/
            var mostPopular;

            mostPopular = _.chain(booksCollection)
                .countBy('author')
                .pairs()
                .max(function (pair) {
                    return _.last(pair);
                })
                .value();

            return mostPopular;
        };

        var findMostCommonFirstAndLastName = function (peopleCollection) {
            /*By an array of people find the most common first and
             last name. Use underscore.*/
            var topFirstName,
                topLastName;

            var countByProperty = function (collection, property) {
                var result;

                result = _.chain(collection)
                    .countBy(property)
                    .pairs()
                    .max(function (pair) {
                        return _.last(pair);
                    })
                    .first()
                    .value();

                return result;
            };

            topFirstName = countByProperty(peopleCollection, 'fName');
            topLastName = countByProperty(peopleCollection, 'lName');

            return {
                topFirstName: topFirstName,
                topLastName: topLastName
            }
        };

        return {
            selectFNameBeforeLastSortDescendingByName: selectFNameBeforeLastSortDescendingByName,
            filterByAgeExtractName: filterByAgeExtractName,
            findHighestMarks: findHighestMarks,
            groupBySpeciesSortByLegs: groupBySpeciesSortByLegs,
            calculateNumberOfLegs: calculateNumberOfLegs,
            findMostPopularAuthor: findMostPopularAuthor,
            findMostCommonFirstAndLastName: findMostCommonFirstAndLastName
        }
    }());

    return collectionUtils;
});