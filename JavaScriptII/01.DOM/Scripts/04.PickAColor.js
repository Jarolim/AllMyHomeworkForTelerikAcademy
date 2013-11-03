var textarea = document.getElementsByTagName('textarea')[0];

function setBackground() {
    return textarea.style.backgroundColor = document.getElementsByName('background')[0].value;
}
function setFontColor() {
    return textarea.style.color = document.getElementsByName('font')[0].value;
}
