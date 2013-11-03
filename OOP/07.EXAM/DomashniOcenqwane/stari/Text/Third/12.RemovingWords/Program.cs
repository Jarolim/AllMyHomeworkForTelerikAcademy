using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
class Program
{
    private static readonly String textFile = @"../../text.txt";
    private static readonly String wordsToDelete = @"../../words.txt";
    private static readonly String edited = @"../../final.txt";

    static void Main(string[] args)
    {
        try
        {
            DeleteWords(textFile, wordsToDelete);
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

    private static void DeleteWords(string textFile, string wordsToDelete)
    {
        string regex = @"\b(" + String.Join("|", File.ReadAllLines(wordsToDelete))+@")\b";
        using (StreamReader reader = new StreamReader(textFile))
        using (StreamWriter writer = new StreamWriter(edited))
        {
            while (reader.Peek() >= 0)
            {
                writer.WriteLine(Regex.Replace(reader.ReadLine(),regex,string.Empty));
            }
        }
    }
}

