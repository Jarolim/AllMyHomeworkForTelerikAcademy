define(function(require) {
    'use strict';

    var utils = require('utils')
    var Point = require('Point')

    var ZOOM = 20
    var PADDING = 3
    var BACKGROUND_COLOR = 'black'

    function Renderer(canvas, rows, cols) {
        canvas.height = rows * ZOOM - PADDING
        canvas.width  = cols * ZOOM - PADDING

        this.context = canvas.getContext('2d')

        this.rows = rows
        this.cols = cols

        this.scene = utils.makeMatrix(this.rows, this.cols, BACKGROUND_COLOR)
        this.previousScene = utils.makeMatrix(this.rows, this.cols, null)
    }

    Renderer.prototype =
        { add: function(obj) {
            var first = Point
                ( Math.max(obj.position.row, 0)
                , Math.max(obj.position.col, 0)
            )

            var last = Point
                ( Math.min(obj.position.row + obj.rows, this.rows)
                , Math.min(obj.position.col + obj.cols, this.cols)
            )

            var row, col

            for (row = first.row; row < last.row; row++)
                for (col = first.col; col < last.col; col++)
                    if (obj.image[row - first.row][col - first.col])
                        this.scene[row][col] = obj.color
        }

        , renderAll: (function() {
            var _render = (function() {
                function _draw(row, col, color) {
                    if (this.scene[row][col] === this.previousScene[row][col])
                        return

                    this.context.fillStyle = color
                    this.context.fillRect(col * ZOOM, row * ZOOM, ZOOM - PADDING, ZOOM - PADDING)

                    this.previousScene[row][col] = color
                }

                return function() {
                    var row, col

                    for (row = 0; row < this.scene.length; row++)
                        for (col = 0; col < this.scene[row].length; col++)
                            _draw.call(this, row, col, this.scene[row][col])
                }
            }())

            function _clear() {
                var row, col

                for (row = 0; row < this.scene.length; row++)
                    for (col = 0; col < this.scene[row].length; col++)
                        this.scene[row][col] = BACKGROUND_COLOR
            }

            return function() {
                _render.call(this)
                _clear.call(this)
            }
        }())
    }

    return Renderer
})
