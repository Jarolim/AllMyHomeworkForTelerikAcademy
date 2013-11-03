Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
}

//PropulsionUnit Hierarchy
function PropulsionUnit(acceleration) {
    this.acceleration = acceleration;
}

function Wheel(radius) {
    var accelertionProduced = 2 * Math.PI * radius;
    PropulsionUnit.apply(this, accelertionProduced);
    this.radius = radius;
}
Wheel.inherit(PropulsionUnit);

function PropellingNozzle(power, afterBurnerSwitch) {
    this.power = power;
    this.afterBurnerSwitch = afterBurnerSwitch;
    var accelertionProduced = afterBurnerSwitch ? power * 2 : power;
    PropulsionUnit.apply(this, accelertionProduced);
}
PropellingNozzle.inherit(PropulsionUnit);

function Propeller(finsCount, spinDirection) {
    this.finsCount = finsCount;
    this.spinDirection = spinDirection;
    var accelerationProduced;

    if (spinDirection == "clockwise") {
        accelerationProduced = finsCount;
    }
    else if("counter-clockwise"){
        accelerationProduced = -finsCount;
    }

    PropulsionUnit.apply(this, accelerationProduced);
}
Propeller.inherit(PropulsionUnit);

//Vehicle Hierarchy
function Vehicle(speed, propulsionUnits) {
    this.speed = speed;
    this.propulsionUnits = propulsionUnits;
    this.Accelerate = function () {
        var sumOfAccelerationsByPropUnits = 0;
        var i;
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            sumOfAccelerationsByPropUnits += this.propulsionUnits[i].accelerations;
        }

        this.speed = this.speed + sumOfAccelerationsByPropUnits;
    }
}

function LandVehicle(speed) {
    var wheels = [new Wheel(15), new Wheel(15), new Wheel(15), new Wheel(15)];
    Vehicle.call(this, speed, wheels);
}
LandVehicle.inherit(Vehicle);

function AirVehicle(speed) {
    var propellingNozle = new PropellingNozle(200, false);
    Vehicle.call(this, speed, propellingNozle);
    this.SwitchAfterBurnerOnOrOff = function () {
        this.propulsionUnits.afterBurnerSwitch ?
        this.propulsionUnits.afterBurnerSwitch = false : this.propulsionUnits.afterBurnerSwitch = false;
    }
}
AirVehicle.inherit(Vehicle);

function WaterVehicle(speed, finsCount) {
    var propellers = new Propeller(finsCount, "clockwise");
    Vehicle.call(this, speed, propellers);
    this.ChangeSpin = function () {
        if (this.propulsionUnits.spinDirection == "clockwise") {
            this.propulsionUnits.spinDirection = "counter-clockwise";
        }
        else {
            this.propulsionUnits.spinDirection = "clockwise";
        }
    }
}
WaterVehicle.inherit(Vehicle);

function AmphibiousVehicle(speed, finsCount) {
    this.landMode = new LandVehicle(speed);
    this.waterMode = new WaterVehicle(speed, finsCount);
    var mode = "land";

    this.switchMode = function () {
        if (mode == "land") {
            mode = "water";
        }
        else {
            mode = "land";
        }
    }
}