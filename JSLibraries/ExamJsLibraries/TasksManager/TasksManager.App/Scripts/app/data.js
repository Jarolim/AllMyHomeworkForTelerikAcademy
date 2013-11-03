window.persisters = (function () {
	//var accessToken = "";
	var bashUsername = "";
	var bashEmail = "";

	function clearLocalStorage() {
	    localStorage.removeItem("username");
	    localStorage.removeItem("accessToken");
	    accessToken = "";
	    bashUsername = "";
	}

	function saveAccessToken(accessTokenNew, username) {
	    localStorage.setItem("username", username);
	    localStorage.setItem("accessToken", accessTokenNew);
	    bashUsername = username;
	    accessToken = accessTokenNew;
	}

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

	function putJSON(requestUrl, data, headers) {
	    var promise = new RSVP.Promise(function (resolve, reject) {
	        $.ajax({
	            url: requestUrl,
	            type: "PUT",
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
		login: function (username, email, password) {
			var user = {
			    username: username,
                email: email,
				authCode: CryptoJS.SHA1(password).toString()
			};
			return postJSON(this.apiUrl + "auth/token", user) //login
				.then(function (data) {
				    saveAccessToken(data.accessToken, data.username);
				    accessToken = data.accessToken;
				    bashUsername = data.username;
				    //localStorage.setItem("username", data.username);
				    //localStorage.setItem("email", data.email);
				    //localStorage.setItem("accessToken", data.accessToken);
					//save to localStorage
				    accessToken = data.accessToken;
				    bashUsername = data.username;
				    bashEmail = data.email;
					//return data;
				});
		},
		register: function (username, email, password) {
			var user = {
			    username: username,
			    email: email,
				authCode: CryptoJS.SHA1(password).toString()
			};
			return postJSON(this.apiUrl + "users/register", user)
				.then(function (data) {
				    localStorage.setItem("username", data.username);
				    localStorage.setItem("email", data.email);
				    localStorage.setItem("accessToken", data.accessToken);
					//save to localStorage
				    accessToken = data.accessToken;
				    bashUsername = data.username;
				    bashEmail = data.email;
					//return data.username; // donno if needed
				});
		},
		logout: function () {
		    if (!accessToken) { 
		        console.log("error in logout missing accessToken");
		        }
			var headers = {
			    "X-accessToken": accessToken
			};
		    //clear accessToken
			clearLocalStorage();
			return putJSON(this.apiUrl + "/users", headers);
		},
		currentUser: function () {
			return bashUsername;
		}
	});

	var AppointmentsPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		all: function () {
            if (!accessToken) {
		        console.log("in error appointments persister");
		    }
		    var headers = {
		        "X-accessToken": accessToken
		    };
		    
		    clearLocalStorage();
			return getJSON(this.apiUrl + "all", headers);
		}
	});

	var TodoListPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    all: function () {
	        if (!accessToken) {
                console.log("error in todo list")
	            }
	            var headers = {
	                "X-accessToken": accessToken
	            };

	            clearLocalStorage();
	            return getJSON(this.apiUrl, headers);
	    }

	})

	var DataPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
			this.users = new UsersPersister(apiUrl);
			this.appointments = new AppointmentsPersister(apiUrl + "appointments/");
			this.lists = new TodoListPersister(apiUrl + "lists/");
		}
	});


	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());

