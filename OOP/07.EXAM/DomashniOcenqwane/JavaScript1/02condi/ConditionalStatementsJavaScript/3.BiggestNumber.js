	var firstNumber = prompt("Please insert a number:");
        var secondNumber = prompt("Please insert second number:");
        var thirdNumber = prompt("Please insert third number:");
        var biggest = firstNumber;
        if (secondNumber > firstNumber && thirdNumber < secondNumber)
        {
            biggest = secondNumber;
        }
        else if (thirdNumber > firstNumber && secondNumber < thirdNumber)
        {
            biggest = thirdNumber;
        }
        console.log("The biggest number is: "+ biggest);

        