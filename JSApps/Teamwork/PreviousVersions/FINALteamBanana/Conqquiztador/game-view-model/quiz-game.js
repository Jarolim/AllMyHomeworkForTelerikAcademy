/// <reference path="../scripts/jquery-1.10.0.js" />
/// <reference path="../scripts/prototype.js" />
/// 
var QuizGame = (function ($) {
    var DUMMY_PLAYER_NAMES = ["Shrek", "Fionna", "Donald", "Bugs", "Spongebob"];
    var CHOICES_ROWS_COUNT = 2;
    var MULTIPLE_CHOICE_CLASS = "multiple-question";
    var SHORT_ANSWER_CLASS = "short-question";
    var SHORT_ANSWER_ID = "sq-answer";
    var SHORT_ANSWER_SUBMIT_ID = "sq-submit";
    var NAME_CLASS = "name";
    var POINTS_CLASS = "points";
    var PLAYER_ID_CONTAINER_CLASS = "player-id";
    var FLAGS_CONTAINER_ID = "flags-container";
    var FLAG_CLASS = "flag";
    var CHOICES_COUNT = 4;

    var GameField = Class.create({
        initializeFlags: function () {
            var flagsContainer = $("<div id=" + FLAGS_CONTAINER_ID + "></div>");
            for (var i = 0; i < 10; i++) {
                var fieldItem = $("<img>").attr({
                    id: "flag" + i,
                    class: FLAG_CLASS,
                    src: 'images/blue_flag.png',
                    alt: 'Blue Flag'
                });
                flagsContainer.append(fieldItem);
            }

            for (i = 0; i < 10; i++) {
                var redItem = $("<img>").attr({
                    id: "red_flag" + i,
                    class: FLAG_CLASS,
                    src: 'images/red_flag.png',
                    alt: 'Red Flag',
                });
                redItem.hide();
                flagsContainer.append(redItem);
            }

            return flagsContainer;
        },
        clearFlags: function () {
            $("#" + FLAGS_CONTAINER_ID).remove();
        }
    });

    var Player = Class.create({
        initialize: function (name) {
            this._name = name || "John Doe";
            this._name = $("<div>").text(this._name).html();
            this._points = 0;
        },
        addPoints: function (points) {
            if (points < 0) {
                throw "Cannot add negative number of points!";
            }
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
            playerId.append($("<div class=" + NAME_CLASS + ">" + this._name + "</div>"));
            playerId.append("<div class=" + POINTS_CLASS + ">" + this._points + "</div>")
            container.append(playerId);

            return container;
        }
    });

    var DummyPlayer = Class.create(Player, {
        initialize: function ($super) {
            var nameIndex = Math.floor((Math.random() * 10 + 1) % DUMMY_PLAYER_NAMES.length);
            $super(DUMMY_PLAYER_NAMES[nameIndex]);
        },
        getMultipleQuestionAnswer: function () {
            var answer = Math.floor((Math.random() * 10 + 1) % CHOICES_COUNT);
            return answer + 1;
        },
        getShortQuestionAnswer: function (question) {
            if (!question) {
                throw "Invalid input question! It cannot be null!";
            }

            if (!(question instanceof QuizGame.ShortAnswerQuestion)) {
                throw "Invalid input question! It must be a short answer question!";
            }

            var downLimit = question.getDownLimit();
            var upLimit = question.getUpLimit();
            var answer = Math.floor(Math.random() * (upLimit - downLimit + 1)) + downLimit;

            return answer;
        }
    });

    var Question = Class.create({
        initialize: function (task, answer) {
            if (!task) {
                throw "Invalid question task! It cannot be null!";
            }

            if (!answer) {
                throw "The answer of the question must be specified!";
            }

            this._task = task;
            this._answer = answer;
        },
        checkAnswer: function (inputAnswer) {
            if (!inputAnswer) {
                throw "You must specify a question answer to check with!";
            }

            if (inputAnswer == this._answer) {
                return true;
            }

            return false;
        },
        getAnswer: function () {
            return this._answer;
        }
    });

    var MultipleChoiceQuestion = Class.create(Question, {
        initialize: function ($super, task, answer, choices) {
            $super(task, answer);

            if (!choices || choices.length == 0 || choices.length != 4) {
                throw "Invalid choices for the question! You must specify 4 answer choices!"
            }

            this._choices = choices;
        },
        render: function () {
            var container = $("<table class=" + MULTIPLE_CHOICE_CLASS + "></table>");

            var task = "<tr><th colspan ='2'>" + this._task + "</td></tr>";
            container.append(task);

            for (var i = 1, counter = 1; i <= CHOICES_ROWS_COUNT; i += 1, counter += 2) {
                var row = $("<tr></tr>");

                var firstCell = $("<td></td>");
                firstCell.attr("id", counter);
                firstCell.append(counter + ". " + this._choices[counter - 1]);

                var secondCell = $("<td></td>");
                secondCell.attr("id", counter + 1);
                secondCell.append(counter + 1 + ". " + this._choices[counter]);

                row.append(firstCell, secondCell);

                container.append(row);
            }

            return container;
        }
    });

    var ShortAnswerQuestion = Class.create(Question, {
        initialize: function ($super, task, answer, downLimit, upLimit) {
            $super(task, answer);
            if (!downLimit || !upLimit) {
                throw "Invalid input limits! You muset specify down and up limit";
            }

            if (downLimit > upLimit) {
                throw "Down limit must be less than the up limit!";
            }

            this._downLimit = downLimit;
            this._upLimit = upLimit;
        },
        getDownLimit: function () {
            return this._downLimit;
        },
        getUpLimit: function () {
            return this._upLimit;
        },
        render: function () {
            var container = $("<div class='" + SHORT_ANSWER_CLASS + "'></div>");
            var task = "<p>" + this._task + "</p>";

            var form = $("<form></form>");
            var input = "<input type='text' id='" + SHORT_ANSWER_ID + "' /><br />";
            var submit = "<input type='button' id='" + SHORT_ANSWER_SUBMIT_ID + "' value='Submit Answer' />";
            form.append(input, submit);

            container.append(task, form);

            return container;
        }
    });

    return {
        GameField: GameField,
        Question: Question,
        MultipleChoiceQuestion: MultipleChoiceQuestion,
        ShortAnswerQuestion: ShortAnswerQuestion,
        Player: Player,
        DummyPlayer: DummyPlayer
    }
}(jQuery));