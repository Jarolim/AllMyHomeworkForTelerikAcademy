define(function() {
    'use strict';

    var utils =
        { makeMatrix: function(rows, cols, value) {
            var matrix = new Array(rows)

            var row, col

            for (row = 0; row < rows; row++) {
                matrix[row] = new Array(cols)

                for (col = 0; col < cols; col++)
                    matrix[row][col] = value
            }

            return matrix
        }

        , boolMatrixToString: function(matrix) {
            return matrix.map(function(row) {
                return row.map(function(cell) {
                    return cell ? 'X' : ' '
                }).join('')
            }).join('\n')
        }

        , inherit: function(Child, Parent) {
            Child.prototype = Object.create(Parent.prototype)
            Child.prototype.parent = Parent.prototype
            Child.prototype.constructor = Child
        }

        , contains: function(array, value) {
            var i

            for (i = 0; i < array.length; i++)
                if (array[i].equals(value))
                    return true

            return false
        }

        , randomInt: function(min, maxInclusive) {
            if (arguments.length === 1) return utils.randomInt(0, min)

            var possibleNumbers = maxInclusive - min + 1

            return min + Math.floor(Math.random() * possibleNumbers)
        }

        , randomByte: function() {
            var decimal = utils.randomInt(1 << 8)
            var hex = decimal.toString(16)

            if (hex.length === 1)
                hex = '0' + hex

            return hex.toUpperCase()
        }

        , randomColor: function() {
            var r = utils.randomByte()
              , g = utils.randomByte()
              , b = utils.randomByte()

            return '#' + r + g + b
        }
    }

    return utils
})
