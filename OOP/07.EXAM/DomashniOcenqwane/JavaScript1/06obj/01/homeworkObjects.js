
// Write functions for working with shapes in  standard Planar coordinate system
// Points are represented by coordinates P(X, Y)
// Lines are represented by two points, marking their beginning and ending
// L(P1(X1,Y1),P2(X2,Y2))
// Calculate the distance between two points
// Check if three segment lines can form a triangle

// Tank You again vic.alexiev 

function Point(x, y) {
    this.x = x;
    this.y = y;
    this.getDistance = function (p) {
        return Math.sqrt((this.x - p.x) * (this.x - p.x) + (this.y - p.y) * (this.y - p.y));
    };
    this.toString = function () {
        return sprintf("point(%f, %f)", this.x, this.y);
    };
    this.clone = function () {
        return new Point(this.x, this.y);
    }
}

function LineSegment(p1, p2) {
    this.start = p1.clone();
    this.end = p2.clone();
    this.getLength = function () {
        return this.start.getDistance(this.end);
    };
    this.toString = function () {
        return sprintf("line-segment(%s, %s)", this.start, this.end);
    };
}

function canMakeTriangle(ls1, ls2, ls3) {
    var a = ls1.getLength();
    var b = ls2.getLength();
    var c = ls3.getLength();

    return a + b > c && a + c > b && b + c > a;
}

console.log("zad 1 >");
(function () {
    var a = new Point(0, 0);
    var b = new Point(4, 0);
    var c = new Point(0, 3);

    console.log(a);
    console.log(b);
    console.log(c);

    var segmentA = new LineSegment(b, c);
    var segmentB = new LineSegment(a, c);
    var segmentC = new LineSegment(a, b);

    console.log(sprintf("%s, length: %f", segmentA, segmentA.getLength()));
    console.log(sprintf("%s, length: %f", segmentA, segmentA.getLength()));
    console.log(sprintf("%s, length: %f", segmentA, segmentA.getLength()));
    

    console.log("Do these line segments form a triangle? " + canMakeTriangle(segmentA, segmentB, segmentC));
})();
console.log("------------------------------------------------------------------------");

// Write a function that removes all elements with a given value
// var arr = [1,2,1,4,1,3,4,1,111,3,2,1,"1"];
// arr.remove(1); //arr = [2,4,3,4,111,3,2,"1"];

// Attach it to the array class
// Read about prototype and how to attach methods

console.log("zad 2 >");

var elementToRemove = 1;
var elements =  [1,2,1,4,1,3,4,1,111,3,2,1,"1"];

(function () {
    if (!Array.prototype.remove) {
        Array.prototype.remove = function (value) {
            if (this == null) {
                throw new TypeError();
            }

            var result = [];

            var size = this.length;
            for (var i = 0; i < size; i++) {
                if (this[i] !== value) {
                    result.push(this[i]);
                }
            }

            return result;
        }
    }
})();
console.log(elements);
console.log("after call remove");
console.log(elements.remove(elementToRemove)); 
console.log("------------------------------------------------------------------------");

// Write a function that checks if a given object contains a given property
// var obj  = …;
// var hasProp = hasProperty(obj,"length");

console.log("zad 4 >");
(function () {
    var prop = "length";

    var obj = new Array();

    if (hasProperty(obj, prop)) {
        console.log(sprintf("The object has a property '%s'.", prop));
    }
    else {
        console.log(sprintf("The object doesn't have a property '%s'.", prop));
    }
})();

function hasProperty(obj, prop) {
    if (obj.hasOwnProperty(prop)) {
        return true;
    }

    if (prop in obj) {
        return true;
    }

    return false;
}
console.log("------------------------------------------------------------------------");

//  Write a function that finds the youngest person in a given array of persons and prints his/hers full name
// Each person have properties firstname, lastname and age, as shown:
// var persons = [
//  {firstname : "Gosho", lastname: "Petrov", age: 32}, 
//  {firstname : "Bay", lastname: "Ivan", age: 81},…];


console.log("zad 5 >");
function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.toString = function () {
        return sprintf("%s %s (age %d)", this.firstName, this.lastName, this.age);
    }
}

function getYoungestPerson1(people) {
    if (people.length === 0) return null;
    if (people.length === 1) return people[0];

    return people.reduce(function (p, q) {
        return (p.age < q.age ? p : q);
    });
}



(function () {

    var people = [];
    people.push(new Person("Gosho", "Petrov", 38));
    people.push(new Person("Bay", "Ivan", 81));
    people.push(new Person("Chicho", "Tony", 57));
    people.push(new Person("Bate", "Boiko", 36));
    
    var youngestPerson = getYoungestPerson1(people);
    
    console.log(sprintf("The youngest person in the list is %s.", youngestPerson));
})();
console.log("------------------------------------------------------------------------");

// Write a function that groups an array of persons by age, first or last name. The function must return an associative array, with keys - the groups, and values -arrays with persons in this groups
// Use function overloading (i.e. just one function)
// var persons = {…};
// var groupedByFname = group(persons,"firstname");
// var groupedByAge= group(persons,"age");

function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.toString = function () {
        return sprintf("%s %s (age %d)", this.firstName, this.lastName, this.age);
    }
}

function group(people, prop) {
    switch (prop) {
        case "firstName":
        case "lastName":
        case "age":
            {
                var groups = {};

                people.map(function (p) {
                    if (!groups[p[prop]])
                        groups[p[prop]] = new Array();
                    groups[p[prop]].push(p);
                });

                return groups;
            }
        default:
            throw new Error("No such property in Person.");
    }
}
console.log("zad 6>");
(function () {

    var people = [];

    people.push(new Person("Gosho", "Shrek", 38));
    people.push(new Person("Bay", "Ivan", 81));
    people.push(new Person("Chicho", "Tony", 57));
    people.push(new Person("Bate", "Boiko", 36));
    people.push(new Person("Gogo", "Tony", 38));
    people.push(new Person("Java", "Script", 81));
    people.push(new Person("Picho", "Dicho", 57));
    people.push(new Person("Shekspir", "Shrek", 36));

    console.log("group firstName");
    var groups = group(people, "firstName");

    for (var entry in groups) {
        console.log(sprintf("Group '%s': %s", entry, groups[entry]));
    }

    console.log("group age");
    var groups2 = group(people, "age");
    for (var entry in groups2) {
        console.log(sprintf("Group '%s': %s", entry, groups2[entry]));
    }
    

    console.log("group lastName");
    var groups3 = group(people, "lastName");
    for (var entry in groups3) {
        console.log(sprintf("Group '%s': %s", entry, groups3[entry]));
    }
})();

console.log("------------------------------------------------------------------------");