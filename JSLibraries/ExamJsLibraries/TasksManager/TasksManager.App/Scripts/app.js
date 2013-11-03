/// <reference path="libs/kendo.web.min.js" />
/// <reference path="libs/_references.js" />


(function () {
    var appLayout =
		new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();

    //NOTE: would now show ... donno why ... but gives responce 200 and shows the content in the console (mozzila).
    router.route("/appointments/all", function () { 
        viewsFactory.getAppointmentsView()
			.then(function (appointmentsViewHtml) {
			    vmFactory.getAppointmentsVM()
				.then(function (vm) {
				    var view =
						new kendo.View(appointmentsViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);
				}, function (err) {
				    console.log(err);
				});
			});
    });

    //router.route("/todo-lists", function () {
    //    viewsFactory.getListsView()
    //		.then(function (listsViewHtml) {
    //		    vmFactory.getListsVM()
    //			.then(function (vm) {
    //			    var view =
    //					new kendo.View(listsViewHtml,
    //					{ model: vm });
    //			    appLayout.showIn("#main-content", view);
    //			}, function (err) {
    //			    console.log(err);
    //			});
    //		});
    //});

    //NOTE: would now show ... donno why ... but gives responce 200 and shows the content in the console (mozzila).
    router.route("/todo-lists", function () {
        viewsFactory.getListsView()
            .then(function (listsViewHtml) {
                var listsVm = vmFactory.getListsVM(
                    function () {
                        router.navigate("/");
                    });
                var view = new kendo.View(listsViewHtml,
                    { model: listsVm });
                appLayout.showIn("#main-content", view);
            });
    });


    router.route("/home", function () {
        $('#main-content').append('In home<br/>');
        viewsFactory.getAppointmentsView()
			.then(function (appointmentsViewHtml) {
			    vmFactory.getAppointmentsVM()
				.then(function (vm) {
				    var view =
						new kendo.View(appointmentsViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);
				}, function (err) {
				    console.log(err);
				});
			});
    });

    router.route("/auth/token", function () {
        $('#main-content').append('In login<br/>');
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

    router.route('/appointments', function () {
        $('#main-content').append('In create appointments<br/>');
    });

    router.route('/appointments/comming', function () {
        $('#main-content').append('In comming appointments<br/>');
    });

    router.route('/appointments/today', function () {
        $('#main-content').append('In today appointments<br/>');
    });

    router.route('/appointments/current', function () {
        $('#main-content').append('In current appointments<br/>');
    });

    router.route('/todo-lists/:id', function (id) {
        $('#main-content').append('In todo lists by' + id +'<br/>');
    });

    router.route('/todo-lists/:id/todos', function () {
        $('#main-content').append('In todo lists by id with todos<br/>');
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