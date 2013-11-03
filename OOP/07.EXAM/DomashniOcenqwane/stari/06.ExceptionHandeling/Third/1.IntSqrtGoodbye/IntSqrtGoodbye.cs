using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class IntSqrtGoodbye
{
    static void Main()
    {
        try
        {
            Console.Write("Enter integer: ");
            int number = int.Parse(Console.ReadLine());


            double sqroot = Math.Sqrt(number);
            Console.WriteLine(sqroot);

            if (number < 0) throw new Exception();

        }
        catch(FormatException fe)
        {
            Console.WriteLine("Invalid number!");
        }
        catch (OverflowException ofe)
        {
            Console.WriteLine("Invalid number!");
        }
        
        finally
        {
            Console.WriteLine("Good Bye!");
        }
    }
}

