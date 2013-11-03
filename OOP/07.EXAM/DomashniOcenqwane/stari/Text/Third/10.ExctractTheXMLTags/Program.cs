using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    private static readonly String readFrom = @"../../readfrom.txt";
    private static readonly String writeTo = @"../../extractedFile.txt";
    static StringBuilder str = new StringBuilder();
    static void Main(string[] args)
    {
        try
        {
            ReadFile(readFrom);
            MatchCollection col = Regex.Matches(str.ToString(), @"(?<=^|>)[^><]+?(?=<|$)");
            WriteToFile(writeTo, col);
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

    private static void WriteToFile(string writeTo, MatchCollection col)
    {
        using (StreamWriter writer = new StreamWriter(writeTo))
        {
            foreach(object s in col){
                writer.WriteLine(s.ToString().Trim());
                writer.Flush();
            }
        }
    }

    private static void ReadFile(string readFrom)
    {
        using (StreamReader reader = new StreamReader(readFrom))
        {
            while (reader.Peek() >= 0)
            {
                str.Append(reader.ReadLine());
            }
        }
    }
}

