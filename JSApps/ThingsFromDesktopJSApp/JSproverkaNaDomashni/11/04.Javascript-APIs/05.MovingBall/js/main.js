(function () {
  'use strict';

  var canvas = document.querySelector('canvas');

  draw(canvas.getContext('2d'), {x: canvas.width, y: canvas.height});

  function draw(c, boxDimensions) {
    drawBox(c, boxDimensions);

    var ball = {
      r: Math.floor(Math.min(boxDimensions.x, boxDimensions.y) / 10)
    };

    ball.center = {
      x: Math.round(boxDimensions.x / 2),
      y: Math.round(boxDimensions.y / 2)
    };

    ball.direction = {
      x: 'right',
      y: 'down'
    };

    ball.move = function () {
      c.clearRect(this.center.x - this.r, this.center.y - this.r, this.r * 2, this.r * 2);

      ball.updateX();
      ball.updateY();

      c.beginPath();
      c.arc(this.center.x, this.center.y, this.r, 0, Math.PI * 2, false);
      c.fillStyle = 'red';
      c.fill();
    };

    ball.updateX = function () {
      if (this.center.x - this.r === 1) {
        this.direction.x = 'right';

      } else if (this.center.x + this.r === boxDimensions.x - 1) {
        this.direction.x = 'left';

      }

      switch (this.direction.x) {
        case 'right':
          this.center.x += 1;
          break;
        case 'left':
          this.center.x -= 1;
          break;
      }
    };

    ball.updateY = function () {
      if (this.center.y - this.r === 1) {
        this.direction.y = 'down';

      } else if (this.center.y + this.r === boxDimensions.y - 1) {
        this.direction.y = 'up';

      }

      switch (this.direction.y) {
        case 'down':
          this.center.y += 1;
          break;
        case 'up':
          this.center.y -= 1;
          break;
      }
    };

    var requestAnimationFrame = window.requestAnimationFrame ||
      window.webkitRequestAnimationFrame ||
      window.mozRequestAnimationFrame;

    function render() {
      ball.move();
    };

    (function animLoop() {
      requestAnimationFrame(animLoop);
      render();
    })();
  }

  function drawBox(c, boxDimensions) {
    c.strokeRect(0, 0, boxDimensions.x, boxDimensions.y);
  }
})();
