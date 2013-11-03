/// <reference path="../libs/_references.js" />

define(["jquery", "httpRequester", "rsvp", "class", "cryptoJs"], function ($, httpRequester) {

    var username = localStorage.getItem("recipe-book-username");
    var sessionKey = localStorage.getItem("recipe-book-sessionKey");

    function saveSession(userData) {
        localStorage.setItem("recipe-book-username", userData.username);
        localStorage.setItem("recipe-book-sessionKey", userData.sessionKey);
        username = userData.username;
        sessionKey = userData.sessionKey;
    }

    function clearSession() {
        localStorage.removeItem("recipe-book-username");
        localStorage.removeItem("recipe-book-sessionKey");
        username = null;
        sessionKey = null;
    }

    var CategoriesPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        all: function () {
            return httpRequester.getJSON(this.apiUrl);
        },
        byId: function (id) {
            var url = this.apiUrl + "/" + id + "/recipes";
            return httpRequester.getJSON(url);
        }
    });

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            var self = this;
            var promise = new RSVP.Promise(function (resolve, reject) {
                var user = {
                    username: username,
                    authCode: CryptoJS.SHA1(username + password).toString()
                };
                return httpRequester.postJSON(self.apiUrl + "/login", user)
					.then(function (data) {
					    saveSession(data);
					    resolve(data);
					});
            });
            return promise;
        },
        register: function (username, password) {
            var self = this;
            var promise = new RSVP.Promise(function (resolve, reject) {
                var user = {
                    username: username,
                    authCode: CryptoJS.SHA1(username + password).toString()
                };
                return httpRequester.postJSON(self.apiUrl + "/register", user)
					.then(function (data) {
					    saveSession(data);
					    resolve(data);
					});
            });
            return promise;
        },

        logout: function (username, password) {
            var self = this;
            var promise = new RSVP.Promise(function (resolve, reject) {
                var user = {
                };

                var header = { "X-sessionKey": localStorage.getItem("recipe-book-sessionKey") };

                return httpRequester.putJSON(self.apiUrl + "/logout", user, header)
					.then(function (data) {
					    clearSession();
					    resolve(data);
					});
            });
            return promise;
        }
    });

    var RecipesPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        add: function (recipe) {
            var self = this;
            var header = { "X-sessionKey": localStorage.getItem("recipe-book-sessionKey") };
            var promise = new RSVP.Promise(function (resolve, reject) {

                return httpRequester.postJSON(self.apiUrl + "/add", recipe, header)
					.then(function (data) {
					    //saveSession(data);
					    resolve(data);
					});
            });
            return promise;
        },
        all: function () {
            var url = this.apiUrl + "/all";
            return httpRequester.getJSON(url);
        },
        byId: function (id) {
            var url = this.apiUrl + "/get/" + id;
            return httpRequester.getJSON(url);
        },

        like: function (id) {
            var url = this.apiUrl + "/like/" + id;
            var header = { "X-sessionKey": localStorage.getItem("recipe-book-sessionKey") };
            return httpRequester.putJSON(url, {}, header);
        },

        state: function (id) {
            var url = this.apiUrl + "/state/" + id;
            var header = { "X-sessionKey": localStorage.getItem("recipe-book-sessionKey") };
            return httpRequester.getJSON(url, header);
        },

        favourites: function () {
            var url = this.apiUrl + "/favourites";
            var header = { "X-sessionKey": localStorage.getItem("recipe-book-sessionKey") };
            return httpRequester.getJSON(url, header);
        },

        myRecipes: function () {
            var url = this.apiUrl + "/mine";
            var header = { "X-sessionKey": localStorage.getItem("recipe-book-sessionKey") };
            return httpRequester.getJSON(url, header);
        },
    });

    var ProductsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        all: function () {
            return httpRequester.getJSON(this.apiUrl);
        },
        measurements: function () {
            return httpRequester.getJSON(this.apiUrl + '/measurements');
        },
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.categories = new CategoriesPersister(this.apiUrl + "/categories");
            this.users = new UsersPersister(this.apiUrl + "/users");
            this.recipes = new RecipesPersister(this.apiUrl + "/recipes");
            this.products = new ProductsPersister(this.apiUrl + "/products");
        },

        isUserLoggedIn: function () {
            var sKey = localStorage.getItem("recipe-book-sessionKey");
            var usrName = localStorage.getItem("recipe-book-username");
            return sKey && usrName;
        },
        getCurrentUsername: function () {
            return username;
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    };
});