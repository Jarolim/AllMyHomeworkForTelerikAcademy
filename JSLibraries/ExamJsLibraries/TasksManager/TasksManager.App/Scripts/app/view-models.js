/// <reference path="../libs/jquery-2.0.3.min.js" />
/// <reference path="../libs/kendo.web.min.js" />

window.vmFactory = (function () {
	var data = null;

	function getLoginViewModel(successCallback) {		
		var viewModel = {
		    username: "DonchoMinkov",
		    email: "doncho.minkov@telerik.com",
			password: "123456q",
			login: function () {
			    data.users.login(this.get("username"), this.get("email"), this.get("password"))
					.then(function () {
						if (successCallback) {
							successCallback();
						}
					});
			},
			register: function () {
			    data.users.register(this.get("username"), this.get("email"), this.get("password"))
					.then(function () {
						if (successCallback) {
							successCallback();
						}
					});
			}
		};
		return kendo.observable(viewModel);
	};

	function getAppointmentsViewModel() {
		return data.appointments.all()
			.then(function (appointments) {
				var viewModel = {
				    appointments: appointments,
					message: ""
				};
				return kendo.observable(viewModel);
			});
	}

	function getListsViewModel() {
	    //debugger;
		return data.lists.all()
			.then(function (lists) {
				var viewModel = {
				    lists: lists,
					message: ""
				};
				return kendo.observable(viewModel);
			});
	}

    function getCurrentAppointmentsViewModel() {
        return data.appointments.all()
            .then(function (receivedData) {
                var dataSource = new kendo.data.DataSource({
                    data: receivedData,
                    filter: {
                        logic: 'and',
                        filters: [
                            { field: 'value', operator: 'eq', value: 'current' }
                        ]
                    }
                });

                var filteredAppointments;
                dataSource.fetch(function () {
                    filteredAppointments = dataSource.view();
                });

                var viewModel = {
                    appointments: filteredAppointments,
                    message: ""
                };

                return kendo.observable(viewModel);
            });
    }

    function getUpcommingAppointmentsViewModel() {
        return data.appointments.all()
            .then(function (receivedData) {
                var dataSource = new kendo.data.DataSource({
                    data: receivedData,
                    filter: {
                        logic: 'and',
                        filters: [
                            { field: 'value', operator: 'eq', value: 'upcomming' }
                        ]
                    }
                });

                var filteredAppointments;
                dataSource.fetch(function () {
                    filteredAppointments = dataSource.view();
                });

                var viewModel = {
                    appointments: filteredAppointments,
                    message: ""
                };

                return kendo.observable(viewModel);
            });
    }

    function getFinishedAppointmentsViewModel() {
        return data.appointments.all()
            .then(function (receivedData) {
                var dataSource = new kendo.data.DataSource({
                    data: receivedData,
                    filter: {
                        logic: 'and',
                        filters: [
                            { field: 'value', operator: 'eq', value: 'finished' }
                        ]
                    }
                });

                var filteredAppointments;
                dataSource.fetch(function () {
                    filteredAppointments = dataSource.view();
                });

                var viewModel = {
                    appointments: filteredAppointments,
                    message: ""
                };

                return kendo.observable(viewModel);
            });
    }

	return {
		getLoginVM: getLoginViewModel,
		getAppointmentsVM: getAppointmentsViewModel,
		getListsVM: getListsViewModel,
		getFinishedAppointmentsViewModel: getFinishedAppointmentsViewModel,
		getUpcommingAppointmentsViewModel: getUpcommingAppointmentsViewModel,
		getCurrentAppointmentsViewModel: getCurrentAppointmentsViewModel,
		setPersister: function (persister) {
			data = persister
		}
	};
}());