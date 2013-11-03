/// <reference path="../scripts/jquery-1.10.0.js" />
/// <reference path="../scripts/prototype.js" />
(function ($) {
    var DUMMY_PLAYER_NAMES = ["Shrek", "Fionna", "Donald", "Bugs", "Spongebob"];
    var NAME_CLASS = "name";
    var POINTS_CLAS = "points";
    var PLAYER_ID_CONTAINER_CLASS = "player_id";
    var CHOICES_COUNT = 4;

    this.Player = Class.create({
        initialize: function (name) {
            this._name = name;
            this._points = 0;
        },
        addPoints: function (points) {
            this._points += points;
        },
        getName: function () {
            return this._name;
        },
        getPoints: function () {
            return this._points;
        },
        render: function () {
            var container = $("<div></div>");
            var playerId = $("<div class=" + PLAYER_ID_CONTAINER_CLASS + "></div>");
            playerId.append("<div class=" + NAME_CLASS + ">" + this._name + "</div>")
            playerId.append("<div class=" + POINTS_CLAS + ">" + this._points + "</div>")
            container.append(playerId);

            return container;
        }
    });


    this.DummyPlayer = Class.create(Player, {
        initialize: function ($super) {
            var nameIndex = Math.floor((Math.random() * 10 + 1) % DUMMY_PLAYER_NAMES.length);
            $super(DUMMY_PLAYER_NAMES[nameIndex]);
        },
        getMultipleQuestionAnswer: function () {
            var answer = Math.floor((Math.random() * 10 + 1) % CHOICES_COUNT);
            return answer + 1;
        },
        getShortQuestionAnswer: function (question) {
            var downLimit = question.getDownLimit();
            var upLimit = question.getUpLimit();
            var answer = Math.floor(Math.random() * (upLimit - downLimit + 1)) + downLimit;

            return answer;
        }
    });


    return {
        Player: Player,
        DummyPlayer: DummyPlayer
    }
}(jQuery));