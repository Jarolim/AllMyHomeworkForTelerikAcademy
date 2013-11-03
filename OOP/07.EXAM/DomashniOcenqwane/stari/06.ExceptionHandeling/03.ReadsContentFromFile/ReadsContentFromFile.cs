using System;

    class ReadsContentFromFile
    {
        static void Main()
        {
            Console.Write("Enter file name:");
            try
            {
                Console.WriteLine(System.IO.File.ReadAllText(Console.ReadLine()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception cought!\n{0}:{1}", e.GetType().Name, e.Message);
            }
        }
    }

