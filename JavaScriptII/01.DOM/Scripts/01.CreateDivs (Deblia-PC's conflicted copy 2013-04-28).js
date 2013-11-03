function createDivElements() {
    var count = parseInt(document.getElementById("quantity").value);
    var divsFragment = document.createDocumentFragment();

    for (var i = 0; i < count; i++) {
        var div = document.createElement("div");
        div.style.position = "absolute";
        div.style.top = randomBetween(20, screen.height -150) + 'px';
        div.style.left = randomBetween(20, screen.width - 150) + 'px';
        div.style.width = randomBetween(20, 150) + 'px';
        div.style.height = randomBetween(20, 150) + 'px';
        div.style.backgroundColor = getRandomColor();
        div.style.color = getRandomColor();
        div.style.borderRadius = randomBetween(0, 20) + 'px';
        div.style.borderWidth = randomBetween(1, 5) + 'px';
        div.style.border = randomBetween(1, 5) + "px solid " + getRandomColor();
        div.style.textAlign = "center";
        var strong = document.createElement("strong");
        strong.innerText = "div";
        div.appendChild(strong);
        divsFragment.appendChild(div);
    }

    document.body.appendChild(divsFragment);
}

function getRandomColor() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';

    for (var i = 0; i < 6; i++)
        color += letters[Math.round(Math.random() * 15)];

    return color;
}

function randomBetween(min, max) {
    var randomValue = Math.floor(min + Math.random() * max);
    return parseInt(randomValue);
}