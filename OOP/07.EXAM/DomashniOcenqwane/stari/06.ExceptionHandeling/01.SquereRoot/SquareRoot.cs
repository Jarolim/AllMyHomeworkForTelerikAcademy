using System;


    class SquareRoot
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter a number:");
                uint n = uint.Parse(Console.ReadLine());

                Console.WriteLine(Math.Sqrt(n));
            }

            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("Invalid number");
            }

            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid number");
            }

            catch (OverflowException)
            {
                Console.Error.WriteLine("Invalid number");
            }

            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
