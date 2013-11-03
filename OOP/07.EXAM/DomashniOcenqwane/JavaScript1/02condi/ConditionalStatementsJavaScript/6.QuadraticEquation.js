 
        var x1, x2;
        var a = prompt("Please insert the coefficients a");
        var b = prompt("Please insert the coefficients b");
        var c = prompt("Please insert the coefficients c");
        var d = (b * b) - 4 * (a * c);
        if (a ==0)
        {
            console.log("Requirement not met: 'a' must not be 0");
        }
        else
        {
            if (d == 0)
            {
                console.log("x1 = x2 =:{0:#.##}", -b / (2 * a));
            }
            else
            {
                if (d > 0)
                {
                    x1 = (-b + (Math.sqrt(d)) / (2 * a));
                    x2 = (b + (Math.sqrt(d)) / (2 * a));
                    console.log("The root x1 is: " + x1);
                    console.log("The root x2 is: " + x2);
                }
                else
                {
                    if (d < 0)
                    {
                        console.log("There are no real roots");
                    }
                }
            }
        }

       


    
