/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
	var data = null;

	function getLoginViewModel(successCallback) {		
		var viewModel = {
		    username: "hasankata",
		    password: "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
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
					});
			}
		};
		return kendo.observable(viewModel);
	};

	function getAccountsViewModel() {
	    return data.accounts.all()
			.then(function (accounts) {
				var viewModel = {
				    accounts: accounts,
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

	function getAccountsDetailedViewModel(id) {
	    return data.accounts.getById(id)
           .then(function (account) {
               var viewModel = {
                   detailedAccount: account
               };
               return kendo.observable(viewModel);
           });
	}

	function getDepositVM(id) {
	    var viewModel = {
	        depositSum: "100",
            id:id,
	        deposit: function () {
	            data.accounts.deposit(this.get("depositSum"), this.get("id"))
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
	}
	function getWidhrawVm(id) {
	    var viewModel = {
	        withrawSum: "1",
	        id: id,
	        withraw: function () {
	            data.accounts.withraw(this.get("withrawSum"), this.get("id"))
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
	}
	
	return {
		getLoginVM: getLoginViewModel,
		getAccountsViewModel: getAccountsViewModel,
		getAccountsDetailedViewModel: getAccountsDetailedViewModel,
		getDepositVM: getDepositVM,
		getWidhrawVm:getWidhrawVm,
		setPersister: function (persister) {
			data = persister
		}
	};
}());