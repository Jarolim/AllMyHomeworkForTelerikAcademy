﻿/// <reference path="../scripts/jquery-1.10.0.js" />
/// <reference path="../scripts/prototype.js" />
/// <reference path="../scripts/q.js" />

var GameRenderer = (function ($) {
    var CONTAINER_CLASS = "container";
    var SOCIAL_BUTTONS_CLASS = "addthis_toolbox addthis_default_style";
    var FACEBOOK_BUTTON_CLASS = "addthis_button_facebook_like";
    var TWEETER_BUTTON_CLASS = "addthis_button_tweet";
    var PINTEREST_BUTTON_CLASS = "addthis_button_pinterest_pinit";
    var SOCIAL_CONTAINER_CLASS = "addthis_counter addthis_pill_style";
    var BODY = "body";
    var WELCOME_ID = "welcome-screen";
    var NICKNAME_ID = "nickname";
    var NICKNAME_BUTTON_ID = "nickname-button";
    var WRAPPER_ID = "wrapper";
    var FIELD_ID = "game-field";
    var SCORE_BOX_ID = "score-box";
    var HELP_BOX_ID = "help-box";
    var QUESTION_BOX_ID = "question-box";
    var MESSAGE_BOX_ID = "message";
    var QEUSTION_LABEL_ID = "question-label";
    var CURRENT_QUESTION_ID = "current-question";
    var PLAYER_ID = "player";
    var DUMMY_PLAYER_ID = "dummy-player";
    var START_ID = "start-game-btn";
    var END_ID = "end-game-btn";
    var HELP_ID = "help-btn";
    var SCORES_ID = "score-btn";
    var SOCIAL_BUTTONS_ID = "social-buttons";
    var SCOREBOARD_ID = "score-board";
    var SCORE_NAME_CLASS = "score-name";

    var Renderer = Class.create({
        renderWelcome: function () {
            var container = $("<div id='" + WELCOME_ID + "' class='" + CONTAINER_CLASS + "'></div>");
            container.append("<h1>Welcome To BananaQuiz Game!</h1>");

            var form = $("<form></form>");
            var inputs = "<label for=" + NICKNAME_ID + ">Please enter your nickname:</label>" +
                         "<br />" +
                         "<input type='text' id=" + NICKNAME_ID + " />" +
                         "<input type='button' id=" + NICKNAME_BUTTON_ID + " class =" + CONTAINER_CLASS + " value='Play!' />";
            form.append(inputs);

            container.append(form);

            $(BODY).append(container);
        },
        renderSkeleton: function () {

            var wrapper = $("<div id=" + WRAPPER_ID + "></div>");
            wrapper.css("display", "none");

            var socialButtons = renderSocialButtons();
            wrapper.append(socialButtons);

            var gameField = renderGameField();
            wrapper.append(gameField);

            var scoreBoardBox = $("<div id=" + SCORE_BOX_ID + "></div>");
            scoreBoardBox.addClass("container");
            scoreBoardBox.css("display", "none");
            wrapper.append(scoreBoardBox);

            var helpBox = renderHelpBox();
            wrapper.append(helpBox);

            var messageBox = renderMessageBox();
            wrapper.append(messageBox);

            var questionBox = renderQuestionBox();
            wrapper.append(questionBox);

            var playerBox = renderPlayerBox(PLAYER_ID);
            wrapper.append(playerBox);

            var dummyPlayerBox = renderPlayerBox(DUMMY_PLAYER_ID);
            wrapper.append(dummyPlayerBox);

            $(BODY).append(wrapper);
        },
        renderFlags: function (flags) {
            if (!flags) {
                throw "Invalid input flags DOM object! It cannot be null!";
            }

            if (!(flags instanceof jQuery)) {
                throw "The input is not a valid jQuery DOM object!"
            }

            $("#" + FIELD_ID).append(flags);
        },
        renderScores: function renderScores(tuples) {

            if (tuples == null) {
                throw "Invalid input tuples! Value cannot be null!";
            }

            if (tuples.length == 0) {
                var emptyList = $("<p>No scores yet!</p>");
                return emptyList;
            }

            var scoreList = $("<p id=" + SCOREBOARD_ID + "></p>");
            scoreList.append("<h3>Scores:</h3>")

            for (i = 0; i < 5 && i < tuples.length; i++) {
                var name = tuples[i][0];
                var points = tuples[i][1];
                var scoreItem =
                    "<span>" + (i + 1) + ". <span class=" + SCORE_NAME_CLASS + ">" + name + "</span> - " + points + " points</span> "
                scoreList.append(scoreItem);
            }

            return scoreList;
        }
    });

    function renderGameField() {
        var container = $("<div id=" + FIELD_ID + "></div>")

        var navigation = renderNavigation();
        container.append(navigation);

        return container;
    }

    function renderNavigation() {
        var container = $("<div></div>");
        container.append("<button id=" + START_ID + ">Start Game</button>");
        container.append("<button id=" + END_ID + ">End Game</button>");
        container.append("<button id=" + HELP_ID + ">Help</button>");
        container.append("<button id=" + SCORES_ID + ">Top Scores</button>");

        return container;
    }

    function renderHelpBox() {
        var container = $("<div id=" + HELP_BOX_ID + "></div>");
        container.addClass(CONTAINER_CLASS);
        container.css("display", "block");
        container.append("<p>Use the menu above to start new quiz game.</p>");
        container.append("<p>You have to open the blue flags one by one.</p>");
        container.append("<p>When new flag is opened, the question will be show.</p>");
        container.append("<p>You and your opponent answer the questions at the same time.</p>");
        container.append("<p>The player who's answer is more quickly will earn points.</p>");

        return container;
    }

    function renderMessageBox() {
        var container = $("<div id=" + MESSAGE_BOX_ID + "></div>");
        container.addClass(CONTAINER_CLASS);

        return container;
    }

    function renderQuestionBox() {
        var container = $("<div id=" + QUESTION_BOX_ID + "></div>");
        container.addClass(CONTAINER_CLASS);

        var label = "<div id=" + QEUSTION_LABEL_ID + ">Question</div>";
        container.append(label);

        var currentQuestionContainer = "<div id=" + CURRENT_QUESTION_ID + "></div>";
        container.append(currentQuestionContainer);

        return container;
    }

    function renderPlayerBox(id) {
        var container = $("<div id=" + id + "></div>");
        container.addClass(CONTAINER_CLASS);

        return container;
    }

    function renderSocialButtons() {
        var container = $("<div id=" + SOCIAL_BUTTONS_ID + "></div>");
        container.addClass(SOCIAL_BUTTONS_CLASS);

        var facebookButton = $("<a fb:like:layout='button_count'></a>");
        facebookButton.addClass(FACEBOOK_BUTTON_CLASS);
        container.append(facebookButton);

        var tweeterButton = $("<a></a>");
        tweeterButton.addClass(TWEETER_BUTTON_CLASS);
        container.append(tweeterButton);

        var pinterestButton = $("<a></a>");
        pinterestButton.addClass(PINTEREST_BUTTON_CLASS);
        container.append(pinterestButton);

        var socialButtonsContainer = $("<a></a>");
        socialButtonsContainer.addClass(SOCIAL_CONTAINER_CLASS);
        container.append(socialButtonsContainer);

        var script = $("<script></script>");
        script.attr("src", "//s7.addthis.com/js/300/addthis_widget.js#pubid=xa-51bc7f984764fef1");
        script.attr("type", "text/javascript");
        container.append(script);

        return container;
    }

    return {
        Renderer: Renderer
    }
}(jQuery));