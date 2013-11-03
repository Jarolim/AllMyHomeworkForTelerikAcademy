define(function(require) {
    'use strict';

    var utils = require('utils')
    var MovingObject = require('MovingObject')

    function Ball(position, direction) {
        MovingObject.call(this, [[ true ]], position, '#999', direction)
    }

    utils.inherit(Ball, MovingObject)

    return Ball
})
