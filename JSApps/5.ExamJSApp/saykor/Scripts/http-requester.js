/// <reference path="jquery-2.0.2.js" />
/// <reference path="q.js" />

var httpRequester = (function () {
    var makeHttpRequest = function (url, type, data) {
        var deferred = Q.defer();

        var stringifiedData = "";
        if (data) {
            stringifiedData = JSON.stringify(data);
        }

        $.ajax({
            url: url,
            type: type,
            timeout: 5000,
            contentType: "application/json",
            data: stringifiedData,
            success: function (result) {
                deferred.resolve(result);
            },

            error: function (errorData) {
                deferred.reject(errorData);
            }
        });

        return deferred.promise;
    };

    var getJSON = function (url) {
        return makeHttpRequest(url, "get");
    };

    var postJSON = function (url, data) {
        return makeHttpRequest(url, "post", data);
    };

    return {
        postJSON: postJSON,
        getJSON: getJSON
    };
}())