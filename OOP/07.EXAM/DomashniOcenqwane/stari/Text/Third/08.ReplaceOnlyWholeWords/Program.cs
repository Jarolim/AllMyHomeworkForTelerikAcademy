using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    private static readonly String readFile = @"../../read.txt";
    private static readonly String writeToFile = @"../../replaced.txt";
    static void Main(string[] args)
    {
        try
        {
            ReplaceWords(readFile, writeToFile);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found, try adding a new file");
        }
        catch (IOException io)
        {
            Console.WriteLine(io.Message);
        }
        catch (OutOfMemoryException ome)
        {
            Console.WriteLine(ome.Message);
        }
        finally { }
    }

    private static void ReplaceWords(string read, string write)
    {
        using (StreamReader input = new StreamReader(read))
        using (StreamWriter output = new StreamWriter(write))
        {
            while (input.Peek() >= 0)
            {
                output.WriteLine(Regex.Replace(input.ReadLine(), @"\bstart\b", "finish")); // http://www.regular-expressions.info/wordboundaries.html for more info
                output.Flush();
            }
        }
    }


}

