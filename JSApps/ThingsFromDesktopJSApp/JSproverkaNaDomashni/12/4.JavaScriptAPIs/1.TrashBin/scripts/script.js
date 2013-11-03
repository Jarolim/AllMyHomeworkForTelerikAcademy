/*global J */

;(function() {
    'use strict';

    function start() {
        record.start()

        J('.trash').removeClass('hide')
    }

    ;(function() {
        var _draggedElement

        J('.trash')
            .each(function() {
                J(this)
                    .css('left', J.random(100) + '%')
                    .css('top',  J.random(100) + '%')
            })
            .on('dragstart', function() {
                _draggedElement = this
            })

        J('.trash-bin')
            .on('dragenter', function() {
                J(this).addClass('opened')
            })
            .on('dragover', function(e) {
                e.preventDefault()
            })
            .on('dragleave', function() {
                J(this).removeClass('opened')
            })
            .on('drop', function(e) {
                e.preventDefault()

                J(this).removeClass('opened')

                J(_draggedElement).addClass('hide')

                onRemovedElement()
            })
    }())

    function onRemovedElement() {
        if (J('.trash:not(.hide)').length === 0)
            onGameOver()
    }

    function onGameOver() {
        record.end()

        start()
    }

    var record = (function() {
        var MAX_PLAYERS = 2

          , _highScore = localStorage.highScore && JSON.parse(localStorage.highScore) || []

          , _startDate

        function _add(name, time) {
           _highScore.push({ name: name, time: time })

           _highScore.sort(function(record1, record2) {
               return record1.time - record2.time
           })

           if (_highScore.length > MAX_PLAYERS)
               _highScore = _highScore.slice(0, MAX_PLAYERS)

           localStorage.highScore = JSON.stringify(_highScore)
        }

        function _showHighScore() {
            J.each(_highScore, function() {
                console.log(this.name, this.time / 1000)
            })
        }

        return {
            start: function() {
                _startDate = +new Date
            },

            end: function() {
                var endDate = +new Date

                  , name = window.prompt('Please enter your name:')

                _add(name, endDate - _startDate)

                _showHighScore()
            }
        }
    }())

    start()
}())
