/// <reference path="../scripts/qunit-1.11.0.js" />
/// <reference path="../game-view-model/quiz-game.js" />

(function () {
    module("ShortAnswerQuestion.init");
    test("Test creating short answer question with no limits", function () {
        throws(function () {
            var saQuestion = new QuizGame.ShortAnswerQuestion("Test task", 1234);
        })
    })

    test("Test creating short answer question with null down limit", function () {
        throws(function () {
            var saQuestion = new QuizGame.ShortAnswerQuestion("Test task", 1234, null, 123);
        })
    })

    test("Test creating short answer question with no up limit", function () {
        throws(function () {
            var saQuestion = new QuizGame.ShortAnswerQuestion("Test task", 1234, 123);
        })
    })

    test("Test creating short answer question with null up limit", function () {
        throws(function () {
            var saQuestion = new QuizGame.ShortAnswerQuestion("Test task", 1234, 123, null);
        })
    })

    test("Test creating short answer question with down limit greater than its up limit", function () {
        throws(function () {
            var saQuestion = new QuizGame.ShortAnswerQuestion("Test task", 1234, 123, 15);
        })
    })

    test("Test creating short answer question with valid limits", function () {
        var downLimit = 123;
        var upLimit = 135;

        var saQuestion = new QuizGame.ShortAnswerQuestion("Test task", 128, downLimit, upLimit);

        equal(saQuestion._downLimit, downLimit);
        equal(saQuestion._upLimit, upLimit);
    })

    module("ShortAnswerQuestion.getDownLimit");
    test("Test get down limit", function () {
        var downLimit = 123;
        var upLimit = 135;

        var saQuestion = new QuizGame.ShortAnswerQuestion("Test task", 128, downLimit, upLimit);
        var questionDownLimit = saQuestion.getDownLimit();

        equal(questionDownLimit, downLimit, "The return value is not the same as the input one.");
    })

    test("Test get up limit", function () {
        var downLimit = 123;
        var upLimit = 135;

        var saQuestion = new QuizGame.ShortAnswerQuestion("Test task", 128, downLimit, upLimit);
        var questionUpLimit = saQuestion.getUpLimit();

        equal(questionUpLimit, upLimit, "The return value is not the same as the input one.");
    })
}());