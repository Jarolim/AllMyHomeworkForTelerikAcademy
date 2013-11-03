jQuery(function () {
    var sliderUl = $('section#slider ul');
    var imgs = sliderUl.find('img');
    var imgWidth = imgs[0].width;
    var imgsLen = imgs.length;
    var current = 1;
    $('section#slider-nav').find('span').on('click', function () {
        var direction = $(this).attr('class');
        loc = imgWidth;
        if (direction === 'right') {
            if (current < imgsLen) {
                ++current;
            } else {
                current = 1;
                loc = (imgWidth * imgsLen) - imgWidth;
                direction = 'left';
            }
        } else {
            if (current !== 1) {
                --current;
            } else {
                current = imgsLen;
                loc = (imgWidth * imgsLen) - imgWidth;
                direction = 'right';
            }
        }
        transition(sliderUl, loc, direction);
    });
    function transition(container, loc, direction) {
        var unit;
        if (direction && loc !== 0) {
            unit = (direction === 'right') ? '-=' : '+=';
            container.animate({
                'margin-left': unit ? (unit + loc) : loc
            }, 'slow');
        }
    }
});