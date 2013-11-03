var carViewModel = kendo.observable({
    data: carDataSource,
    makes: ["Audi", "BMW", "Mercedes"],
    make: 'Audi',
    model: 'A5',
    year: '2010',
    power: '210',
    agreed: false,
    added: false,
    addCar: function () {
        var self = this;
        this.set('added', true);

        this.data.fetch(function () {
            self.data.data().push(self.generateCarObject());
        });

        var carTemplate = kendo.template($('#car-list-template').html());
        $('#car-list').append(carTemplate(self.generateCarObject()));

        setTimeout(function () {
            self.set('added', false);
        }, 2000);
    },
    generateCarObject: function () {
        return {
            make: this.get("make"),
            model: this.get("model"),
            year: this.get("year"),
            power: this.get("power")
        }
    }
});