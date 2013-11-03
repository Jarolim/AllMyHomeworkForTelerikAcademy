var movingShapes = (function () {
    var divElement;
    var angle = 0;
    var rectangularDivs = [];
    var circleDivs = [];
    var container = document.getElementById("wrapper");
    var circleDivLeftPosition = 1000;
    var circleDivTopPosition = 200;
    var circleDivRadius = 150;
    var rectDivLeftPosition = 150;
    var rectDivTopPosition = 150;
    var maxRectCoordinates = { x: 500, y: 300 };

    setInterval(function () {
        moveCircleDiv(circleDivs)
    }, 60);

    setInterval(function () {
        moveRectDiv(rectangularDivs)
    }, 30);

    function add(movingType) {
        divElement = document.createElement("div");
        altertStyleToDiv(divElement);
        if (movingType == "rect") {
            divElement.style.position = "absolute";
            divElement.style.left = rectDivLeftPosition + "px";
            divElement.style.top = rectDivTopPosition + "px";
            rectangularDivs.push({ element: divElement, coordinates: { x: rectDivLeftPosition, y: rectDivTopPosition }, direction: "R" });
        }
        else if (movingType == "ellipse") {
            divElement.style.position = "absolute";
            divElement.style.left = circleDivLeftPosition + circleDivRadius + "px";
            divElement.style.top = circleDivTopPosition + "px";
            circleDivs.push({ element: divElement, angle: 0 });
        }
        container.appendChild(divElement);
    }

    function moveRectDiv(rectangularDivs) {
        for (var i = 0; i < rectangularDivs.length; i++) {
            if (rectangularDivs[i].direction == "R" && rectangularDivs[i].coordinates.x >= maxRectCoordinates.x) {
                rectangularDivs[i].direction = "B";
            }
            else if (rectangularDivs[i].direction == "B" && rectangularDivs[i].coordinates.y >= maxRectCoordinates.y) {
                rectangularDivs[i].direction = "L";
            }
            else if (rectangularDivs[i].direction == "L" && rectangularDivs[i].coordinates.x <= rectDivLeftPosition) {
                rectangularDivs[i].direction = "T";
            }
            else if (rectangularDivs[i].direction == "T" && rectangularDivs[i].coordinates.y <= rectDivTopPosition) {
                rectangularDivs[i].direction = "R";
            }
            if (rectangularDivs[i].direction == "R") {
                rectangularDivs[i].coordinates.x += 10;
            }
            else if (rectangularDivs[i].direction == "B") {
                rectangularDivs[i].coordinates.y += 10;
            }
            else if (rectangularDivs[i].direction == "L") {
                rectangularDivs[i].coordinates.x -= 10;
            }
            else if (rectangularDivs[i].direction == "T") {
                rectangularDivs[i].coordinates.y -= 10;
            }
            rectangularDivs[i].element.style.position = 'absolute';
            rectangularDivs[i].element.style.left = rectangularDivs[i].coordinates.x + 'px';
            rectangularDivs[i].element.style.top = rectangularDivs[i].coordinates.y + 'px';
        }
    }

    function moveCircleDiv(circleDivs) {
        var x = 0, y = 0;
        for (var i = 0; i < circleDivs.length; i++) {
            circleDivs[i].angle += 0.1;
            x = circleDivLeftPosition + circleDivRadius * Math.cos(circleDivs[i].angle);
            y = circleDivTopPosition + circleDivRadius * Math.sin(circleDivs[i].angle);
            circleDivs[i].element.style.position = 'absolute';
            circleDivs[i].element.style.left = x + 'px';
            circleDivs[i].element.style.top = y + 'px';
        }
    }

    function altertStyleToDiv(div) {

        div.style.width = "50px";
        div.style.height = "50px";
        div.style.lineHeight = div.style.height;
        div.style.textAlign = "center";
        div.style.verticalAlign = "middle";
        div.style.backgroundColor = rndColor();
        div.style.color = rndColor();
        div.innerHTML += "div";
        div.style.fontSize = "20px";
        div.style.borderStyle = "solid";
        div.style.borderRadius = "20px";
        div.style.borderColor = rndColor();
        div.style.borderWidth = "2px";
    }

    function rndColor() {
        var r = ('0' + generateRandomNumber(0, 255).toString(16)).substr(-2), // red
            g = ('0' + generateRandomNumber(0, 255).toString(16)).substr(-2), // green
            b = ('0' + generateRandomNumber(0, 255).toString(16)).substr(-2); // blue
        return '#' + r + g + b;
    }

    function generateRandomNumber(start, end) {
        var number = Math.floor(Math.random() * (end - start)) + start;
        return number;
    }

    return {
        add: add
    };
})();

function onRectDivClick() {
    movingShapes.add("rect");
}

function onCircleDivClick() {
    movingShapes.add("ellipse");
}