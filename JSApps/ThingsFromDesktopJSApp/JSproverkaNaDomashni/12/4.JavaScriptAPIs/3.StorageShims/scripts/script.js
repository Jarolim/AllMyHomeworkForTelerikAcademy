// Taken from http://www.quirksmode.org/js/cookies.html
var cookie = (function() {
    return {
        create: function(name, value, days) {
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                var expires = "; expires=" + date.toGMTString();
            }
            else var expires = "";
            document.cookie = name + "=" + value + expires + "; path=/";
        },

        read: function(name) {
            var nameEQ = name + '='
            var ca = document.cookie.split(';')
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i]
                while (c.charAt(0) == ' ') c = c.substring(1, c.length)
                if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length)
            }
            return null
        }
    }
}())

var localStorageShim = (function() {
    var _getKey = (function() {
        var PREFIX = '__local__'

        return function(key) {
            return PREFIX + key
        }
    }())

    return {
        add: function(key, value) {
            cookie.create(_getKey(key), value, 365)
        },

        get: function(key) {
            return cookie.read(_getKey(key))
        }
    }
}())

var sessionStorageShim = (function() {
    var _getKey = (function() {
        var PREFIX = '__session__'

        return function(key) {
            return PREFIX + key
        }
    }())

    return {
        add: function(key, value) {
            cookie.create(_getKey(key), value)
        },

        get: function(key) {
            return cookie.read(_getKey(key))
        }
    }
}())

// Use with local server
localStorageShim.add('key', 'value')
console.log(localStorageShim.get('key'))

sessionStorageShim.add('key', 'value')
console.log(sessionStorageShim.get('key'))
