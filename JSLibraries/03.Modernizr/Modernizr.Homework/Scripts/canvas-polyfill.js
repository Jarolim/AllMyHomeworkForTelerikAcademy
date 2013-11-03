var polyfillCanvas = (function(){
    function initCanvas() {
        var el = document.getElementById('canvas');
        var ctx = el.getContext('2d');

        ctx.fillStyle = '#000000';
        ctx.fillRect(0, 0, 200, 200);

        var body = document.getElementById("content");
        body.appendChild(el);
    }

    return {
        init: initCanvas
    }
})();

polyfillCanvas.init();