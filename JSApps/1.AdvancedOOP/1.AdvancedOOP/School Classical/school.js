Function.prototype.inherit = function(parent) {
	var oldPrototype = this.prototype; // Student
	var prototype = new parent(); // Person 
	this.prototype._superConstructor = parent; // The base constructor ~ Person
	for(var prop in oldPrototype) // All new properties from Student
		this.prototype[prop] = oldPrototype[prop]; // added to all properties from Person

};

var Class = (function() {
	function createClass(properties) {
		var f = function() {
			if(this._superConstructor) {
				this._super = new this._superConstructor(arguments);
			}

			this.init.apply(this, arguments);
		}

		for(var prop in properties) {
			f.prototype[prop] = properties[prop];
		}
		if(!f.prototype.init) {
			f.prototype.init = function() {}
		}
		return f;
	}

	return {
		create: createClass
	};
}());

var School = Class.create({
	init: function(name, town, sclasses) {
		this.sname = name;
		this.town = town;
		this.sclasses = sclasses;
	},
	toString: function() {
		var classesString = '';
		for(var i = 0; i < this.sclasses.length; i++) {
			classesString += this.sclasses[i].getName() + " ";
		}
		return "Name: " + this.sname + ", town: " + this.town + ", courses: " + classesString;
	}
});

var Person = Class.create({
	init: function(fname, lname, age) {
		this.Name = fname + " " + lname;
		this.Age = age;
	},
	introduce: function() {
		var info = '';
		for(var prop in this) {
			if(this[prop] instanceof Function) {
				continue;
			}
			info += prop + ": " + this[prop] + " ";
		}
		return info;
	}
});

var Student = Class.create({
	init: function(fname, lname, age, grade) {
		this._super.init(fname, lname, age);
		this.grade = grade;
	},
	introduce: function() {
		var info = this._super.introduce();
		for(var prop in this) {
			if(this[prop] instanceof Function || prop == "_super") {
				continue;
			}
			info += prop + ": " + this[prop] + " ";
		}
		return info;
	}
});

var Teacher = Class.create({
	init: function(fname, lname, age, specialty) {
		this._super.init(fname, lname, age);
		this.specialty = specialty;
	},
	introduce: function() {
		var info = this._super.introduce();
		for(var prop in this) {
			if(this[prop] instanceof Function || prop == "_super") {
				continue;
			}
			info += prop + ": " + this[prop] + " ";
		}
		return info;
	}
});

Student.inherit(Person);
Teacher.inherit(Person);

var Course = Class.create({
	init: function(cname, capacity, students, formteacher) {
		this.cname = cname;
		this.capacity = capacity;
		this.students = students;
		this.formteacher = formteacher;
	}, 
	getName: function() {	
		return this.cname;
	}
});



// test demo
var sam = new Student("Samuel", "Jackson", 5, 1);
var pepi = new Student("Petar", "Petrov", 6, 3);
var jeleva = new Teacher("Damqna", "Jeleva", 40, "Math");

var mathCourse = new Course("Math", 10, new Array(sam, pepi), jeleva);
var sou132 = new School("132 SOU", "Sofia", new Array(mathCourse));
console.log(sam.introduce());
console.log(pepi.introduce());
console.log(jeleva.introduce());
console.log(sou132.toString());