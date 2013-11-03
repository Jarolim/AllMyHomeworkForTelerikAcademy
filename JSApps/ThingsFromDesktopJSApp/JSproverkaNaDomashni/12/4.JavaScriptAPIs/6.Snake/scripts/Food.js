define(function(require) {
    'use strict';

    var utils = require('utils')
    var GameObject = require('GameObject')

    function Food(position) {
        GameObject.call(this, [[ true ]], position, utils.randomColor()) // TODO: Can't have black food

        // this.timeToLive = 50
    }

    utils.inherit(Food, GameObject)

    // Food.prototype.update = function() {
    //     this.timeToLive--

    //     if (!this.timeToLive)
    //         this.isDestroyed = true
    // }

    // Food.prototype.respondToCollision = function() {
    //     this.isDestroyed = true
    // }

    return Food
})
