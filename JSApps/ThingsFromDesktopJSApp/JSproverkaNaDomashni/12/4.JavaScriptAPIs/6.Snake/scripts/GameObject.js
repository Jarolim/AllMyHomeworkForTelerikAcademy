define(function() {
    'use strict';

    function _noop() {

    }

    function GameObject(image, position, color) {
        this.image = image
        this.position = position
        this.color = color
    }

    GameObject.prototype =
        { get rows() {
            return this.image.length
        }

        , get cols() {
            return this.image[0].length
        }

        , update: _noop

        , respondToCollision: _noop
    }

    return GameObject
})
