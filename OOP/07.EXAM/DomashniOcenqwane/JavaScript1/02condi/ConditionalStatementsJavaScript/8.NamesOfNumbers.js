   var NumName = function (num)
{
        var numbers = "";
        switch (num)
        {
            case 1: numbers = "one";
                break;
            case 2: numbers = "two";
                break;
            case 3: numbers = "three";
                break;
            case 4: numbers = "four";
                break;
            case 5: numbers = "five";
                break;
            case 6: numbers = "six";
                break;
            case 7: numbers = "seven";
                break;
            case 8: numbers = "eight";
                break;
            case 9: numbers = "nine";
                break;
            case 10: numbers = "ten";
                break;
            case 11: numbers = "eleven";
                break;
            case 12: numbers = "twelve"; 
                break;
            case 13: numbers = "thirteen";
                break;
            case 14: numbers = "fourteen";
                break;
            case 15: numbers = "fifteen";
                break;
            case 16: numbers = "sixteen";
                break;
            case 17: numbers = "seventeen";
                break;
            case 18: numbers = "eighteen";
                break;
            case 19: numbers = "nineteen";
                break;
            case 20: numbers = "twenty";
                break;
            case 30: numbers = "thirty";
                break;
            case 40: numbers = "fourty";
                break;
            case 50: numbers = "fifty";
                break;
            case 60: numbers = "sixty";
                break;
            case 70: numbers = "seventy";
                break;
            case 80: numbers = "eighty";
                break;
            case 90: numbers = "ninety";
                break;
        }
        return numbers;
};
        var num = prompt("Please, insert a number");
        var nameString;
        if (num >= 0 && num <= 999)
        {
            nameString = NumName(num / 100);
            if (num / 10 >= 10)
            {
                nameString += " hundred";
            }
            if ((num % 10 == 0 && num % 100 != 0 && num % 10 != 0) || (num % 100 < 20 && num % 100 != 0))
            {
                if (num > 20)
                {
                    nameString += " and ";
                }
                nameString += NumName(num % 100);
            }
            else
            {
                nameString += " " + NumName((num % 100) - (num % 10)) + " " + NumName(num % 10);
            }
            if (num == 0)
            {
                nameString = "Zero";
            }
          
            console.log("Text representation: "+ nameString);
        }
        else
        {
            console.log("Wrong input!");
        }