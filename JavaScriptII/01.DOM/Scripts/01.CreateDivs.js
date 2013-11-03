function createDivElements() {
    var count = parseInt(document.getElementById("count").value);
    var divsFragment = document.createDocumentFragment();

    for (var i = 0; i < count; i++) {
        var div = document.createElement("div");
        
        div.style.top = randomBetween(20, screen.height -500) + 'px'; // otherwize they are created in a small area
        div.style.left = randomBetween(20, screen.width - 500) + 'px'; // otherwize they are created in a small area
        div.style.width = randomBetween(20, 100) + 'px';
        div.style.height = randomBetween(20, 100) + 'px';
        div.style.backgroundColor = getRandomColor();
        div.style.color = getRandomColor();
        div.style.position = "absolute"; // otherwise they are created 1 under another

        var strong = document.createElement("strong");
        strong.innerText = "div";
        div.appendChild(strong);

        div.style.borderRadius = randomBetween(1, 20) + 'px';
        div.style.border = randomBetween(1, 20) + "px solid " + getRandomColor();
        div.style.borderWidth = randomBetween(1, 20) + 'px';
        
        div.style.textAlign = "center";

        divsFragment.appendChild(div);
    }

    document.body.appendChild(divsFragment);
}

function getRandomColor() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.round(Math.random() * 15)];
    }

    return color;
}

function randomBetween(min, max) {
    var randomValue = Math.floor(min + Math.random() * max);

    return parseInt(randomValue);
}