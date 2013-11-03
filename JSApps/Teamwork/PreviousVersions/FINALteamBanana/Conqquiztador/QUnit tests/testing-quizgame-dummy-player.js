/// <reference path="../scripts/qunit-1.11.0.js" />
/// <reference path="../game-view-model/quiz-game.js" />

(function () {
    module("DummyPlayer.getMultipleQuestionAnswer");
    test("Get multiple question answer several times, check if in range", function () {
        var dummy = new QuizGame.DummyPlayer();

        var operationsCount = 35;
        var isInRange = true;
        var downLimit = 1;
        var upLimit = 4;

        for (var i = 0; i < operationsCount; i+=1) {
            var answer = dummy.getMultipleQuestionAnswer();

            if (answer<downLimit || answer>upLimit) {
                isInRange = false;
                break;
            }
        }

        ok(isInRange, "Everytime the given answer is in the specified range.")
    })

    module("DummyPlayer.getShortQuestionAnswer");
    test("Get answer of null question", function () {
        var dummy = new QuizGame.DummyPlayer();

        throws(function () {
            dummy.getShortQuestionAnswer(null);
        });
    })

    test("Get answer of object that is not short answer question", function () {
        var dummy = new QuizGame.DummyPlayer();
        var obj = { x: 2, y: 3 };
        throws(function () {
            dummy.getShortQuestionAnswer(obj);
        });
    })

    test("Get answer several times, check if in range", function () {
        var dummy = new QuizGame.DummyPlayer();
        var downLimit = 1100;
        var upLimit = 1330;
        var question = new QuizGame.ShortAnswerQuestion("Test task", 1255, downLimit, upLimit)
        var isInRange = true;
        var operationsCount = 35;

        for (var i = 0; i < operationsCount; i += 1) {
            var answer = dummy.getShortQuestionAnswer(question);

            if (answer < downLimit || answer > upLimit) {
                isInRange = false;
                break;
            }
        }

        ok(isInRange, "Everytime the given answer is in the specified range.")
    })
}());