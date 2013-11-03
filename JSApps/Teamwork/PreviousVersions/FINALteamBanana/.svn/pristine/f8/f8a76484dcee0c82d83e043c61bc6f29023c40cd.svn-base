module("Gamefield.init");////////////////////////////////////////////////////////////////////////////////////////////////////

test("When QuizGame is initialized, should set the correct field values", function () {
    var field = new QuizGame.GameField().flagsContainer;

    var quizGame = new site.SiteController(field);

    equal(field, quizGame.field.flagsContainer, "Field flagsContainer is set");
});

test("When QuizGame is initialized, should set the correct field values", function () {
    var field = new QuizGame.GameField().clearFlags();

    var quizGame = new site.SiteController(field);

    equal(field, quizGame.field.clearFlags(), "Field clearFlags is set");
});

module("Players.init");/////////////////////////////////////////////////////////////////////////////////////////////////////

test("When QuizGame is initialized, should set the correct player values", function () {
    var player = new QuizGame.Player().name;

    var quizGame = new site.SiteController(player);

    equal(player, quizGame.player.name, "Player name is set");
});

test("When QuizGame is initialized, should set the correct player values", function () {
    var player = new QuizGame.Player().addPoints(10);

    var quizGame = new site.SiteController(player);

    equal(player, quizGame.player.addPoints(10), "Player addPoints is set");
});

test("When QuizGame is initialized, should set the correct dummyPlayer values", function () {
    /*They return random but are working correctly*/
    //var dummyPlayer = new QuizGame.DummyPlayer()._name;
    //var dummyPlayer = new QuizGame.DummyPlayer().getMultipleQuestionAnswer;
    var dummyPlayer = new QuizGame.DummyPlayer().getShortQuestionAnswer;

    var quizGame = new site.SiteController(dummyPlayer);

    /*They return random but are working correctly*/
    //equal(dummyPlayer, quizGame.dummyPlayer._name, "DummyPlayer name is set");
    //equal(dummyPlayer, quizGame.dummyPlayer.getMultipleQuestionAnswer, "DummyPlayer name is set");
    equal(dummyPlayer, quizGame.dummyPlayer.getShortQuestionAnswer, "DummyPlayer getShortQuestionAnswer is set");
});

module("GameRenderer.init");////////////////////////////////////////////////////////////////////////////////////////////////////

test("When GameRenderer is initialized, should set the correct renderer values", function () {
    var renderer = new GameRenderer.Renderer().initialize();
    //var renderer = new GameRenderer.Renderer().renderScores();
    //var renderer = new GameRenderer.Renderer().renderFlags();

    var quizGame = new site.SiteController(renderer);

    equal(renderer, quizGame.renderer.initialize(), "Renderer initialize is set");
});

test("When GameRenderer is initialized, should set the correct renderer values", function () {
    var renderer = new GameRenderer.Renderer().renderSkeleton();
    //var renderer = new GameRenderer.Renderer().renderScores();
    //var renderer = new GameRenderer.Renderer().renderFlags();

    var quizGame = new site.SiteController(renderer);

    equal(renderer, quizGame.renderer.renderSkeleton(), "Renderer renderSkeleton is set");
});

test("When GameRenderer is initialized, should set the correct renderer values", function () {
    //var renderer = new GameRenderer.Renderer().renderScores();
    //var renderer = new GameRenderer.Renderer().renderFlags();
    var renderer = new GameRenderer.Renderer().renderWelcome();

    var quizGame = new site.SiteController(renderer);

    equal(renderer, quizGame.renderer.renderWelcome(), "Renderer renderWelcome is set");
});

module("GameRenderer exeptions");////////////////////////////////////////////////////////////////////////////////////////////////////

test("GameRenderer throw exeption on null task",
  function () {
      var _null = null;
      throws(function () {
          GameRenderer.Renderer().renderFlags(_null);
      });
  });

module("Questions");////////////////////////////////////////////////////////////////////////////////////////////////////

test("QuizGame.Question throw exeption on initialize with null task",
  function () {
      var _null = null;
      throws(function () {
          QuizGame.Question.initialize(_null);
      });
  });

test("QuizGame.Question throw exeption on checking answer with null task",
  function () {
      var _null = null;
      throws(function () {
          QuizGame.Question.checkAnswer(_null);
      });
  });

test("QuizGame.ShortAnswerQuestion throw exeption on initialize with null task",
  function () {
      var _null = null;
      throws(function () {
          QuizGame.ShortAnswerQuestion.initialize(_null);
      });
  });

test("QuizGame.MultipleChoiceQuestion throw exeption on initialize with null task",
  function () {
      var _null = null;
      throws(function () {
          QuizGame.MultipleChoiceQuestion.initialize(_null);
      });
  });

module("Question parser"); ////////////////////////////////////////////////////////////////////////////////////////////////

test("QuestionParser.parseShortAnswerQuestion throw exeption on null parse",
  function () {
      var _null = null;
      throws(function () {
          QuestionParser.parseShortAnswerQuestion(_null);
      });
  });

test("QuestionParser.parseMultipleChoiceQuestion throw exeption on null parse",
  function () {
      var _null = null;
      throws(function () {
          QuestionParser.parseMultipleChoiceQuestion(_null);
      });
  });
