define(function(require) {
    'use strict';

    var utils = require('utils')
    var Point = require('Point')
    var Food = require('Food')
    var GameObject = require('GameObject')

    // TODO: Extract geometry - bounding box
    var _getFirst, _getLast
    ;(function() {
        function _getFirstLast(minMax) {
            return this.parts.reduce(function(result, part) {
                result.row = minMax(result.row, part.row)
                result.col = minMax(result.col, part.col)

                return result
            }, new Point(minMax(), minMax())) // +/- Infinity
        }

        _getFirst = function() {
            return _getFirstLast.call(this, Math.min)
        }

        _getLast = function() {
            return _getFirstLast.call(this, Math.max)
        }
    }())

    function _getImage() {
        var first = _getFirst.call(this)
        var last = _getLast.call(this)

        var image = utils.makeMatrix
            ( last.row - first.row + 1
            , last.col - first.col + 1
        )

        this.parts.forEach(function(part) {
            image[part.row - first.row][part.col - first.col] = true
        })

        return image
    }

    // TODO: Extract ArrayOfPointsObject
    function Snake(position) {
        this.parts =
            [ Point.add(position, Point(0, 0))
            , Point.add(position, Point(0, 1))
            , Point.add(position, Point(0, 2))
            , Point.add(position, Point(0, 3))
        ]

        GameObject.call(this, _getImage.call(this), _getFirst.call(this), 'yellow')

        this.headDirection = Point.RIGHT
    }

    utils.inherit(Snake, GameObject)

    Snake.prototype.update = function() {
        var currentHead = this.parts[this.parts.length - 1]
        var nextHead = Point.add(currentHead, this.headDirection)

        if (utils.contains(this.parts, nextHead))
            return this.respondToCollision()

        if (this.isFed) this.isFed = false
        else this.parts.shift()

        this.parts.push(nextHead)

        this.image = _getImage.call(this)
        this.position = _getFirst.call(this)
    }

    // TODO: So many things are wrong here
    Snake.prototype.respondToCollision = function(data) {
        if (data && data.object instanceof Food) {
            this.isFed = true

            data.object.color = utils.randomColor()

            do {
                data.object.position = Point(utils.randomInt(1, 20), utils.randomInt(1, 28))
            } while (utils.contains(this.parts, data.object.position))
        }

        else {
            window.location.reload()
            throw new Error('Game over!');
        }
    }

    Snake.prototype.handleInput = (function() {
        var _unallowed =
            { 'LEFT' : 'RIGHT'
            , 'RIGHT': 'LEFT'

            , 'UP'   : 'DOWN'
            , 'DOWN' : 'UP'
        }

        // TODO: Decouple UserInterface and Point
        return function(input) {
            if (!this.headDirection.equals(Point[_unallowed[input]]))
                this.headDirection = Point[input]
        }
    }())

    return Snake
})
