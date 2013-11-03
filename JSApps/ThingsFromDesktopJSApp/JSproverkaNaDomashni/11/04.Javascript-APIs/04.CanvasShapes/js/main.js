(function () {
  'use strict';

  main(document.querySelector('canvas'));

  function main(canvas) {
    var c = canvas.getContext('2d');

    drawHead(c);
    drawBike(c);
    drawHouse(c);
  }

  function drawHead(c) {

    //draw face ellipse
    var face = {
      dimensions: {x: 50},
      center: {x: 100, y: 120}
    };

    face.dimensions.y = face.dimensions.x * 0.85;

    drawEllipse(face.center, face.dimensions, c);

    face.fillStyle = '#90CAD6';
    c.fillStyle = face.fillStyle;
    c.fill();

    face.strokeStyle = '#114B57';
    c.strokeStyle = face.strokeStyle;
    c.stroke();

    //draw left eye
    var eye = {
      dimensions: {
        x: face.dimensions.x / 6,
        y: face.dimensions.y / 6
      },
      center: {
        x: face.center.x - face.dimensions.x * 3 / 5,
        y: face.center.y - face.dimensions.y / 3
      }
    };

    c.fillStyle = face.strokeStyle;
    drawEye(eye.center, eye.dimensions, c);

    //draw right eye
    eye.center.x += face.dimensions.x;
    drawEye(eye.center, eye.dimensions, c);

    //draw nose
    var nose = {
      top: {
        x: eye.center.x - face.dimensions.x / 2,
        y: eye.center.y
      }
    };

    nose.bottom = {
      x: nose.top.x - eye.dimensions.x,
      y: eye.center.y + (face.center.y - eye.center.y) * 2
    };

    c.beginPath();
    c.moveTo(nose.top.x, nose.top.y);
    c.lineTo(nose.bottom.x, nose.bottom.y);
    c.lineTo(nose.top.x, nose.bottom.y);
    c.stroke();

    //draw mouth
    var mouth = {
      left: {
        x: face.center.x - face.dimensions.x * 3 / 5,
        y: nose.bottom.y
      },
      right: {
        x: face.center.x + face.dimensions.x * 3 / 5,
        y: nose.bottom.y
      }
    };

    c.beginPath();
    c.moveTo(mouth.left.x, mouth.left.y);
    c.bezierCurveTo(
      mouth.left.x + (mouth.right.x - mouth.left.x) / 2, mouth.left.y + 30,
      mouth.right.x, mouth.left.y + 30,
      mouth.right.x, mouth.right.y
    );
    c.bezierCurveTo(
      mouth.left.x + (mouth.right.x - mouth.left.x) / 2,  mouth.left.y + 15,
      mouth.left.x, mouth.left.y + 5,
      mouth.left.x, mouth.left.y
    );
    c.stroke();

    //draw hat
    var hatBottom = {
      center: {
        x: face.center.x,
        y: face.center.y - face.dimensions.y
      },
      dimensions: {
        x: face.dimensions.x,
        y: face.dimensions.y / 4
      }
    };

    drawEllipse(
      hatBottom.center,
      hatBottom.dimensions,
      c
    );

    c.fillStyle = '#3A6693';
    c.fill();

    var hatBody = {
      topLeft: {
        x: hatBottom.center.x - hatBottom.dimensions.x / 2,
        y: hatBottom.center.y - face.dimensions.y
      },
      dimensions: {
        x: hatBottom.dimensions.x,
        y: face.dimensions.y
      }
    };

    var hatBoddyBottom = {
      center: {
        x: hatBottom.center.x,
        y: hatBody.topLeft.y + hatBody.dimensions.y
      },
      dimensions: {
        x: hatBody.dimensions.x / 2,
        y: hatBottom.dimensions.y / 2
      }
    };

    drawEllipse(hatBoddyBottom.center, hatBoddyBottom.dimensions, c);
    c.fill();
    c.stroke();

    c.fillRect(
      hatBody.topLeft.x,
      hatBody.topLeft.y,
      hatBody.dimensions.x,
      hatBody.dimensions.y
    );

    c.beginPath();
    c.moveTo(hatBody.topLeft.x, hatBody.topLeft.y);
    c.lineTo(hatBody.topLeft.x, hatBody.topLeft.y + hatBody.dimensions.y);

    c.moveTo(hatBody.topLeft.x + hatBody.dimensions.x, hatBody.topLeft.y);
    c.lineTo(hatBody.topLeft.x + hatBody.dimensions.x, hatBody.topLeft.y + hatBody.dimensions.y);
    c.stroke();

    var hatBodyTop = {
      center: {
        x: hatBoddyBottom.center.x,
        y: hatBoddyBottom.center.y - hatBody.dimensions.y
      },
      dimensions: hatBoddyBottom.dimensions
    };

    drawEllipse(hatBodyTop.center, hatBodyTop.dimensions, c);
    c.fill();
    c.stroke();
  }

  function drawBike(c) {
    var leftWheel = {
      center: {
        x: 100,
        y: 300
      },
      dimensions: {
        r: 50
      }
    };

    c.beginPath();
    c.arc(leftWheel.center.x, leftWheel.center.y, leftWheel.dimensions.r, 0, Math.PI * 2, false);
    c.fillStyle = '#90CAD6';
    c.fill();
    c.strokeStyle = '#114B57';
    c.stroke();

    var rightWheel = {
      center: {
        x: 300,
        y: leftWheel.center.y
      },
      dimensions: leftWheel.dimensions
    };

    c.beginPath();
    c.arc(rightWheel.center.x, rightWheel.center.y, rightWheel.dimensions.r, 0, Math.PI * 2, false);
    c.fill();
    c.stroke();

    var frame = {
      bottomLeft: leftWheel.center,
      topRight: {
        x: rightWheel.center.x - rightWheel.dimensions.r / 2,
        y: rightWheel.center.y - rightWheel.dimensions.r * 1.25
      }
    };

    frame.bottomLeft.length = leftWheel.dimensions.r * 1.5;

    frame.middleJoinBottom = {
      x: frame.bottomLeft.x + frame.bottomLeft.length,
      y: frame.bottomLeft.y
    };

    frame.middleJoinTop = {
      x: leftWheel.center.x + frame.bottomLeft.length * Math.cos(Math.PI / 4),
      y: leftWheel.center.y - frame.bottomLeft.length * Math.sin(Math.PI / 4)
    };

    c.beginPath();
    c.moveTo(frame.bottomLeft.x, frame.bottomLeft.y);
    c.lineTo(frame.middleJoinBottom.x, frame.middleJoinBottom.y);
    c.lineTo(frame.topRight.x, frame.topRight.y);
    c.lineTo(frame.middleJoinTop.x, frame.middleJoinTop.y);
    c.closePath();
    c.stroke();

    var pedals = {
      center: frame.middleJoinBottom,
      dimensions: {
        r: 10
      }
    };

    c.beginPath();
    c.arc(pedals.center.x, pedals.center.y, pedals.dimensions.r, 0, Math.PI * 2, false);
    c.stroke();

    pedals.leftOne = {
      start: {
        x: pedals.center.x - pedals.dimensions.r * Math.cos(Math.PI / 4),
        y: pedals.center.y - pedals.dimensions.r * Math.sin(Math.PI / 4)
      }
    };

    pedals.leftOne.end = {
      x: pedals.leftOne.start.x - pedals.dimensions.r * Math.cos(Math.PI / 4),
      y: pedals.leftOne.start.y - pedals.dimensions.r * Math.sin(Math.PI / 4)
    };

    c.beginPath();
    c.moveTo(pedals.leftOne.start.x, pedals.leftOne.start.y);
    c.lineTo(pedals.leftOne.end.x, pedals.leftOne.end.y);
    c.stroke();

    pedals.rightOne = {
      start: {
        x: pedals.center.x + pedals.dimensions.r * Math.cos(Math.PI / 4),
        y: pedals.center.y + pedals.dimensions.r * Math.sin(Math.PI / 4)
      }
    };

    pedals.rightOne.end = {
      x: pedals.rightOne.start.x + pedals.dimensions.r * Math.cos(Math.PI / 4),
      y: pedals.rightOne.start.y + pedals.dimensions.r * Math.sin(Math.PI / 4)
    };

    c.beginPath();
    c.moveTo(pedals.rightOne.start.x, pedals.rightOne.start.y);
    c.lineTo(pedals.rightOne.end.x, pedals.rightOne.end.y);
    c.stroke();

    var seatTube = {
      bottom: pedals.center,
      through: frame.middleJoinTop
    };

    seatTube.throughRadius = Math.sqrt(
      Math.pow(seatTube.bottom.x - seatTube.through.x, 2) +
      Math.pow(seatTube.bottom.y - seatTube.through.y, 2)
    );

    seatTube.length = seatTube.throughRadius * 1.33;

    seatTube.top = {
      x: seatTube.bottom.x - seatTube.length * Math.cos(Math.acos(Math.abs(seatTube.through.x - seatTube.bottom.x) / seatTube.throughRadius)),
      y: seatTube.bottom.y - seatTube.length * Math.sin(Math.asin(Math.abs(seatTube.through.y - seatTube.bottom.y) / seatTube.throughRadius))
    };

    c.beginPath();
    c.moveTo(seatTube.bottom.x, seatTube.bottom.y);
    c.lineTo(seatTube.top.x, seatTube.top.y);
    c.stroke();

    var seat = {
      length: seatTube.length - seatTube.throughRadius
    };

    seat.start = {
      x: seatTube.top.x - seat.length / 2,
      y: seatTube.top.y
    };

    seat.end = {
      x: seat.start.x + seat.length,
      y: seat.start.y
    };

    c.beginPath();
    c.moveTo(seat.start.x, seat.start.y);
    c.lineTo(seat.end.x, seat.end.y);
    c.stroke();

    var steeringTube = {
      bottom: rightWheel.center,
      through: frame.topRight
    };

    steeringTube.throughRadius = Math.sqrt(
      Math.pow(steeringTube.bottom.x - steeringTube.through.x, 2) +
      Math.pow(steeringTube.bottom.y - steeringTube.through.y, 2)
    );

    steeringTube.length = rightWheel.dimensions.r * 2;

    steeringTube.top = {
      x: steeringTube.bottom.x - steeringTube.length * Math.cos(Math.acos(Math.abs(steeringTube.through.x - steeringTube.bottom.x) / steeringTube.throughRadius)),
      y: steeringTube.bottom.y - steeringTube.length * Math.sin(Math.asin(Math.abs(steeringTube.through.y - steeringTube.bottom.y) / steeringTube.throughRadius))
    };

    c.beginPath();
    c.moveTo(steeringTube.bottom.x, steeringTube.bottom.y);
    c.lineTo(steeringTube.top.x, steeringTube.top.y);
    c.stroke();

    var handlebars = {
      middle: steeringTube.top,
      length: Math.sqrt(
        Math.pow(steeringTube.top.x - steeringTube.through.x, 2) +
        Math.pow(steeringTube.top.y - steeringTube.through.y, 2)
      )
    };

    var upperHandlebar = {
      end: {
        x: handlebars.middle.x + handlebars.length * Math.cos(Math.PI * 9 / 8),
        y: handlebars.middle.y + handlebars.length * Math.sin(Math.PI * 9 / 8)
      }
    };

    c.beginPath();
    c.moveTo(handlebars.middle.x, handlebars.middle.y);
    c.lineTo(upperHandlebar.end.x, upperHandlebar.end.y);
    c.stroke();

    var lowerHandlebar = {
      end: {
        x: handlebars.middle.x + handlebars.length * Math.cos(Math.PI * 7 / 8),
        y: handlebars.middle.y + handlebars.length * Math.sin(Math.PI * 7 / 8)
      }
    };

    c.beginPath();
    c.moveTo(handlebars.middle.x, handlebars.middle.y);
    c.lineTo(lowerHandlebar.end.x, lowerHandlebar.end.y);
    c.stroke();
  }

  function drawEye(center, dimensions, c) {
    var eye = {
      dimensions: dimensions,
      center: center
    };

    drawEllipse(eye.center, eye.dimensions, c);
    c.stroke();

    var dot = {
      dimensions: {x: eye.dimensions.x / 3, y: eye.dimensions.y - c.lineWidth * 2},
      center: {x: eye.center.x - eye.dimensions.x * 2 / 5, y: eye.center.y}
    };

    drawEllipse(dot.center, dot.dimensions, c);
    c.fill();
  }

  function drawHouse(c) {
    var wall = {
      topLeft: {
        x: 400,
        y: 140
      },
      dimensions: {
        x: 250,
        y: 200
      }
    };

    c.beginPath();
    c.fillStyle = '#975B5B';
    c.fillRect(wall.topLeft.x, wall.topLeft.y, wall.dimensions.x, wall.dimensions.y);
    c.strokeStyle = 'black';
    c.strokeRect(wall.topLeft.x, wall.topLeft.y, wall.dimensions.x, wall.dimensions.y);

    var windowToWallMargin = 20;

    var window = {
      topLeft: {
        x: wall.topLeft.x + windowToWallMargin,
        y: wall.topLeft.y + windowToWallMargin
      },
      dimensions: {
        x: wall.dimensions.x / 6
      }
    };

    var windowToWindowMargin = 5;

    window.dimensions.y = window.dimensions.x / 1.5;

    c.beginPath();
    c.fillStyle = 'black';
    drawFourWindows(window.topLeft, window.dimensions, windowToWindowMargin, c);

    window.topLeft.x = wall.topLeft.x + wall.dimensions.x - windowToWallMargin - window.dimensions.x * 2 - windowToWindowMargin;
    window.topLeft.y = wall.topLeft.y + windowToWallMargin;
    drawFourWindows(window.topLeft, window.dimensions, windowToWindowMargin, c);

    window.topLeft.x = wall.topLeft.x + wall.dimensions.x - windowToWallMargin - window.dimensions.x * 2 - windowToWindowMargin;
    window.topLeft.y = wall.topLeft.y + wall.dimensions.y - windowToWallMargin - window.dimensions.y * 2 - windowToWindowMargin;
    drawFourWindows(window.topLeft, window.dimensions, windowToWindowMargin, c);

    var door = {
      centerBottom: {
        x: wall.topLeft.x + windowToWallMargin + window.dimensions.x + windowToWindowMargin / 2,
        y: wall.topLeft.y + wall.dimensions.y
      },
      dimensions: {
        x: (window.dimensions.x * 2 + windowToWindowMargin) / 1.5,
        y: (windowToWallMargin + window.dimensions.y * 2 + windowToWindowMargin)
      }
    };

    door.centerTop = {
      x: door.centerBottom.x,
      y: door.centerBottom.y - door.dimensions.y
    };

    c.strokeStyle = 'black';
    c.beginPath();
    c.moveTo(door.centerBottom.x, door.centerBottom.y);
    c.lineTo(door.centerTop.x, door.centerTop.y);
    c.stroke();

    c.beginPath();
    c.moveTo(door.centerTop.x, door.centerTop.y);
    c.quadraticCurveTo(
      door.centerTop.x + door.dimensions.x / 2, door.centerTop.y,
      door.centerTop.x + door.dimensions.x / 2, door.centerTop.y + door.dimensions.y / 5);
    c.lineTo(door.centerBottom.x + door.dimensions.x / 2, door.centerBottom.y);
    c.stroke();

    c.beginPath();
    c.moveTo(door.centerTop.x, door.centerTop.y);
    c.quadraticCurveTo(
      door.centerTop.x - door.dimensions.x / 2, door.centerTop.y,
      door.centerTop.x - door.dimensions.x / 2, door.centerTop.y + door.dimensions.y / 5);
    c.lineTo(door.centerBottom.x - door.dimensions.x / 2, door.centerBottom.y);
    c.stroke();

    var knob = {
      center: {
        x: door.centerBottom.x - door.dimensions.x / 6,
        y: door.centerBottom.y - door.dimensions.y / 3
      },
      dimensions: {
        r: 2
      }
    };

    c.beginPath();
    c.arc(knob.center.x, knob.center.y, knob.dimensions.r, 0, Math.PI * 2, false);
    c.stroke();

    knob.center.x = door.centerBottom.x + (door.centerBottom.x - knob.center.x);
    c.beginPath();
    c.arc(knob.center.x, knob.center.y, knob.dimensions.r, 0, Math.PI * 2, false);
    c.stroke();

    var roof = {
      bottomLeft: wall.topLeft,
      top: {
        x: wall.topLeft.x + wall.dimensions.x / 2,
        y: wall.topLeft.y - wall.dimensions.y / 2
      }
    };

    c.beginPath();
    c.moveTo(roof.bottomLeft.x, roof.bottomLeft.y);
    c.lineTo(roof.top.x, roof.top.y);
    c.lineTo(roof.bottomLeft.x + wall.dimensions.x, roof.bottomLeft.y);
    c.fillStyle = '#975B5B';
    c.fill();
    c.stroke();

    var chimney = {
      bottomLeft: {
        x: roof.bottomLeft.x + wall.dimensions.x * 0.75,
        y: roof.bottomLeft.y - (roof.bottomLeft.y - roof.top.y) * 0.25
      },
      dimensions: {
        x: wall.dimensions.x / 10,
        y: (roof.bottomLeft.y - roof.top.y) * 0.5
      }
    };

    c.beginPath();
    c.fillRect(chimney.bottomLeft.x, chimney.bottomLeft.y - chimney.dimensions.y, chimney.dimensions.x, chimney.dimensions.y);
    c.moveTo(chimney.bottomLeft.x, chimney.bottomLeft.y);
    c.lineTo(chimney.bottomLeft.x, chimney.bottomLeft.y - chimney.dimensions.y);
    c.moveTo(chimney.bottomLeft.x + chimney.dimensions.x, chimney.bottomLeft.y);
    c.lineTo(chimney.bottomLeft.x + chimney.dimensions.x, chimney.bottomLeft.y - chimney.dimensions.y);
    c.stroke();

    var chimneyTop = {
      center: {
        x: chimney.bottomLeft.x + chimney.dimensions.x / 2,
        y: chimney.bottomLeft.y - chimney.dimensions.y
      },
      dimensions: {
        x: chimney.dimensions.x / 2,
      }
    };

    chimneyTop.dimensions.y = chimneyTop.dimensions.x / 4;
    drawEllipse(chimneyTop.center, chimneyTop.dimensions, c);
    c.fill();
    c.stroke();
  }

  function drawFourWindows(topLeft, dimensions, margin, c) {
    c.fillRect(topLeft.x, topLeft.y, dimensions.x, dimensions.y);
    topLeft.x = topLeft.x + dimensions.x + margin;
    c.fillRect(topLeft.x, topLeft.y, dimensions.x, dimensions.y);
    topLeft.y = topLeft.y + dimensions.y + margin;
    c.fillRect(topLeft.x, topLeft.y, dimensions.x, dimensions.y);
    topLeft.x = topLeft.x - dimensions.x - margin;
    c.fillRect(topLeft.x, topLeft.y, dimensions.x, dimensions.y);
  }

  function drawEllipse(center, dimensions, c) {
    var largestDimension = Math.max(dimensions.x, dimensions.y),
      scale = {x: dimensions.x / largestDimension, y: dimensions.y / largestDimension};

    c.beginPath();
    c.save();
    c.scale(scale.x, scale.y);
    c.arc(center.x / scale.x, center.y / scale.y, largestDimension, 0, Math.PI * 2, false);
    c.restore();
  }

  /*
  function drawCoordinates(c, canvas) {
    var stepSize = 20,
      lineVerticalPosition = stepSize;

    for (var i = 1; lineVerticalPosition <= canvas.height; i += 1, lineVerticalPosition = i * stepSize) {
      c.beginPath();
      c.moveTo(0, lineVerticalPosition);
      c.lineTo(canvas.width, lineVerticalPosition);
      c.stroke();
    }

    var lineHorizontalPosition = stepSize;

    for (i = 1; lineHorizontalPosition <= canvas.width; i += 1, lineHorizontalPosition = i * stepSize) {
      c.beginPath();
      c.moveTo(lineHorizontalPosition, 0);
      c.lineTo(lineHorizontalPosition, canvas.height);
      c.stroke();
    }
  }
  */
})();
