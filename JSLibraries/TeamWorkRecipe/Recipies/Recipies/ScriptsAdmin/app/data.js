/// <reference path="../_references.js" />
//define(["angular", "Class", /*,"CryptoJS"*/], function (angular, Class /*,CryptoJS*/) {
window.persister = (function () {
    var username = localStorage.getItem("username");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userData) {
        localStorage.setItem("username", userData.username);
        localStorage.setItem("sessionKey", userData.sessionKey);
        username = userData.username;
        sessionKey = userData.sessionKey;
    }

    function clearUserData() {
        localStorage.removeItem("username");
        localStorage.removeItem("sessionKey");
        username = "";
        sessionKey = "";
    }

    var MainPersister = Class.create({
        init: function (requester, rootUrl) {
            this.rootUrl = rootUrl;
            this.requester = requester;
            this.user = new UserPersister(this.requester, this.rootUrl);
            this.category = new CategoryPersister(this.requester, this.rootUrl);
            this.recipe = new RecipePersister(this.requester, this.rootUrl);
        },
        isUserLoggedIn: function () {
            var isLoggedIn = username != null && sessionKey != null
            return isLoggedIn;
        },
        username: function () {
            return username;
        }
    });

    var UserPersister = Class.create({
        init: function (requester, rootUrl) {
            this.rootUrl = rootUrl + "/users";
            this.requester = requester;
        },
        login: function (user, success, error) {
            var url = this.rootUrl + "/login";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            this.requester.post(url, userData)
                .success(function (data) {
                    saveUserData(data);
                    success(data);
                })
                .error(error);
        },
        //register: function (user, success, error) {
        //    var url = this.rootUrl + "/register";
        //    var userData = {
        //        username: user.username,
        //        authCode: CryptoJS.SHA1(user.username + user.password).toString()
        //    };

        //    this.requester.post(url, userData)
        //        .success(function (data) {
        //            saveUserData(data);
        //            success(data);
        //        })
        //        .error(error);

        //},
        logout: function (success, error) {
            var url = this.rootUrl + "/logout";

            var config = {
                headers: {
                    "X-sessionKey": sessionKey
                }
            };

            this.requester.put(url, {}, config)
               .success(function () {
                   clearUserData();
                   success();
               })
               .error(error);
        },
        getAll: function (success, error) {
            var url = this.rootUrl + "/get";

            var config = {
                headers: {
                    "X-sessionKey": sessionKey
                }
            };

            this.requester.get(url, config)
               .success(success)
               .error(error);
        },
        promoteToAdmin: function (user, success, error) {
            var url = this.rootUrl + "/" + user.id + "/promote";

            var config = {
                headers: {
                    "X-sessionKey": sessionKey
                }
            };

            this.requester.put(url, user, config)
               .success(success)
               .error(error);
        },
        changePassword: function (user, success, error) {
            var url = this.rootUrl + "/" + user.id + "/update";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            var config = {
                headers: {
                    "X-sessionKey": sessionKey
                }
            };

            this.requester.put(url, userData, config)
               .success(success)
               .error(error);
        },
        deleteUser: function (user, success, error) {
            var url = this.rootUrl + "/" + user.id + "/delete";

            var config = {
                headers: {
                    "X-sessionKey": sessionKey
                }
            };

            this.requester.put(url, {}, config)
               .success(success)
               .error(error);
        },
    });


    var CategoryPersister = Class.create({
        init: function (requester, rootUrl) {
            this.rootUrl = rootUrl + "/categories";
            this.requester = requester;
        },
        getAll: function (success, error) {
            var url = this.rootUrl;

            this.requester.get(url)
               .success(success)
               .error(error);
        },
        getWithId: function (id, success, error) {
            var url = this.rootUrl + "/" + id;

            this.requester.get(url)
               .success(success)
               .error(error);
        },
        deleteCategory: function (id, success, error) {
            var url = this.rootUrl + "/" + id + "/delete";

            var config = {
                headers: {
                    "X-sessionKey": sessionKey
                }
            };

            this.requester.put(url, {}, config)
               .success(success)
               .error(error);
        },
    });

    var RecipePersister = Class.create({
        init: function (requester, rootUrl) {
            this.rootUrl = rootUrl + "/recipes";
            this.requester = requester;
        },
        getAll: function (success, error) {
            var url = this.rootUrl + "/all";

            this.requester.get(url)
               .success(success)
               .error(error);
        },
        getWithId: function (id, success, error) {
            var url = this.rootUrl +"/get/"+id;

            this.requester.get(url)
               .success(success)
               .error(error);
        },
        deleteRecipe: function (id, success, error) {
            var url = this.rootUrl + "/delete/" + id;

            var config = {
                headers: {
                    "X-sessionKey": sessionKey
                }
            };

            this.requester.put(url, {}, config)
               .success(success)
               .error(error);
        },
    });

    return {
        get: function (requester, rootUrl) {
            return new MainPersister(requester, rootUrl);
        }
    }
}());
//});