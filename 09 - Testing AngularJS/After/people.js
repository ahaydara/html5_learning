'use strict';

var _ = require('underscore');

var people = [{
    "id": "1",
    "firstName": "Park",
    "lastName": "Cote"
}, {
    "id": "2",
    "firstName": "Terry",
    "lastName": "Dalton"
}, {
    "id": "3",
    "firstName": "Elinor",
    "lastName": "Bartlett"
}, {
    "id": "4",
    "firstName": "Wynn",
    "lastName": "Cash"
}, {
    "id": "5",
    "firstName": "Molina",
    "lastName": "Hull"
}, {
    "id": "6",
    "firstName": "Kellie",
    "lastName": "Diaz"
}, {
    "id": "7",
    "firstName": "Marla",
    "lastName": "Sherman"
}, {
    "id": "8",
    "firstName": "Baldwin",
    "lastName": "Noble"
}, {
    "id": "9",
    "firstName": "Isabelle",
    "lastName": "Moss"
}, {
    "id": "10",
    "firstName": "Marsh",
    "lastName": "Carney"
}, {
    "id": "11",
    "firstName": "Solis",
    "lastName": "Williams"
}, {
    "id": "12",
    "firstName": "Jeanine",
    "lastName": "Hardin"
}, {
    "id": "13",
    "firstName": "Fanny",
    "lastName": "Pacheco"
}, {
    "id": "14",
    "firstName": "Sondra",
    "lastName": "Gibson"
}, {
    "id": "15",
    "firstName": "Perez",
    "lastName": "Simmons"
}];

module.exports = {
    getAll: function () {
        return people;
    },
    get: function (id) {
        return _.find(people, function (p) {
            return p.id === id;
        });
    },
    save: function (id, person) {
        var oldPerson = _.find(people, function (p) {
            return p.id === id;
        });
        var index = _.indexOf(people, oldPerson);
        people[index] = person;
        return person;
    }
};
