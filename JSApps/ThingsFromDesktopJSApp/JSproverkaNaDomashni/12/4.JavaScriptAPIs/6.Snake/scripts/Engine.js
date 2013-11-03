define(function(require) {
    'use strict';

    var Point = require('Point')

    var MOVE_DELAY = 1000 / 10

    function Engine(renderer, userInterface) {
        this.controlledObject = null

        this.allObjects = []
        this.movingObjects = []

        this.renderer = renderer
        this.userInterface = userInterface
    }

    // TODO: If A collides with B - B collides with A
    var _checkForCollision = (function() {
        function _checkInDirection(obj, objDirection) {
            var i, cur
            var first, last
            var row, col

            for (i = 0; i < this.allObjects.length; i++) {
                cur = this.allObjects[i]

                if (cur === obj)
                    continue

                first = new Point
                    ( Math.max
                        ( obj.position.row + objDirection.row
                        , cur.position.row
                    )

                    , Math.max
                        ( obj.position.col + objDirection.col
                        , cur.position.col
                    )
                )

                last = new Point
                    ( Math.min
                        ( obj.position.row + obj.rows + objDirection.row
                        , cur.position.row + cur.rows
                    )

                    , Math.min
                        ( obj.position.col + obj.cols + objDirection.col
                        , cur.position.col + cur.cols
                    )
                )

                for (row = first.row; row < last.row; row++)
                    for (col = first.col; col < last.col; col++)
                        if (obj.image
                                [row - (obj.position.row + objDirection.row)]
                                [col - (obj.position.col + objDirection.col)] &&

                            cur.image
                                [row - cur.position.row]
                                [col - cur.position.col]
                        )
                            return cur
            }

            return null
        }

        return function(obj) {
            var direction = obj.direction || Point.ZERO

            var rowCollision = _checkInDirection.call(this, obj, new Point(direction.row, 0))
            var colCollision = _checkInDirection.call(this, obj, new Point(0, direction.col))

            var collision = rowCollision || colCollision

            var force = new Point
                ( rowCollision && direction.row || 0
                , colCollision && direction.col || 0
            )

            if (collision)
                return { object: collision, force: Point.invert(force) }

            // Diagonal
            collision = _checkInDirection.call(this, obj, direction)

            if (collision)
                return { object: collision , force: Point.invert(direction) }

            return null
        }
    }())

    Engine.prototype =
        { add: function(obj) {
            this.allObjects.push(obj)

            if (obj.direction)
                this.movingObjects.push(obj)
        }

        , addControlled: function(obj) {
            this.controlledObject = obj

            this.allObjects.push(obj)
            this.movingObjects.push(obj)
        }

        , run: (function() {
            function _renderAll() {
                var self = this

                this.allObjects.forEach(function(obj) {
                    self.renderer.add(obj)
                })

                this.renderer.renderAll()
            }

            function _run() {
                var currentDate = +new Date

                var self = this
                var input

                if (this.userInterface) {
                    input = this.userInterface.processInput()

                    input && this.controlledObject.handleInput(input)
                }

                this.movingObjects.forEach(function(obj) {
                    var collision = _checkForCollision.call(self, obj)

                    collision && obj.respondToCollision(collision)
                })

                this.allObjects.forEach(function(obj) {
                    obj.update()
                })

                this.allObjects = this.allObjects.filter(function(obj) {
                    return !obj.isDestroyed
                })

                _renderAll.call(this)

                setTimeout(_run.bind(this), Math.max(0, MOVE_DELAY - (+new Date - currentDate)))
            }

            return function() {
                _renderAll.call(this)

                setTimeout(_run.bind(this), MOVE_DELAY)
            }
        }())
    }

    return Engine
})
