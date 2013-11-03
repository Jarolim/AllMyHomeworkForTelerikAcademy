function fiveDivs() {
    setInterval("createDivs()", 100);
}

function clear() {
    document.body.innerHTML = "";
}

var addAngle = 0;
function createDivs() {
    clear();
    var centerX = 400;
    var centerY = 200;
    var radius = 150;
    for (var i = 0; i < 5; i++) {
        var currentAngle = 72 * i + addAngle;
        createDiv(centerX, centerY, radius, currentAngle)
    }
    addAngle += 2;
}

function createDiv(centerX, centerY, radius, angle) {
    var div = document.createElement("div");
    div.style.top = (centerY + radius * Math.sin(angle * Math.PI / 180)) + "px";
    div.style.left = (centerX + radius * Math.cos(angle * Math.PI / 180)) + "px";
    document.body.appendChild(div);
}