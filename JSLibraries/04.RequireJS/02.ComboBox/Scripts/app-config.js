/// <reference path="libs/class.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/require.js" />


require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        "class": "libs/class",
        mustache: "libs/mustache",
        controller: "app/controller"
    }
});

require(["jquery", "controller", "mustache"], function ($, controller, mustache) {

    var people = [
  { id: 1, name: "Doncho Minkov", age: 19, avatarUrl: "../Images/face1.jpg" },
  { id: 2, name: "Georgi Georgiev", age: 20, avatarUrl: "../Images/face2.jpg" },
    { id: 3, name: "Ivaylo Kenov", age: 21, avatarUrl: "../Images/face3.jpg" },
    { id: 4, name: "Niki Kostov", age: 22, avatarUrl: "../Images/face4.jpg" }];

    var comboBox = controller.createComboBox(people);

    var peopleTemplate = mustache.compile(document.getElementById("person-template").innerHTML);

    var comboBoxHTML = comboBox.render(peopleTemplate);

    $("#comboBox").append(comboBoxHTML);
});