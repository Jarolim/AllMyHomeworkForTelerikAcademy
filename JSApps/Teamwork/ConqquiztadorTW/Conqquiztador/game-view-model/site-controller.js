﻿/// <reference path="../scripts/jquery-1.10.0.js" />
/// <reference path="../scripts/q.js" />
/// <reference path="question.js" />
/// <reference path="quiz-game.js" />

/// Game flow
/// 1. init player - choose nickname
/// 2. start game
/// . choose field to attack - 10 seconds countdown if not selected automatically is choosed
/// . get question - type ABC
/// . get player and computer answers
/// . if answers are same we have second battle with question of type 123
/// . select round winner and add points
/// . repeat 2. until all fields are taken

var game = (function ($) {
    var PLAYER_COLOR = "rgba(255, 216, 0, 0.5)";
    var DUMMY_PLAYER_COLOR = "rgba(255, 106, 0, 0.5)";

    var GameController = Class.create({
        initialize: function () {
            //var self = this;
            this.field = new QuizGame.GameField();
            this.player = new QuizGame.Player;
            this.dummyPlayer = new QuizGame.DummyPlayer;
            this.renderer = new GameRenderer.Renderer();
            //this.currentQuestion;
        },
        startGame: function () {
            var self = this;

            // promises

            var getQuestionPromise = function (type) {
                var deferredQuestion = Q.defer();

                if (type === "multiple") {
                    $.getJSON("model/bd-multiple-choice-questions.js", function (data) {
                        var questionsNumber = data.length;

                        var index = Math.floor((Math.random() * 100 + 1) % questionsNumber);
                        self.currentQuestion = QuestionParser.parseMultipleChoiceQuestion(data[index]);

                        $("#current-question").html(self.currentQuestion.render());
                        deferredQuestion.resolve();
                    });
                }
                else {
                    $.getJSON("model/bd-short-answer-questions.js", function (data) {
                        var questionsNumber = data.length;

                        var index = Math.floor((Math.random() * 100 + 1) % questionsNumber);
                        self.currentQuestion = QuestionParser.parseShortAnswerQuestion(data[index]);

                        $("#current-question").html(self.currentQuestion.render());
                        deferredQuestion.resolve();
                    });
                }
                //setTimeout(function () {
                //    deferredQuestion.resolve();
                //}, 100);
                var message = "Answer the question before continue.";
                showMessage(message);
                return deferredQuestion.promise;
            };

            var getPlayerAnswerPromise = function () {
                var deferred = Q.defer();
                var answer = "";

                $("#question-box td").on("click", function (ev) {
                    ev = $(ev.target);
                    answer = ev.attr("id");
                    ev.css("background-color", PLAYER_COLOR);
                    deferred.resolve(answer);
                });

                setTimeout(function () {
                    if (answer == "") {
                        var randomId = Math.floor((Math.random() * 10) % 4) + 1;
                        $("td#" + randomId).css("background-color", PLAYER_COLOR);
                        deferred.resolve(randomId);
                    }
                }, 10000); // Time to answer

                return deferred.promise;
            };

            var getAnswersPromise = function (answer) {
                var deferred = Q.defer();

                var dummyAnswer = self.dummyPlayer.getMultipleQuestionAnswer();
                var rightAnswer = self.currentQuestion.getAnswer();
                setTimeout(function () {
                    $("td#" + dummyAnswer).css("background-color", DUMMY_PLAYER_COLOR);
                }, 1000);
                setTimeout(function () {
                    $("td#" + rightAnswer).css("background-color", "rgba(0, 255, 0, 0.5)");
                }, 1000);

                var answers = {
                    "player": answer,
                    "dummy": dummyAnswer,
                    "correct": rightAnswer
                };

                deferred.resolve(answers);

                return deferred.promise;
            }

            var getWinnerPromise = function (answers) {
                var deferred = Q.defer();

                //console.log(answers.player);
                //console.log(answers.dummy);
                //console.log(answers.correct);

                if (answers.player != answers.dummy) {
                    if (answers.player == answers.correct) {
                        deferred.resolve("player");
                    }
                    else {
                        if (answers.dummy == answers.correct) {
                            deferred.resolve("dummy");
                        }
                        else {
                            //deferred.reject("rematch");
                            // when we add the logic for short question we shoud use reject to ask for rematch
                            deferred.resolve("rematch");
                        }
                    }
                }
                else {
                    //deferred.reject("rematch");
                    deferred.resolve("rematch");
                }
                return deferred.promise;
            };

            // functions

            function showMessage(message) {
                //$("#flags-container").append("<p id='message'>" + message + "</p>");
                var message_box = $("#message");
                message_box.empty();
                message_box.append(message);
            };

            function loadPairs() {
                var scores = {};
                for (var i = 0; i < localStorage.length; i++) {
                    var name = localStorage.key(i);
                    var score = parseInt(localStorage.getItem(name));
                    scores[name] = score;
                }

                var tuples = [];
                for (var key in scores) {
                    tuples.push([key, scores[key]]);
                }
                tuples.sort(function (a, b) {
                    a = a[1];
                    b = b[1];

                    return a < b ? 1 : (a > b ? -1 : 0);
                });

                return tuples;
            }

            function saveScore(name, score) {
                var value = score;
                var key = name;
                localStorage.setItem(key, value);
            }

            self.renderer.renderWelcome();
            self.renderer.renderSkeleton();

            // attach events

            $("#score-btn").click(function () {
                var scoreBox = $("#score-box");
                if (scoreBox.css("display") === "none") {
                    scoreBox.html(self.renderer.renderScores(loadPairs()));
                    scoreBox.css("display", "block");
                }
                else {
                    scoreBox.css("display", "none");
                }
            })

            $("#nickname-button").on("click", function () {
                nickname = document.getElementById("nickname").value;
                $("#welcome-screen").fadeOut(1000).promise()
                .then(function () {
                    $("#wrapper").fadeIn(1000)
                })
                .then(function () {
                    self.player = new QuizGame.Player(nickname);
                    self.dummyPlayer = new QuizGame.DummyPlayer();

                    $("#player").append(self.player.render());
                    $("#dummy-player").html(self.dummyPlayer.render());
                });
            });

            $("#end-game-btn").click(function () {
                self.field.clearFlags();
                $("#current-question").html("");
                $("#start-game-btn").removeAttr("disabled");

                self.player = new QuizGame.Player(self.player.getName());
                self.dummyPlayer = new QuizGame.DummyPlayer(self.dummyPlayer.getName());

                $("#player").html(self.player.render());
                $("#dummy-player").html(self.dummyPlayer.render());
                var message = "Game ended! Use the button above to start new game.";
                showMessage(message);
            });

            $("#start-game-btn").on('click', function () {
                $("#start-game-btn").attr("disabled", "disabled");
                var flags = self.field.initializeFlags();
                self.renderer.renderFlags(flags);
                if ($("#help-box").is(":visible")) {
                    $("#help-box").hide();
                }
                if ($("#score-box").is(":visible")) {
                    $("#score-box").hide();
                }
                var message = "Please, choise one of the blue flags";
                showMessage(message);

                $(".flag").on('click', function () {
                    var selectedFlag = $(this);

                    getQuestionPromise("multiple")
                    .then(getPlayerAnswerPromise)
                    .then(getAnswersPromise)
                    .then(getWinnerPromise)
                    .then(function (winner) {
                        console.log(winner);
                        if (winner === "player") {
                           self.player.addPoints(10);
                           $("#player").html(self.player.render());

                            selectedFlag.attr({
                                "src": "images/green_flag.png",
                                "alt": "Green flag"
                            });
                            message = $("#player div.name").html() + " answered correct. Now choise again blue flag.";
                            showMessage(message);
                        }
                        else {
                            if (winner === "dummy") {
                                console.log(self.dummyplayer);
                                self.dummyPlayer.addPoints(10);
                                $("#dummy-player").html(self.dummyPlayer.render());

                                selectedFlag.attr({
                                    "src": "images/green_flag.png",
                                    "alt": "Green flag"
                                });
                                message = $("#dummy-player div.name").html() + " answered correct. Now choise again blue flag.";
                                showMessage(message);
                            }
                            else {
                                selectedFlag.attr({
                                    "src": "images/red_flag.png",
                                    "alt": "Red flag"
                                });

                                message = "Wrong answer! Now choose again blue flag.";
                                showMessage(message);
                            }
                        }
                        console.log($("[alt='Blue Flag']").length);
                        if ($("[alt='Blue Flag']").length == 0) {
                            var winnerName = "";
                            if (parseInt($("#dummy-player .points").html()) > parseInt($("#player .points").html())) {
                                winnerName = $("#dummy-player div.name").html();
                            }
                            else {
                                if (parseInt($("#dummy-player .points").html()) < parseInt($("#player .points").html())) {
                                    winnerName = $("#player div.name").html();
                                    saveScore(winnerName, parseInt($("#player .points").html()));
                                }
                                else {
                                    winnerName = "No one"
                                }
                            }
                            message = winnerName + " wins the game!";
                            showMessage(message);
                        }
                    });
                });
            });

            $("#help-btn").click(function () {
                var helpBox = $("#help-box");
                if (helpBox.is(":visible")) {
                    helpBox.hide();
                }
                else {
                    helpBox.show();
                }
            });
        }
    });

    return {
        GameController: GameController
    }
}(jQuery));