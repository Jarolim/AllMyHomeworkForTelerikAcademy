/// <reference path="../libs/_references.js" />


window.viewsFactory = (function () {
	var rootUrl = "Scripts/partials/";

	var templates = {};

	function getTemplate(name) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			if (templates[name]) {
				resolve(templates[name])
			}
			else {
				$.ajax({
					url: rootUrl + name + ".html",
					type: "GET",
					success: function (templateHtml) {
						templates[name] = templateHtml;
						resolve(templateHtml);
					},
					error: function (err) {
						reject(err)
					}
				});
			}
		});
		return promise;
	}

	function getLoginView() {
		return getTemplate("login-form");
	}

	function getAccountsView() {
		return getTemplate("accounts");
	}
	function getDetailedAccountsView() {
	    return getTemplate("detailed-accounts");
	}

	function getDepositMoneyView() {
	    return getTemplate("deposit-money");
	}

	function getWidhrawMoneyView() {
	    return getTemplate("withraw-money");
	}

	return {
		getLoginView: getLoginView,
		getAccountsView: getAccountsView,
		getDetailedAccountsView: getDetailedAccountsView,
		getDepositMoneyView: getDepositMoneyView,
		getWidhrawMoneyView: getWidhrawMoneyView
	};
}());