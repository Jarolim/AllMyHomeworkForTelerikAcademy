Function.prototype.extend = function(parent) {
	for (var i = 1; i < arguments.length; i += 1) {
		var name = arguments[i];
		this.prototype[name] = parent.prototype[name];
	}
	return this;
}

function PropulsionUnits() {}
PropulsionUnits.prototype.wheel = function(radius) {
	var perimeter = Math.PI * (2 * radius);
	return perimeter;
}

PropulsionUnits.prototype.propellingNozzle = function(power, afterburnerSwitch) {
	var doublePower = 1;
	if (afterburnerSwitch) {
		doublePower = 2;
	} else {
		doublePower = 1;
	}

	return power * doublePower;
}

PropulsionUnits.prototype.propeller = function(fins, spinDirection) {
	if (spinDirection === "clockwise") {
		return fins;
	} else if (spinDirection === "counter-clockwise") {
		return fins * (-1);
	} else {
		console.log("spinDirection is not right !!")
	}
}

function Vehicles(speed, units) {
	this._speed = speed;
	this._units = units;
}
Vehicles.prototype.CalculateAcceleration = function() {
	this._speedAfterAcceleration = this._speed + this._units;
	return this._speedAfterAcceleration;
}

function Air(speed, propellingNozzles, power, afterburnerSwitch) {
	this._speed = speed;
	this._propellingNozzles = propellingNozzles || 1;
	this._power = power;
	this._afterburnerSwitch = afterburnerSwitch;

	this.switchChange = function() {
		if (this._afterburnerSwitch) {
			this._afterburnerSwitch = false;
			this.CallAirParent();
		} else {
			this._afterburnerSwitch = true;
			this.CallAirParent();
		}
	}

	this._afterburnerSwitch = afterburnerSwitch;
	this.CallAirParent();
}

Air.prototype = new Vehicles();
Air.prototype.constructor = Air;
Air.prototype.CallAirParent = function() {
	var unit = new PropulsionUnits().propellingNozzle(this._power, this._afterburnerSwitch);
	Vehicles.call(this, this._speed, unit);
}

function Land(speed, wheels, radius) {
	this._speed = speed;
	this._radius = radius;
	var _wheels = wheels | 4;
	this.callLandParent();
}

Land.prototype = new Vehicles();
Land.prototype.constructor = Land;
Land.prototype.callLandParent = function() {
	var unit = new PropulsionUnits().wheel(this._radius)
	Vehicles.call(this, this._speed, unit);
}

function Water(speed, propellers, fins, spinDirection) {
	var _propellers = propellers;
	this._spinDirection = spinDirection;
	this._fins = fins;
	this._speed = speed;
	this.CallWaterParent();
}

Water.prototype = new Vehicles();
Water.prototype.constructor = Water;
Water.prototype.CallWaterParent = function() {
	var unit = new PropulsionUnits().propeller(this._fins, this._spinDirection);
	Vehicles.call(this, this._speed, unit);
}
Water.prototype.changeDiraction = function() {
	if (this._spinDirection === "clockwise") {
		this._spinDirection = "counter-clockwise";
		this.CallWaterParent();
	} else {
		this._spinDirection = "clockwise";
		this.CallWaterParent();
	}
}

function Amphibious(speed, propellers, fins, spinDirection, wheels, radius) {
	this._spinDirection = spinDirection;
	this._fins = fins;
	this._speed = speed;
	Land.call(this, speed, wheels, radius);
}

Amphibious.prototype = new Land();
Amphibious.prototype.constructor = Amphibious;
Amphibious.extend(Water, "CallWaterParent");
Amphibious.extend(Water, "changeDiraction");


var airCraft = new Air(6, 4, 3, false);
console.log("aircraft acceleration befor switch on = " + airCraft.CalculateAcceleration());
airCraft.switchChange();
console.log("aircraft acceleration after switch on = " + airCraft.CalculateAcceleration());

var car = new Land(1, 4, 5);
console.log("Car speed = " + car._speed);
console.log("Car acceleration = " + car.CalculateAcceleration());

var boat = new Water(1, 2, 3, "clockwise") //"counter-clockwise"
console.log("boat acceleration befor change Diraction = " + boat.CalculateAcceleration());
boat.changeDiraction();
console.log("boat acceleration after change Diraction = " + boat.CalculateAcceleration());

//always starts with land
var anb = new Amphibious(1, 2, 3, "clockwise", 4, 5);
console.log("Acceleration on land = " + anb.CalculateAcceleration());

anb.CallWaterParent();
console.log("Acceleration on water in clockwise = " + anb.CalculateAcceleration());
anb.changeDiraction();
console.log("Acceleration on water in counter-clockwise = " + anb.CalculateAcceleration());
anb._speed = 4;
console.log(anb._speed);
console.log("Acceleration on water with speed = 4 : " + anb.CalculateAcceleration());
anb.callLandParent();
console.log("Acceleration on land with speed = 4 : " + +anb.CalculateAcceleration());