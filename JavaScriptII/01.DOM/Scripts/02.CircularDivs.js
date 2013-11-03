﻿function fiveDivs() {
    setInterval("createDivs()", 100);
}

function clear() {
    document.body.innerHTML = "";
}

var numberOFDivs = 5;
var calculatedAngle = 360 / numberOFDivs; // 360 degrees divided by 5 divs = 72 degrees
var addAngle = 0;
var centerX = 200;
var centerY = 200;
var radius = 100;
function createDivs() {
    clear();    
    for (var i = 0; i < numberOFDivs; i++) {
        var currentAngle = calculatedAngle * i + addAngle; 
        createDiv(centerX, centerY, radius, currentAngle)
    }

    addAngle += 3;
}

function createDiv(centerX, centerY, radius, angle) {
    var div = document.createElement("div");
    div.style.top = (centerY + radius * Math.sin(angle * Math.PI / 180)) + "px";
    div.style.left = (centerX + radius * Math.cos(angle * Math.PI / 180)) + "px";
    document.body.appendChild(div);
}