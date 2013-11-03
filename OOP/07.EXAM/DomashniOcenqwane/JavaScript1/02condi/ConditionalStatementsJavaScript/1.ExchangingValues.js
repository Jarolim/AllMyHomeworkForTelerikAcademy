	var firstNumber = prompt("Please insert a number:");
        var secondNumber = prompt("Please another number:");
        var smallerNumber;
        if (firstNumber < secondNumber)
        {
            console.log("FirstNumber is smaller than the secondNumber");
        }
        else
        {
            smallerNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = smallerNumber;
          console.log("FirstNumber becomes "+firstNumber+ " and second number becomes " +secondNumber+" after exchanging values.");
        }
