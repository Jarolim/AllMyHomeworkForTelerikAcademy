/// <reference path="../scripts/qunit-1.11.0.js" />
/// <reference path="../game-view-model/quiz-game.js" />

(function () {
    module("MultipleChoiceQuestion.init");
    test("Test creating multiple choice question with no choices array", function () {
        throws(function () {
            var mcQuestion = new QuizGame.MultipleChoiceQuestion("Test task", 3);
        })
    })

    test("Test creating multiple choice question with null choices array", function () {
        throws(function () {
            var mcQuestion = new QuizGame.MultipleChoiceQuestion("Test task", 3, null);
        })
    })

    test("Test creating multiple choice question with empty choices array", function () {
        throws(function () {
            var mcQuestion = new QuizGame.MultipleChoiceQuestion("Test task", 3, []);
        })
    })

    test("Test creating multiple choice question with less choices than needed", function () {
        throws(function () {
            var mcQuestion = new QuizGame.MultipleChoiceQuestion("Test task", 3, ["A", "B"]);
        })
    })

    test("Test creating multiple choice question with more choices than needed", function () {
        throws(function () {
            var mcQuestion = new QuizGame.MultipleChoiceQuestion("Test task", 3, ["A", "B", "C", "D", "E", "F"]);
        })
    })

    test("Test creating multiple choice question with valid chocies array", function () {
        var choices = ["A", "B", "C", "D"];
        var mcQuestion = new QuizGame.MultipleChoiceQuestion("Test task", 3, choices);

        var choicesAreValid = true;
        for (var i = 0, len = mcQuestion._choices.length; i < len; i += 1) {
            if (mcQuestion._choices[i] != choices[i]) {
                choicesAreValid = false;
                break;
            }
        }

        ok(choices, "Choices are not the same as input!");
    })
}());