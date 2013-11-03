/// <reference path="../scripts/qunit-1.11.0.js" />
/// <reference path="../game-view-model/quiz-game.js" />

(function () {
    module("Player.init");

    test("Test creating player with valid name", function () {
        var name = "Pesho";
        var player = new QuizGame.Player(name);

        equal(player._name, name);
        equal(player._points, 0)
    })

    test("Test creating player with no name", function () {
        var name = "John Doe";
        var player = new QuizGame.Player();

        equal(player._name, name);
        equal(player._points, 0)
    })

    test("Test creating player with name a script fragment", function () {
        var name = "<script>alert('hack');</script>";
        var player = new QuizGame.Player(name);

        var escapedName = "&lt;script&gt;alert('hack');&lt;/script&gt;"
        equal(player._name, escapedName);
        equal(player._points, 0)
    })

    module("Player.addPoints");
    test("Test adding positive number of points", function () {
        var name = "Pesho";
        var pointsToAdd = 25;

        var player = new QuizGame.Player(name);
        player.addPoints(pointsToAdd);

        equal(player._points, pointsToAdd);
    })

    test("Test adding positive number of points several times", function () {
        var name = "Pesho";
        var pointsToAdd = 25;
        var nextPointsToAdd = 12;
        var lastPointsToAdd = 3;

        var player = new QuizGame.Player(name);
        player.addPoints(pointsToAdd);
        player.addPoints(nextPointsToAdd);
        player.addPoints(lastPointsToAdd);

        equal(player._points, pointsToAdd + nextPointsToAdd + lastPointsToAdd);
    })

    test("Test adding negative number of points", function () {
        var name = "Pesho";
        var pointsToAdd = -25;

        var player = new QuizGame.Player(name);
        throws(function () {
            player.addPoints(pointsToAdd);
        });
    })

    module("Player.getName");
    test("Test get player name v1", function () {
        var name = "Pesho";

        var player = new QuizGame.Player(name);
        var playerName = player.getName();

        equal(playerName, name);
    })

    test("Test get player name v2", function () {
        var name = "Ivan";

        var player = new QuizGame.Player(name);
        var playerName = player.getName();

        equal(playerName, name);
    })

    module("Player.getPoints");
    test("Test get player points when no points added", function () {
        var name = "Pesho";

        var player = new QuizGame.Player(name);
        var playerPoints = player.getPoints();

        equal(playerPoints, 0);
    })

    test("Test get player points when some points added", function () {
        var name = "Ivan";
        var pointsToAdd = 12;

        var player = new QuizGame.Player(name);
        player.addPoints(pointsToAdd)
        var playerPoints = player.getPoints();

        equal(playerPoints, pointsToAdd);
    })
}());