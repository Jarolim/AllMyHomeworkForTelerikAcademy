using System;
class CatchingException
{
    static void Main()
    {
        try
        {
            Console.Write("please enter number: ");
            ushort number = ushort.Parse(Console.ReadLine());
            Console.WriteLine("square root of {0}, is: {1}",number,Math.Sqrt(number));
        }
        catch (OverflowException)
        {
            Console.WriteLine("invalid number");
        }
        catch (FormatException)
        {
            Console.WriteLine("invalid number");
        }
        finally
        {
            Console.WriteLine("good bye");
        }
        Console.ReadLine();
    }
}

