/// <reference path="../scripts/qunit-1.11.0.js" />
/// <reference path="../game-view-model/quiz-game.js" />

(function () {
    module("Question.init");
    test("Test question creation with null task", function () {
        var answer = 3;

        throws(function () {
            var question = new QuizGame.Question(null, answer);
        });
    })

    test("Test question creation with null answer", function () {
        var task = "Test task";

        throws(function () {
            var question = new QuizGame.Question(task, null);
        });
    })

    test("Test question creation with no answer", function () {
        var task = "Test task";

        throws(function () {
            var question = new QuizGame.Question(task);
        });
    })

    test("Test question creation with valid task and answer", function () {
        var task = "Test task";
        var answer = 5;

        var question = new QuizGame.Question(task, answer);

        equal(question._task, task);
        equal(question._answer, answer);
    })

    module("Question.chekAnswer");
    test("Test get answer with no input answer to check with", function () {
        var task = "Test task";
        var answer = 5;

        var question = new QuizGame.Question(task, answer);
        throws(function () {
            question.checkAnswer();
        })
    })

    test("Test get answer with null input answer", function () {
        var task = "Test task";
        var answer = 5;

        var question = new QuizGame.Question(task, answer);
        throws(function () {
            question.checkAnswer(null);
        })
    })

    test("Test get answer with correct input answer", function () {
        var task = "Test task";
        var answer = 5;

        var question = new QuizGame.Question(task, answer);
        var isAnswerCorrect = question.checkAnswer(answer);

        ok(isAnswerCorrect, "The answer is must be correct.")
    })

    test("Test get answer with incorrect input answer", function () {
        var task = "Test task";
        var answer = 5;
        var inputAnswer = 3;

        var question = new QuizGame.Question(task, answer);
        var isAnswerCorrect = question.checkAnswer(inputAnswer);

        ok(!isAnswerCorrect, "The answer is must be incorrect.")
    })
}());