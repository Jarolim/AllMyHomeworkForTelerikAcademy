/// <reference path="http-requester.js" />
/// <reference path="class.js" />
/// <reference path="q.js" />
/// <reference path="sha1.js" />

var providers = (function () {
	var nickname = localStorage.getItem("nickname");
	var sessionKey = localStorage.getItem("sessionKey");
    
	function saveSession(userData) {
		localStorage.setItem("nickname", userData.nickname);
		localStorage.setItem("sessionKey", userData.sessionKey);
		nickname = userData.nickname;
		sessionKey = userData.sessionKey;
	}
    
	function clearSession() {
		localStorage.removeItem("nickname");
		localStorage.removeItem("sessionKey");
		nickname = "";
		sessionKey = "";
	}

	var BaseProvider = Class.create({
		init: function (serviceUrl) {
			this.serviceUrl = serviceUrl;
			this.user = new UserProvider(this.serviceUrl);
			this.game = new GameProvider(this.serviceUrl);
			this.message = new MessagesProvider(this.serviceUrl);
			this.guess = new GuessProvider(this.serviceUrl);
		},
		isUserLoggedIn: function () {
			var isLoggedIn = nickname != null && sessionKey != null;
			return isLoggedIn;
		},
		nickname: function () {
			return nickname;
		}
	});
	var UserProvider = Class.create({
		init: function (serviceUrl) {
			this.serviceUrl = serviceUrl + "user/";
		},
		login: function (username, password) {
			var url = this.serviceUrl + "login";
			var userData = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString()
			};

			return httpRequester.postJSON(url, userData).then(function (result) {
			    saveSession(result);
			}, function (error) {
			    console.log(error.responseText);
			});
		},
		register: function (username, nickname, password) {
			var url = this.serviceUrl + "register";
			var userData = {
			    username: username,
			    nickname: nickname,
			    authCode: CryptoJS.SHA1(password).toString()
			};
			return httpRequester.postJSON(url, userData).then(function (result) {
			    saveSession(result);
			}, function (error) {
			    console.log(error.responseText);
			});
		},
		logout: function (success, error) {
			var url = this.serviceUrl + "logout/" + sessionKey;
		    httpRequester.getJSON(url, function(data) {
		        clearSession();
		        success(data);
		    }, error);
		},
		scores: function () {
		    return httpRequester.getJSON(this.serviceUrl + "scores/" + sessionKey);
		}
	});
	var GameProvider = Class.create({
	    init: function (serviceUrl) {
	        this.serviceUrl = serviceUrl + "game/";
	    },
	    create: function (title, password, number) {
	        var hash = CryptoJS.SHA1(password).toString();

	        var url = this.serviceUrl + "create/" + sessionKey;
	        var data = {
	            title: title,
	            password: hash,
	            number: number
	        };
	        return httpRequester.postJSON(url, data);
	    },

	    join: function (gameId, password, number) {
	        var hash = CryptoJS.SHA1(password).toString();

	        var url = this.serviceUrl + "join/" + sessionKey;
	        var data = {
	            gameId: gameId,
	            password: hash,
	            number: number
	        };
	        return httpRequester.postJSON(url, data);
	    },

	    start: function (gameId) {
	        return httpRequester.getJSON(this.serviceUrl + "/" + gameId + "/start/" + sessionKey);
	    },
	    open: function () {
	        return httpRequester.getJSON(this.serviceUrl + "open/" + sessionKey);
	    },
	    active: function () {
	        return httpRequester.getJSON(this.serviceUrl + "my-active/" + sessionKey);
	    },
	    state: function (gameId) {
	        return httpRequester.getJSON(this.serviceUrl + "/" + gameId + "/state/" + sessionKey);
	    }
	});

	var GuessProvider = Class.create({
	    init: function (serviceUrl) {
	        this.serviceUrl = serviceUrl + "guess/";
	    },

	    make: function (gameId, number) {
	        var data = {
	            gameId: gameId,
	            number: number
	        };
	        return httpRequester.postJSON(this.serviceUrl + "make/" + sessionKey, data);
	    }

	});

	var MessagesProvider = Class.create({
	    init: function (serviceUrl) {
	        this.serviceUrl = serviceUrl + "messages/";
	    },

	    unread: function () {
	        return httpRequester.getJSON(this.serviceUrl + "unread/" + sessionKey);
	    },

	    all: function () {
	        return httpRequester.getJSON(this.serviceUrl + "all/" + sessionKey);
	    }

	});
	return {
		get: function (url) {
			return new BaseProvider(url);
		}
	};
}());