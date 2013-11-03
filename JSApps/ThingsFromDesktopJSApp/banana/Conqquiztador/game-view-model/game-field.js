/// <reference path="../scripts/jquery-1.10.0.js" />
/// <reference path="../scripts/prototype.js" />
/// <reference path="../scripts/q.js" />

(function ($) {
    this.StartGame = Class.create({
        initialize: function () {

        },
        startNewGame: function () {
            var container = $("#mouse_pointer");
            container.empty();
            container.append("<ul>");

            for (var i = 0; i < 10; i++) {

                container.append("li");
                var fieldItem = $("<img>").attr({
                    id: "flag" + i,
                    class: 'flags' ,
                    src: 'images/blue_flag.png' ,
                    alt: 'Blue Flag',
                });
                container.append(fieldItem);
                container.append("</li>");
            }
            container.append("/ul");

            //for (var i = 0; i < 10; i++) {
            //    var redItem = $("<img>").attr({
            //        id: "red_flag" + i,
            //        class: 'flags',
            //        src: 'images/red_flag.png',
            //        alt: 'Red Flag',
            //    });
            //    redItem.hide();
            //    $("#mouse_pointer").append(redItem);
            //}
        },
        stopGame: function () {
            $("#mouse_pointer").empty();
        }
    });

    return {
        StartGame: StartGame
    }
}(jQuery));


//function getPointCoordinates(event) {

//    pointX = event.offsetX ? (event.offsetX) : event.pageX - document.getElementById("mouse_pointer").offsetLeft;
//    pointY = event.offsetY ? (event.offsetY) : event.pageY - document.getElementById("mouse_pointer").offsetTop;
//    document.getElementById("flag").style.left = (pointX - 1);
//    document.getElementById("flag").style.top = (pointY - 15);
//    document.getElementById("flag").style.visibility = "visible";

//    var coordinates = new Array;
//    coordinates[0] = pointX;
//    coordinates[1] = pointY;
//    console.log(coordinates[0], coordinates[1]);

//    return coordinates;
//}