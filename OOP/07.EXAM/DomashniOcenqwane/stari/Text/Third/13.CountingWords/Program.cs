using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class Program
{
    static char[] delim = { ' ', '.' ,','  };
    private static readonly String textFile = @"../../text.txt";
    private static readonly String outFile = @"../../out.txt";
    static Dictionary<String, int> dict = new Dictionary<string, int>();
    static void Main(string[] args)
    {
        try
        {
            CountWords(textFile);
            WriteToFile(outFile);
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

    private static void WriteToFile(string outFile)
    {
        using (StreamWriter writer = new StreamWriter(outFile))
        {
            var sorted = dict.OrderBy(x => -x.Value);
            foreach (var i in sorted)
            {
                writer.WriteLine(i);
                writer.Flush();
            }
        }
    }

    private static void CountWords(string textFile)
    {
        using (StreamReader reader = new StreamReader(textFile))
        {
            while (reader.Peek() >= 0)
            {
                string[] split = reader.ReadLine().Split(delim, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < split.Length; i++)
                {
                    if (dict.ContainsKey(split[i])) dict[split[i]]++;
                    else dict.Add(split[i], 1);
                }
            }
        }
    }
}

