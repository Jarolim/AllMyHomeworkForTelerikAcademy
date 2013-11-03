(function () {
  'use strict';

  var HighScores = (function () {
    var renderEl,
      maxEntryCount = 5;

    function getScores() {
      return JSON.parse(localStorage.getItem('highScores') || '[]');
    }

    function setScores(scores) {
      console.assert(
        scores.length <= maxEntryCount,
        'score size ' + scores.length + ' exceeds the maximum of ' + maxEntryCount);

      localStorage.setItem('highScores', JSON.stringify(scores));
    }

    return {
      render: function (el) {
        renderEl = el || renderEl;

        if (!renderEl) {
          return;
        }

        renderEl.innerHTML = '';

        var fragment = document.createDocumentFragment(),
          highScores = getScores();

        for (var i = 0, length = highScores.length; i < length; i += 1) {
          var userScore = highScores[i],
            userScoreEl = document.createElement('tr');

          var positionEl = document.createElement('td');
          positionEl.textContent = i + 1;
          userScoreEl.appendChild(positionEl);

          var nameEl = positionEl.cloneNode();
          nameEl.textContent = userScore.name;
          userScoreEl.appendChild(nameEl);

          var scoreEl = positionEl.cloneNode();
          scoreEl.textContent = userScore.score;
          userScoreEl.appendChild(scoreEl);

          fragment.appendChild(userScoreEl);
        }

        renderEl.appendChild(fragment);
      },
      addScore: function (userScore) {
        var scores = getScores(),
          newScoreIndex = scores.length;

        for (var i = 0, length = scores.length; i < length; i += 1) {
          var currentScore = scores[i].score;

          if (userScore.score < currentScore) {
            newScoreIndex = i;
            break;
          }
        }

        scores.splice(newScoreIndex, 0, userScore);

        if (scores.length > maxEntryCount) {
          scores.pop();
        }

        setScores(scores);
        this.render();
      }
    };
  })();

  HighScores.render(document.querySelector('#high-score tbody'));

  var Timer = (function () {
    var started = false,
      time = 0,
      beginTime,
      timeEl,
      requestAnimationFrame = window.requestAnimationFrame ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame,
      cancelAnimationFrame = window.cancelAnimationFrame ||
        window.webkitCancelAnimationFrame ||
        window.mozCancelAnimationFrame,
        requestId;

    function renderFrame() {
      time = Math.round(window.performance.now() - beginTime);
      showCurrentTime();
    }

    function showCurrentTime() {
      timeEl.textContent = time;
    }

    return {
      render: function (el) {
        timeEl = el;
        showCurrentTime();
      },
      start: function () {
        beginTime = window.performance.now();

        (function animloop() {
          requestId = requestAnimationFrame(animloop);
          renderFrame();
        })();

        started = true;
      },
      isStarted: function () {
        return started;
      },
      stop: function () {
        renderFrame();
        cancelAnimationFrame(requestId);
      },
      getTime: function () {
        return time;
      }
    };
  })();

  Timer.render(document.querySelector('#timer'));

  document.addEventListener('dragstart', function (event) {
    event.dataTransfer.effectAllowed = 'move';
    event.dataTransfer.setData('text/plain', '#' + event.target.id);

    if (!Timer.isStarted()) {
      Timer.start();
    }
  }, false);

  var binEl = document.querySelector('#bin');

  binEl.addEventListener('dragenter', function (event) {
    event.target.classList.add('opened');
    event.dropEffect = 'move';
  }, false);

  binEl.addEventListener('dragover', function (event) {
    event.preventDefault();
  }, false);

  binEl.addEventListener('dragleave', function (event) {
    event.target.classList.remove('opened');
  }, false);

  binEl.addEventListener('drop', function (event) {
    event.preventDefault();

    var draggedEl = document.querySelector(event.dataTransfer.getData('text/plain'));
    draggedEl.parentElement.removeChild(draggedEl);

    event.target.classList.remove('opened');

    if (document.querySelectorAll('[draggable]').length === 0) {
      Timer.stop();

      var name = window.prompt('Enter your name') || 'anonymous';

      HighScores.addScore({
        name: name,
        score: Timer.getTime()
      });
    }
  }, false);

  document.querySelector('#reset-game').addEventListener('click', function (event) {
    window.location.reload(true);
  }, false);
})();
