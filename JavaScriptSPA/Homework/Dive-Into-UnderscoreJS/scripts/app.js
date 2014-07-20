/*jslint browser: true*/
(function () {
    'use strict';

    require.config({
        paths: {
            underscore: 'libs/underscore',
            collectionUtils: 'modules/collectionUtils'
        }
    });

    require(['collectionUtils'], function (collectionUtils) {
        var students =
            [
                {
                    id: 1,
                    fName: "Pesho",
                    lName: "Kolev",
                    age: 18,
                    marks: [6, 4, 5, 4, 5, 6]
                },
                {
                    id: 2,
                    fName: "Gosho",
                    lName: "Kolev",
                    age: 21,
                    marks: [5, 5, 3, 4, 5, 5]
                },
                {
                    id: 3,
                    fName: "Maria",
                    lName: "Kostova",
                    age: 19,
                    marks: [6, 5, 5, 4, 6, 5]
                },
                {
                    id: 4,
                    fName: "Gergana",
                    lName: "Petrova",
                    age: 19,
                    marks: [3, 4, 5, 4, 3, 3]
                },
                {
                    id: 5,
                    fName: "Mariana",
                    lName: "Veselinova",
                    age: 17,
                    marks: [6, 4, 5, 4, 3, 4]
                },
                {
                    id: 6,
                    fName: "Grigor",
                    lName: "Dimitrov",
                    age: 25,
                    marks: [3, 3, 3, 4, 3, 6]
                },
                {
                    id: 7,
                    fName: "Stamat",
                    lName: "Zhelyazkov",
                    age: 23,
                    marks: [6, 3, 3, 4, 4, 5]
                },
                {
                    id: 8,
                    fName: "Pesho",
                    lName: "Kotev",
                    age: 25,
                    marks: [3, 4, 6, 5, 4, 4]
                },
                {
                    id: 9,
                    fName: "Gergana",
                    lName: "Petkova",
                    age: 21,
                    marks: [6, 2, 2, 2, 2, 2]
                },
                {
                    id: 10,
                    fName: "Mariana",
                    lName: "Petkova",
                    age: 21,
                    marks: [6, 4, 3, 3, 4, 5]
                },
                {
                    id: 11,
                    fName: "Gosho",
                    lName: "Petkov",
                    age: 26,
                    marks: [2, 3, 3, 3, 4, 5]
                },
                {
                    id: 12,
                    fName: "Pesho",
                    lName: "Kurtev",
                    age: 25,
                    marks: [3, 5, 6, 4, 3, 5]
                },
                {
                    id: 13,
                    fName: "Kalina",
                    lName: "Petkova",
                    age: 25,
                    marks: [6, 5, 5, 6, 5, 4]
                },
            ];

        var animals = {
            alligator: {
                'class': 'reptile',
                'numberOfLegs': 4
            },
            octopus: {
                'class': 'cephalopod',
                'numberOfLegs': 8
            },
            bear: {
                'class': 'mammal',
                'numberOfLegs': 4
            },
            centipedes: {
                'class': 'chilopod',
                'numberOfLegs': 100
            },
            pesho: {
                'class': 'mammal',
                'numberOfLegs': 3
            },
            eagle: {
                'class': 'bird',
                'numberOfLegs': 2
            },
            lizard: {
                'class': 'reptile',
                'numberOfLegs': 4
            },
            flamingo: {
                'class': 'bird',
                'numberOfLegs': 2
            },
            human: {
                'class': 'mammal',
                'numberOfLegs': 2
            },
            turtle: {
                'class': 'reptile',
                'numberOfLegs': 4
            }
        };

        var books = [
            {
                name: 'Killing Floor',
                author: 'Lee Child',
                year: 1997
            },
            {
                name: 'Die Trying',
                author: 'Lee Child',
                year: 1998
            },
            {
                name: 'Tripwire',
                author: 'Lee Child',
                year: 1999
            },
            {
                name: 'The Visitor',
                author: 'Lee Child',
                year: 2000
            },
            {
                name: 'A Game Of Thrones',
                author: 'George R. R. Martin',
                year: 1996
            },
            {
                name: 'A Clash Of Kings',
                author: 'George R. R. Martin',
                year: 1998
            },
            {
                name: 'A Storm Of Swords',
                author: 'George R. R. Martin',
                year: 2000
            },
            {
                name: 'A Feast For Crows',
                author: 'George R. R. Martin',
                year: 2005
            },
            {
                name: 'A Dance Of Dragons',
                author: 'George R. R. Martin',
                year: 2011
            },
            {
                name: 'The Black Echo',
                author: 'Michael Connelly',
                year: 1992
            },
            {
                name: 'The Black Ice',
                author: 'Michael Connelly',
                year: 1993
            },
            {
                name: 'The Concrete Blond',
                author: 'Michael Connelly',
                year: 1994
            },
            {
                name: 'The Last Coyote',
                author: 'Michael Connelly',
                year: 1995
            },
            {
                name: 'The Poet',
                author: 'Michael Connelly',
                year: 1996
            },
            {
                name: 'Trunk Music',
                author: 'Michael Connelly',
                year: 1997
            },
            {
                name: 'Blood Work',
                author: 'Michael Connelly',
                year: 1998
            }
        ];

        var notify = document.createElement('div');
        notify.style.font = 'italic bold 35px Georgia, serif';
        notify.style.color = 'red';
        notify.innerHTML = "Open the console to see the result -> F12";
        document.getElementsByTagName('body')[0].appendChild(notify);

        console.log(collectionUtils.selectFNameBeforeLastSortDescendingByName(students));
        console.log(collectionUtils.filterByAgeExtractName(students));
        console.log(collectionUtils.findHighestMarks(students));
        console.log(collectionUtils.groupBySpeciesSortByLegs(animals));
        console.log(collectionUtils.calculateNumberOfLegs(animals));
        console.log(collectionUtils.findMostPopularAuthor(books));
        console.log(collectionUtils.findMostCommonFirstAndLastName(students));
    });
}());