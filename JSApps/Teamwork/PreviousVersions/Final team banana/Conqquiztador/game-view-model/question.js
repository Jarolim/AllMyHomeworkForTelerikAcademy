/// <reference path="../scripts/jquery-1.10.0.js" />
/// <reference path="../scripts/prototype.js" />

(function ($) {

    var CHOICES_ROWS_COUNT = 2;
    var MULTIPLE_CHOICE_CLASS = "multiple-question";
    var SHORT_ANSWER_CLASS = "short-question";
    var SHORT_ANSWER_ID = "sq-answer";
    var SHORT_ANSWER_SUBMIT_ID = "sq-submit";

    this.Question = Class.create({
        initialize: function (task, answer) {
            this.task = task;
            this._answer = answer;
        },
        checkAnswer: function (inputAnswer) {
            if (inputAnswer === this._answer) {
                return true;
            }

            return false;
        }
    });

    this.MultipleChoiceQuestion = Class.create(Question, {
        initialize: function ($super, task, answer, choices) {
            $super(task, answer);
            this._choices = choices;
        },
        render: function () {
            var container = $("<table class=" + MULTIPLE_CHOICE_CLASS + "'></table>");

            var task = "<tr><th colspan ='2'>" + this.task + "</td></tr>";
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

    this.ShortAnswerQuestion = Class.create(Question, {
        initialize: function ($super, task, answer, downLimit, upLimit) {
            $super(task, answer);
            this._upLimit = upLimit;
            this._downLimit = downLimit;
        },
        render: function () {
            var container = $("<div class='" + SHORT_ANSWER_CLASS + "'></div>");
            var task = "<p>" + this.task + "</p>";

            var form = $("<form></form>");
            var input = "<input type='text' id='" + SHORT_ANSWER_ID + "' /><br />";
            var submit = "<input type='button' id='" + SHORT_ANSWER_SUBMIT_ID + "' value='Submit Answer' />";
            form.append(input, submit);

            container.append(task, form);

            return container;
        }

    });

    return {
        Question: Question,
        MultipleChoiceQuestion: MultipleChoiceQuestion,
        ShortAnswerQuestion: ShortAnswerQuestion,
    }
}(jQuery))

var QuestionParser = (function () {

    function parseShortAnswerQuestion(json) {

        var saQuestion = new ShortAnswerQuestion(json.task, json.answer, json.downLimit, json.upLimit);
        return saQuestion;
    }

    function parseMultipleChoiceQuestion(json) {

        var answers = [json.a, json.b, json.c, json.d];
        var mcQuestion = new MultipleChoiceQuestion(json.task, json.answer, answers);
        return mcQuestion;
    }

    return {
        parseShortAnswerQuestion: parseShortAnswerQuestion,
        parseMultipleChoiceQuestion: parseMultipleChoiceQuestion
    }
}());