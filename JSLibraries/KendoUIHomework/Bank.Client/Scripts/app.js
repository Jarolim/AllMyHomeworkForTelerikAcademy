/// <reference path="libs/_references.js" />


var application= (function () {
    var appLayout =
		new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("http://localhost:12938/api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();
    router.route("/getaccounts", function () {
        viewsFactory.getAccountsView()
			.then(function (accountsViewHtml) {
			    vmFactory.getAccountsViewModel()
				.then(function (vm) {
				    var view =
						new kendo.View(accountsViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);

				    $("#menu").kendoMenu({
				        animation: { open: { effects: "fadeIn" } },
				        orientation: "vertical"
				    }); 

				}, function (err) {
				    //...
				});
			});
    });

    router.route("/", function () {
        if (data.users.currentUser()) {
            router.navigate("/getaccounts");
        }
        else{
            viewsFactory.getLoginView()
                .then(function (loginViewHtml) {
                    var loginVm = vmFactory.getLoginVM(
                        function () {
                            //not sure what for, was like that "/"
                            router.navigate("/getaccounts");
                        });
                    var view = new kendo.View(loginViewHtml,
                        { model: loginVm });
                    appLayout.showIn("#main-content", view);
                });
        }
    });

    router.route("/login", function () {
        debugger;
        if (data.users.currentUser()) {
            router.navigate("/getaccounts");
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

    router.route("/account-:id", function (id) {
        viewsFactory.getDetailedAccountsView()
          .then(function (accountsDetailedViewHtml) {
              vmFactory.getAccountsDetailedViewModel(id)
              .then(function (vm) {
                  var view =
                      new kendo.View(accountsDetailedViewHtml,
                      { model: vm });
                  appLayout.showIn("#details-" + id, view);
                
                  $("#menu").kendoMenu({
                      animation: { open: { effects: "fadeIn" } },
                      orientation: "vertical"
                  });

              }, function (err) {
                  //...
              });
          });

    });

    router.route("/deposit-:id", function (id) {
        viewsFactory.getDepositMoneyView()
          .then(function (depositMoneyViewHtml) {
              var depositVm = vmFactory.getDepositVM( id,
						function () {
						    alert("You just have deposit some money");
						    router.navigate("/");
						}, function () {
						    alert("You just have deposit some money");
						    router.navigate("/");
						});
              var view = new kendo.View(depositMoneyViewHtml,
						{ model: depositVm });
              appLayout.showIn("#meney-operation", view);
          });

    });

    router.route("/widhraw-:id", function (id) {
        viewsFactory.getWidhrawMoneyView()
          .then(function (withrawMoneyViewHtml) {
              var widthrawVm = vmFactory.getWidhrawVm(id,
						function () {
						    alert("You just have deposit some money");
						    router.navigate("/");
						}, function () {
						    alert("You just have deposit some money");
						    router.navigate("/");
						});
              var view = new kendo.View(withrawMoneyViewHtml,
						{ model: widthrawVm });
              appLayout.showIn("#meney-operation", view);
          });

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

    return {

        router: function () {
            return router;
        }
    }
}());