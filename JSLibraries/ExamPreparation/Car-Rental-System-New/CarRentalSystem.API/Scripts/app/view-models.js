/// <reference path="../libs/jquery-2.0.3.min.js" />
/// <reference path="../libs/kendo.web.min.js" />

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

	function getCarsViewModel() {
		return data.cars.all()
			.then(function (cars) {
				var viewModel = {
					cars: cars,
					message: ""
				};
				return kendo.observable(viewModel);
			});
	}

	function getFilteredCarsViewModel(){
	    return data.cars.all()
            .then(function (receivedData) {
                var dataSource =  new kendo.data.DataSource({
                    data: receivedData,
                    filter: {
                        logic: 'and',
                        filters: [
                            { field: 'make', operator: 'neq', value: 'Opel' }
                        ]
                    }
                });

                var sorting = [
                { field: 'make', dir: 'asc' },
                { field: 'model', dir: 'asc' }
                ];

                dataSource.sort(sorting);

                var filteredCars;
                dataSource.fetch(function () {
                    filteredCars = dataSource.view();
                });

                var viewModel = {
                    cars: filteredCars,
                    message: ""
                };

                return kendo.observable(viewModel);
            });
	}

	function getAtPageCarsViewModel(page, count) {
	    return data.cars.all()
            .then(function (receivedData) {
                var dataSource = new kendo.data.DataSource({
                    data: receivedData
                });

                var sorting = [
                    { field: 'make', dir: 'asc' },
                    { field: 'model', dir: 'asc' }
                ];

                dataSource.sort(sorting);

                dataSource.pageSize(count);

                dataSource.fetch(function () {
                    dataSource.page(page);
                    filteredCars = dataSource.view();
                });

                var viewModel = {
                    cars: filteredCars,
                    message: ""
                };

                return kendo.observable(viewModel);
            });
	}

	function getRentedCarsViewModel() {
	    return data.cars.all()
            .then(function (receivedData) {
                var dataSource = new kendo.data.DataSource({
                    data: receivedData,
                    filter: {
                        logic: 'and',
                        filters: [
                            { field: 'state', operator: 'eq', value: 'rented' }
                        ]
                    }
                });
                
                var filteredCars;
                dataSource.fetch(function () {
                    filteredCars = dataSource.view();
                });
                
                var viewModel = {
                    cars: filteredCars,
                    message: ""
                };

                return kendo.observable(viewModel);
            });
	}

	function getSingleCarViewModel(id){
	    return data.cars.all()
            .then(function (receivedData) {
                var dataSource = new kendo.data.DataSource({
                    data: receivedData,
                    filter: {
                        logic: 'and',
                        filters: [
                            { field: 'id', operator: 'eq', value: parseInt(id) }
                        ]
                    }
                });
                var filteredCar;
                dataSource.fetch(function () {
                    filteredCar = dataSource.view();
                });
                
                var viewModel = {
                    car: filteredCar,
                    message: ""
                };

                return kendo.observable(viewModel);
            });
	}

	return {
		getLoginVM: getLoginViewModel,
		getCarsVM: getCarsViewModel,
		getFilteredCarsVM: getFilteredCarsViewModel,
		getAtPageCarsVM: getAtPageCarsViewModel,
		getRentedCarsVM: getRentedCarsViewModel,
        getSingleCarVM: getSingleCarViewModel,
		setPersister: function (persister) {
			data = persister
		}
	};
}());