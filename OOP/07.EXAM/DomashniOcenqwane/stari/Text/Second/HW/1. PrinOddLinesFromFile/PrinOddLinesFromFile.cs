//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class PrinOddLinesFromFile
{
    static void Main()
    {
        string file = @"textFile.txt";
        try
        {
            StreamReader streamReader = new StreamReader(file);
            using (streamReader)
            {
                int counter =
                    1;
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (counter % 2 == 1)
                        Console.WriteLine(line);

                    counter++;
                }
            }
        }
        catch (FieldAccessException)
        {

            Console.WriteLine("{0} file is locked", file);
        }
        catch (FileNotFoundException)
        {

            Console.WriteLine("{0} file is not found", file);
        }
        catch (FileLoadException)
        {

            Console.WriteLine("{0} can not be load", file);
        }
        catch (Exception fe)
        {
            Console.WriteLine(fe.Message);
        }
    }
}