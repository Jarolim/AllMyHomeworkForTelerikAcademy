 var firstN = prompt("Please insert first number");
        var secondN = prompt("Please insert second number");
        var thirdN = prompt("Please insert third number");
        var fourthN = prompt("Please insert fourth number");
        var fifthN = prompt("Please insert fifth number");
        var biggest = 0;
        if ((firstN > secondN) && (firstN > thirdN) && (firstN > fourthN) && (firstN > fifthN))
        {
            biggest = firstN;
        }
        else if ((secondN > firstN) && (secondN > thirdN) && (secondN > fourthN) && (secondN > fifthN))
        {
            biggest = secondN;
        }
        else if ((thirdN > firstN) && (thirdN > secondN) && (thirdN > forthN) && (thirdN > fifthN))
        {
            biggest = thirdN;
        }
        else if ((fourthN > firstN) && (fourthN > secondN) && (fourthN > thirdN) && (fourthN > fifthN))
        {
            biggest = forthN;
        }
        else if ((fifthN > firstN) && (fifthN > secondN) && (fifthN > thirdN) && (fifthN > fourthN))
        {
            biggest = fifthN;
        }
        console.log("The biggest number is: "+biggest);

