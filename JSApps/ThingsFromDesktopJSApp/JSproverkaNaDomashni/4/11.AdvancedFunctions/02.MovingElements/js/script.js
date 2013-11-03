(function () {
    'use strict';

    var TOP_MAX = 800;
    var TOP_MIN = 300;
    var LEFT_MAX = 510;
    var LEFT_MIN = 10;

    var RADIUS = 150;
    var X_CENTER = 420;
    var Y_CENTER = 130;

    var movingShapes = (function () {
        var add = function (shape) {
            if (shape === 'rectangular') {
                container.appendChild(makeNewDiv());
            }
            else if (shape === 'circular') {
                container.appendChild(makeNewDiv(true));
            }
        };

        function makeNewDiv(isCircle) {
            var newDiv = document.createElement('div');
            newDiv.textContent = 'div';
            newDiv.style.width = '50px';
            newDiv.style.height = '50px';
            newDiv.style.textAlign = 'center';
            newDiv.style.position = 'absolute';
            newDiv.style.borderWidth = '2px';
            newDiv.style.borderStyle = 'solid';
            newDiv.style.backgroundColor = randomizeColor();
            newDiv.style.borderColor = randomizeColor();
            newDiv.style.color = randomizeColor();
            if (isCircle) {
                newDiv.style.borderRadius = '50%';
                newDiv.className = 'circular';
                angles[angles.length] = randomizator(0, 6);
            }
            else {
                newDiv.className = 'rectangular';
                newDiv.style.top = randomizator(TOP_MAX, TOP_MAX) + 'px';
                newDiv.style.left = randomizator(LEFT_MIN, LEFT_MAX) + 'px';
            }

            return newDiv;
        }

        function randomizeColor() {
            var red = randomizator(0, 256);
            var green = randomizator(0, 256);
            var blue = randomizator(0, 256);

            return "rgb(" + red + "," + green + "," + blue + ")";
        }

        function randomizator(start, end) {
            var outputRandomNumber = Math.floor((Math.random() * (end - start + 1)) + start);
            return outputRandomNumber;
        }

        return {
            add: add
        };
    })();

    function moveCircDiv(angles, divs) {
        for (var i = 0; i < divs.length; i++) {
            angles[i] = angles[i] - 0.05;
            var x = Math.floor(X_CENTER + (RADIUS * Math.cos(angles[i])));
            var y = Math.floor(Y_CENTER + (RADIUS * Math.sin(angles[i])));
            divs[i].style.top = x + 'px';
            divs[i].style.left = y + 'px';
        }

        setTimeout(function () {
            moveCircDiv(angles, divs);
        }, 100);
    }

    function moveRectDiv(divs) {
        for (var i = 0; i < divs.length; i++) {
            var top = parseInt(divs[i].style.top, 10);
            var left = parseInt(divs[i].style.left, 10);
            if (top < TOP_MAX && left === LEFT_MIN) {
                top++;
            }
            else if (left < LEFT_MAX && top === TOP_MAX) {
                left++;
            }
            else if (left === LEFT_MAX && top > TOP_MIN) {
                top--;
            }

            else if (top === TOP_MIN && left > LEFT_MIN) {
                left--;
            }
            divs[i].style.top = top + 'px';
            divs[i].style.left = left + 'px';
        }

        setTimeout(function () {
            moveRectDiv(divs);
        }, 10);
    }
    
    var container = document.getElementById('wrapper');
    var rectDivs = document.getElementsByClassName('rectangular');
    var circDivs = document.getElementsByClassName('circular');
    var angles = [];
    moveCircDiv(angles, circDivs);
    moveRectDiv(rectDivs);

    var buttonCircular = document.querySelector("#circular");
    buttonCircular.addEventListener('click', function () {
       movingShapes.add('circular');
    });

    var buttonRectangular = document.querySelector('#rectangular');
    buttonRectangular.addEventListener('click', function () {
        movingShapes.add('rectangular');
    });
})();