using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static StringBuilder str = new StringBuilder();
    private static readonly String readFile = @"../../readfrom.txt";
    private static readonly String writeTo = @"../../updated.txt";
    static void Main(string[] args)
    {
        try
        {
            DeletePrefixWords(readFile, writeTo);
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

    private static void DeletePrefixWords(string readFile, string writeTo)
    {
        using (StreamWriter writer = new StreamWriter(writeTo))
        using (StreamReader reader = new StreamReader(readFile))
        {
            while (reader.Peek() >= 0)
            {
                writer.WriteLine(Regex.Replace(reader.ReadLine(),@"\btest\w*" ,""));
            }
        }
    }
}

