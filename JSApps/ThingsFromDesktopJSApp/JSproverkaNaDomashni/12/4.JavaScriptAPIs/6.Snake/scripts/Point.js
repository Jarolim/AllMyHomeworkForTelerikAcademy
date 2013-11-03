define(function() {
    'use strict';

    function Point(row, col) {
        if (!(this instanceof Point))
            return new Point(row, col)

        this.row = row || 0
        this.col = col || 0
    }

    Point.add = function(point1, point2) {
        return new Point
            ( point1.row + point2.row
            , point1.col + point2.col
        )
    }

    Point.subtract = function(point1, point2) {
        return new Point
            ( point1.row - point2.row
            , point1.col - point2.col
        )
    }

    Point.invert = function(point) {
        return new Point
            ( -point.row
            , -point.col
        )
    }

    Point.prototype =
        { equals: function(other) {
            return this.row === other.row &&
                   this.col === other.col
        }

        , clone: function() {
            return new Point
                ( this.row
                , this.col
            )
        }
    }

    Point.ZERO  = Object.freeze(new Point( 0,  0))
    Point.LEFT  = Object.freeze(new Point( 0, -1))
    Point.UP    = Object.freeze(new Point(-1,  0))
    Point.RIGHT = Object.freeze(new Point( 0,  1))
    Point.DOWN  = Object.freeze(new Point( 1,  0))

    return Point
})
