/*jslint browser: true*/
(function () {
    'use strict';
    require.config({
        paths: {
            jquery: "libs/jquery.min",
            handlebars: "libs/handlebars.min",
            controls: "modules/controls"
        },
        shim: {
            'handlebars': {
                'exports': 'Handlebars'
            }
        }
    });

    require(["jquery", "controls"], function ($, controls) {
        var people =
            [
                {
                    id: 1,
                    name: "Николай Костов",
                    avatarUrl: "images/niki.jpg",
                    age: 20
                },
                {
                    id: 2,
                    name: "Ивайло Кенов",
                    avatarUrl: "images/ivo.jpg",
                    age: 21
                },
                {
                    id: 3,
                    name: "Дончо Минков",
                    avatarUrl: "images/doncho.jpg",
                    age: 22
                },
                {
                    id: 4,
                    name: "Тодор Стоянов",
                    avatarUrl: "images/todor.jpg",
                    age: 23
                }
            ];

        var container = document.getElementById("container");
        var comboBox = controls.ComboBox(people);
        var template = $("#person-template").html();
        var comboBoxHtml = comboBox.render(template);
        container.innerHTML = comboBoxHtml;
    });
}());
