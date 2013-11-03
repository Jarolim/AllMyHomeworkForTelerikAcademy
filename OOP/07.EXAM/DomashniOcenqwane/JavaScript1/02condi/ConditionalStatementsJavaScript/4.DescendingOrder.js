	 var firstNumber = 5.9;
        var secondNumber = 7.2;
        var thirdNumber = 1.1;
        var temp;
        if (secondNumber > firstNumber)
        {
            temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
            if (thirdNumber > secondNumber)
            {
                temp = thirdNumber;
                thirdNumber = secondNumber;
                secondNumber = temp;
            }
            if (secondNumber > firstNumber)
            {
                temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp;
            }
        }
        if (thirdNumber > secondNumber)
        {
            temp = thirdNumber;
            thirdNumber = secondNumber;
            secondNumber = temp;
            if (secondNumber > firstNumber)
            {
                temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp;
            }
        }
        console.log("Given numbers in descending order: "+ firstNumber+" "+ secondNumber+" "+ thirdNumber);
