define(function(require) {
    'use strict';

    var utils = require('utils')
    var Point = require('Point')
    var GameObject = require('GameObject')

    function MovingObject(image, position, color, direction) {
        GameObject.apply(this, arguments)

        this.direction = direction
    }

    utils.inherit(MovingObject, GameObject)

    MovingObject.prototype.update = function() {
        this.position = Point.add(this.position, this.direction)
    }

    MovingObject.prototype.respondToCollision = function(data) {
        if (data.force.row * this.direction.row < 0)
            this.direction = new Point(-1 * this.direction.row, this.direction.col)

        if (data.force.col * this.direction.col < 0)
            this.direction = new Point(this.direction.row, -1 * this.direction.col)
    }

    return MovingObject
})
