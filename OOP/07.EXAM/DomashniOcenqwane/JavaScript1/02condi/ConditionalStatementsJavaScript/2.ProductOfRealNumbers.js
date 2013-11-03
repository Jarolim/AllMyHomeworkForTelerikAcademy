          var firstNumber = prompt("Please, insert first number");
        var secondNumber = prompt("Please, insert second number");
        var thirdNumber = prompt("Please, insert third number");
        var count = 0;
       if(firstNumber == 0 || secondNumber ==0|| thirdNumber == 0)
        {
            console.log("The product of the numbers will be 0");
        }
        else
        {
            if (firstNumber < 0)
              {
            count++;
              }
        if (secondNumber < 0)
        {
            count++;
        }
        if (thirdNumber < 0)
        {
            count++;
        }
        if (count === 1 || count === 3)
        {
            console.log("The product of the numbers will be negative number");
        }
        else
        {
            console.log("The product of the numbers will be positive number");
        }
        }
        