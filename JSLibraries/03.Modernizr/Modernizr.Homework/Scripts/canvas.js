var canvasCreator = (function () {
    function initFunction() {
        var canvas = document.getElementById('canvas');
        var ctx = canvas.getContext('2d');
        ctx.fillStyle = '#808080';
        ctx.fillRect(0, 0, 200, 200);
    }

    return {
        init: initFunction
    }
})();

canvasCreator.init();
