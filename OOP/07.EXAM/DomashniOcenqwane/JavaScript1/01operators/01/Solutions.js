while (true) {
    var switchChoise = parseInt(prompt("input Nomber of a problem from 1 to 9 or 0 for exit ="));

    switch (switchChoise) {
        case 0: break;
        case 1: {
            alert("Problem 1: Write an expression that checks if given integer is odd or even.");
            var number = parseInt(prompt("input intNomber ="));
            if (number % 2 == 0) {
                alert("the number" + " " + number + " is even");
            }
            else { alert("the number" + " " + number + " is odd"); }
            break;

        }
        case 2:
            alert("Problem 2: Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.");
            var number = parseInt(prompt("input intNomber ="));
            if (number % 21 == 0) { alert("the number" + " " + number + " can be devided by 7 and 3"); }
            else { alert("the number" + " " + number + " can't be devided by 7 and 3"); }
            break;

        case 3:
            alert("Problem 3: Write an expression that calculates rectangle’s area by given width and height.");
            var height = parseInt(prompt("input height ="));
            var width = parseInt(prompt("input width ="));
            alert("Rectangle's area is: " + (height + width));
            break;

        case 4:
            alert("Problem 4: Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.");
            var number = parseInt(prompt("input intNomber ="));
            var numbr = number / 100;
            numbr = parseInt(numbr);
            if (numbr == 0) { alert(number + "->false"); }
            else if ((numbr % 10) == 7) { alert(number + "->true"); }
            else { alert(number + "->false"); }
            break;
        case 5:
            alert("Problem 5: Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.");
            var number = parseInt(prompt("input intNomber ="));

            if ((number & 4) == 4) {
                alert("bit 3 is 1 of " + number + " Binary form: " + number.toString(2));
            }
            else { alert("bit 3 is 0of " + number + " Binary form: " + number.toString(2)); }
            break;

        case 6:
            alert("Problem 6: Write an expression that checks if given print (x,  y) is within a circle K(O, 5).");
            var x = parseInt(prompt("input x coordinate ="));
            var y = parseInt(prompt("input y coordinate ="));

            if ((y * y + x * x) <= 25) {
                alert("point " + x + "," + y + " is within a circle K(O, 5)");
            }
            else { alert("point " + x + "," + y + " is out of a circle K(O, 5)"); }
            break;

        case 7:
            alert("Problem 7: Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.");
            var number = parseInt(prompt("input number ="));

            var res = true;

            for (var i = 2; i <= Math.sqrt(number) ; i++) {
                if ((number % i) == 0) {
                    res = false;
                    break;
                }
            }

            if (res) { alert("number " + number + " is prime"); }
            else { alert("number " + number + " isn't prime"); }
            break;

        case 8:
            alert("Problem 8: Write an expression that calculates trapezoid's area by given sides a and b and height h.");
            var sideA = parseInt(prompt("input side A ="));
            var sideB = parseInt(prompt("input side B ="));
            var h = parseInt(prompt("input h ="));

            alert("trapezoid's area is " + (((sideA + sideB) / 2.0) * h));
            break;

        case 9:
            alert("Problem 9: Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).");
            var x = parseInt(prompt("input side x ="));
            var y = parseInt(prompt("input side y ="));

            var outRectangular = ((x < -1 || x > 5) || (y > 1 || y < -1));

            if (outRectangular) {
                x--;
                y--;
                var inCircle = (9 >= (x * x + y * y));

                if (inCircle) {
                    alert("Point (" + x + "," + y + ") is in circle K((1,1)3 and out of rectangular R(top=1,left=-1,width=6,heigh=2)");
                }
                else {
                    alert("Point (" + x + "," + y + ") isn't in circle K((1,1)3 and out of rectangular R(top=1,left=-1,width=6,heigh=2)");
                }
            }
            else {
                alert("Point (" + x + "," + y + ") isn't in circle K((1,1)3 and out of rectangular R(top=1,left=-1,width=6,heigh=2)");
            }
            break;

        default:
            alert("Not a valid choise");
            break;

    }
    if (switchChoise == 0) {
        break;
    }
}