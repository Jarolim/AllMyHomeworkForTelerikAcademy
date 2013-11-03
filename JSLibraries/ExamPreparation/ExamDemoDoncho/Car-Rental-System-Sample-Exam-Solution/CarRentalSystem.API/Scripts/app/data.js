/// <reference path="../libs/_references.js" />

window.persisters = (function () {
    var sessionKey = "";
    var bashUsername = "";
    function getJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };
            return postJSON(this.apiUrl + "login", user)
				.then(function (data) {
				    //save to localStorage
				    saveSessionKey(data.SessionKey, data.displayName);
				    sessionKey = data.sessionKey;
				    bashUsername = data.displayName;
				    //return data;
				}, function (err) {
				    console.log(err);
				});
        },
        register: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };
            return postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    //save to localStorage
				    saveSessionKey(data.SessionKey, data.displayName);
				    sessionKey = data.sessionKey;
				    bashUsername = data.displayName;
				    return data.displayName;
				});
        },
        logout: function () {
            if (localStorage.getItem("sessionKey")) { // !sessionKey??!?!?!
                return httpRequester.putJSON(this.apiUrl + "logout?sessionKey=" + localStorage.getItem("sessionKey"))
		        .then(function () {
		            clearLocalStorage();
		            console.log("in success logout");
		            var router = application.router();
		            router.navigate("/");

		        }, function () {
		            //debugger;
		            console.log("in error logout");
		            clearLocalStorage();
		            var router = application.router();
		            router.navigate("/");
		        });
            }
            else {
                console.log("It's already logged out");
            }

            var headers = {
                "X-sessionKey": sessionKey
            };
            //clear sessionKey
            sessionKey = "";
            return putJSON(this.apiUrl + "logout", headers);
        },
        currentUser: function () {
            return bashUsername;
        }
    });

    var CarsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        all: function () {
            return getJSON(this.apiUrl);
        }
        
    });

    var StoresPersister = Class.create({
    })

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl + "users/");
            this.cars = new CarsPersister(apiUrl + "cars/");
            this.stores = new StoresPersister(apiUrl + "stores/");
        }
    });


    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());