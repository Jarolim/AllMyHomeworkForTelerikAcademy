/// <reference path="libs/kendo.web.min.js" />
/// <reference path="libs/_references.js" />


(function () {
	var appLayout =
		new kendo.Layout('<div id="main-content"></div>');
	var data = persisters.get("api/");
	vmFactory.setPersister(data);

	var router = new kendo.Router();
	router.route("/", function () {
		viewsFactory.getCarsView()
			.then(function (carsViewHtml) {
				vmFactory.getCarsVM()
				.then(function (vm) {
					var view =
						new kendo.View(carsViewHtml,
						{ model: vm });
					appLayout.showIn("#main-content", view);
				}, function (err) {
				    console.log(err);
				});
			});
	});

	router.route("/home", function () {
	    viewsFactory.getCarsView()
			.then(function (carsViewHtml) {
			    vmFactory.getCarsVM()
				.then(function (vm) {
				    var view =
						new kendo.View(carsViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);
				}, function (err) {
				    console.log(err);
				});
			});
	});

	router.route("/login", function () {
		if (data.users.currentUser()) {
			router.navigate("/");
		}
		else {
			viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
					var loginVm = vmFactory.getLoginVM(
						function () {
							router.navigate("/");
						});
					var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
					appLayout.showIn("#main-content", view);
				});
		}
	});

	router.route("/cars/filter", function () {
	    if (data.users.currentUser()) {
	        viewsFactory.getCarsView()
			.then(function (carsViewHtml) {
			    vmFactory.getFilteredCarsVM()
				.then(function (vm) {
				    var view =
						new kendo.View(carsViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);
				}, function (err) {
				    console.log(err);
				});
			});
	    }
	    else {
	        router.navigate("/login");
	        viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    router.navigate("/");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
	    }
	});

	router.route("/cars/page/:page/:count", function (page, count) {
	    if (data.users.currentUser()) {
	        viewsFactory.getCarsView()
			.then(function (carsViewHtml) {
			    vmFactory.getAtPageCarsVM(page, count)
				.then(function (vm) {
				    var view =
						new kendo.View(carsViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);
				}, function (err) {
				    console.log(err);
				});
			});
	    }
	    else {
	        router.navigate("/login");
	        viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    router.navigate("/");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
	    }
	});

	router.route("/cars/rented", function () {
	    if (data.users.currentUser()) {
	        viewsFactory.getCarsView()
			.then(function (carsViewHtml) {
			    vmFactory.getRentedCarsVM()
				.then(function (vm) {
				    var view =
						new kendo.View(carsViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);
				}, function (err) {
				    console.log(err);
				});
			});
	    }
	    else {
	        router.navigate("/login");
	        viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    router.navigate("/");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
	    }
	});

	router.route("/cars/:id", function (id) {
	    if (data.users.currentUser()) {
	        viewsFactory.getSingleCarView()
			.then(function (singleCarViewHtml) {
			    vmFactory.getSingleCarVM(id)
				.then(function (vm) {
				    var view =
						new kendo.View(singleCarViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);
				}, function (err) {
				    console.log(err);
				});
			});
	    }
	    else {
	        router.navigate("/login");
	        viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    router.navigate("/");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
	    }
	});

	//only for registered users
	router.route("/special", function () {
		if (!data.users.currentUser()) {
			router.navigate("/login");
		}
	});

	$(function () {
		appLayout.render("#app");
		router.start();
	});
}());