/// <reference path="../scripts/qunit-1.11.0.js" />
/// <reference path="../game-view-model/quiz-game.js" />
/// <reference path="../game-view-model/question-parser.js" />

(function () {
    module("parseShortAnswerQuestion");
    test("Test parsing question with no input object", function () {
        throws(function () {
            var saQuestion = QuestionParser.parseShortAnswerQuestion();
        })
    })

    test("Test parsing question with null input", function () {
        throws(function () {
            var saQuestion = QuestionParser.parseShortAnswerQuestion(null);
        })
    })

    test("Test parsing question with input that is not an object", function () {
        throws(function () {
            var a = 5;
            var saQuestion = QuestionParser.parseShortAnswerQuestion(a);
        })
    })

    test("Test parsing question with valid input JSON object", function () {
        var task = "Test task";
        var answer = 1234;
        var downLimit = 123;
        var upLimit = 2345;
        var initialQuestion = new QuizGame.ShortAnswerQuestion(task, answer, downLimit, upLimit);
        var objToParse = {
            task: task,
            answer: answer,
            downLimit: downLimit,
            upLimit: upLimit
        }

        var saQuestion = QuestionParser.parseShortAnswerQuestion(objToParse);

        deepEqual(saQuestion, initialQuestion);
    })

    module("parseMultipleChoiceQuestion");
    test("Test parsing multiple choice question with no input object", function () {
        throws(function () {
            var saQuestion = QuestionParser.parseMultipleChoiceQuestion();
        })
    })

    test("Test parsing question with null input", function () {
        throws(function () {
            var saQuestion = QuestionParser.parseMultipleChoiceQuestion(null);
        })
    })

    test("Test parsing multiple choice question with input that is not an object", function () {
        throws(function () {
            var a = 5;
            var saQuestion = QuestionParser.parseMultipleChoiceQuestion(a);
        })
    })

    test("Test parsing multiple choice question with valid input JSON object", function () {
        var task = "Test task";
        var answer = 1;
        var choices = ["A", "B", "C", "D"];
        var initialQuestion = new QuizGame.MultipleChoiceQuestion(task, answer, choices);
        var objToParse = {
            task: task,
            answer: answer,
            a: "A",
            b: "B",
            c: "C",
            d: "D",
        }

        var mcQuestion = QuestionParser.parseMultipleChoiceQuestion(objToParse);

        deepEqual(mcQuestion, initialQuestion);
    })
}());