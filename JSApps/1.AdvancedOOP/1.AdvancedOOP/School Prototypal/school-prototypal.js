if (!Object.create) {
  Object.create = function(obj) {
    function f() {};
    f.prototype = obj;
    return new f();
  }
}

if (!Object.prototype.extend) {
	Object.prototype.extend = function(properties) {
		function f() {};
		f.prototype = Object.create(this);
		for(var prop in properties) {
			f.prototype[prop] = properties[prop];
		}
		f.prototype._super = this;
		return new f();
	}
}

var School = {
	init: function(sname, town, sclasses) {
		this.sname = sname;
		this.town = town;
		this.sclasses = sclasses;
	}
};

var Course = {
	init: function(cname, capacity, students, formTeacher) {
		this.cname = cname;
		this.capacity = capacity;
		this.students = students;
		this.formTeacher = formTeacher;
	}
};

var Person = {
	init: function(fname, lname, age) {
		this.fname = fname;
		this.lname = lname;
		this.age = age;
	},
	introduce: function() {
		return "Name: " + this.fname + " " + this.lname + ", Age: " + this.age;
	}
};

var Student = Person.extend ({
	init: function(fname, lname, age, grade) {
		this._super = Object.create(this._super);
		this._super.init(fname, lname, age);
		this.grade = grade;
	},
	introduce: function() {
		var intro = this._super.introduce() + ", grade: " + this.grade;
		return  intro;
	}
});

var Teacher = Person.extend ({
	init: function(fname, lname, age, specialty) {
		this._super = Object.create(this._super);
		this._super.init(fname, lname, age);
		this.specialty = specialty;
	},
	introduce: function() {
		var intro = this._super.introduce() + ", specialty: " + this.specialty;
		return intro;
	}
});

var sam = Object.create(Person);
sam.init("Samuel", "Jackson", 10);
var gogo = Object.create(Student);
gogo.init("Gogo", "Gogov", 10, 3);
var levent = Object.create(Student);
levent.init("Levent", "Mihajlovski", 8, 2);
var slavi = Object.create(Student);
slavi.init("Slavi", "Trifonov", 7, 1);

var mamar = Object.create(Teacher);
mamar.init("Mamar", "Mumun", 100, "Biology");

var biologyCourse = Object.create(Course);
biologyCourse.init("Biology", 20, new Array(sam, gogo, levent), mamar);

console.log(sam.introduce());
console.log(sam.introduce());
console.log(gogo.introduce());
console.log(levent.introduce());

console.log(mamar.introduce());

console.log(biologyCourse);