define(function(require) {
    'use strict';

    var KEY_MAP =
        { 37: 'LEFT'
        , 38: 'UP'
        , 39: 'RIGHT'
        , 40: 'DOWN'
    }

    function UserInterface(element) {
        var self = this

        this.input = []

        element.focus()

        // TODO: Add to element
        window.addEventListener('keydown', function(e) {
            e.preventDefault()

            self.input.push(KEY_MAP[e.which])
        })
    }

    // TODO: Use events and not strings
    UserInterface.prototype =
        { processInput: function() {
            return this.input.shift()
        }
    }

    return UserInterface
})
