define(function(require) {
    'use strict';

    var Point = require('Point')

    var Engine = require('Engine')
    var Renderer = require('Renderer')
    var UserInterface = require('UserInterface')

    var Ball = require('Ball')
    var Food = require('Food')
    var Block = require('Block')
    var Snake = require('Snake')

    var ROWS = 22
    var COLS = 30

    var _canvas = document.getElementById('canvas')

    var _engine

    function init() {
        var renderer = new Renderer(_canvas, ROWS, COLS)
        var userInterface = new UserInterface(_canvas)

        _engine = new Engine(renderer, userInterface)
    }

    var make = (function() {
        function _makeBorders() {
            var row, col

            for (row = 0; row < ROWS; row++){
                _engine.add(new Block(Point(row, 0)))
                _engine.add(new Block(Point(row, COLS - 1)))
            }

            for (col = 1; col < COLS - 1; col++){
                _engine.add(new Block(Point(0, col)))
                _engine.add(new Block(Point(ROWS - 1, col)))
            }
        }

        function _makeEnviroment() {
            // _engine.add(new Block(Point(COLS / 2 - 1, COLS / 2 - 1)))

            _engine.add(new Food(Point(ROWS / 2, 20)))

            _engine.add(new Ball(Point(5, 5), Point(1, 1)))

            _engine.add(new Ball(Point(2, 2), Point.RIGHT))
            _engine.add(new Ball(Point(2, COLS - 3), Point.LEFT))

            // _engine.add(new Ball(Point(2, 5), Point.DOWN))
            // _engine.add(new Ball(Point(ROWS - 3, 5), Point.UP))
        }

        function _makeSnake() {
            _engine.addControlled(new Snake(Point(ROWS / 2, 6)))
        }

        return function() {
            _makeBorders(), _makeEnviroment(), _makeSnake()
        }
    }())

    init(), make(), _engine.run()
})
