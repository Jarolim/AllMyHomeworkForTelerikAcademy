﻿/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
    var data = null;

    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "DonchoMinkov",
            password: "123456q",
            login: function () {
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					}, function () {
					    if (errorCallback) {
					        errorCallback();
					    }
					});
            },
            register: function () {
                data.users.register(this.get("username"), this.get("password"))
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function () {
                        if (errorCallback) {
                            errorCallback();
                        }
                    });
            }
        };
        return kendo.observable(viewModel);
    };

    function getCarsViewModel() {
        return data.cars.all()
			.then(function (cars) {
			    var viewModel = {
			        cars: cars,
			        message: "",
			        logout: function () {
			            data.users.logout()
                            .then(function () {
                                if (successCallback) {
                                    successCallback();
                                }
                            }, function () {
                                if (errorCallback) {
                                    errorCallback();
                                }
                            });
			        }
			    };
			    return kendo.observable(viewModel);
			});
    }

    return {
        getLoginVM: getLoginViewModel,
        getCarsVM: getCarsViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());