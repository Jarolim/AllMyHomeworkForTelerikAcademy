using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
// avtomatichno sym generiral failovete za chetene, za ydobstvo na proverqvashtiqt, da ne se muchi da vkarva neshta do bezkrai
class Program
{
    static Random rnd = new Random();
    static StringBuilder str = new StringBuilder();
    static List<String> array = new List<string>();
    private static readonly String readFile = @"../../readfrom.txt";
    private static readonly String writeToFile = @"../../writetofile.txt";
    private static readonly char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    static void Main(string[] args)
    {
        try
        {
            GenUnsortedFile(readFile);// generiram nesortiran fail -- izvun nujdite na yslovieto, kato bonus ideq
            ReadUnsortedFile(readFile, writeToFile);
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

    private static void ReadUnsortedFile(string read, string write)
    {
        using (StreamReader reader = new StreamReader(read))
        {
            while (reader.Peek()>=0)
            {
                array.Add(reader.ReadLine());
            }
        }
        array.Sort();
        using (StreamWriter writer = new StreamWriter(write))
        {
            for (int i = 0; i < array.Count; i++)
            {
                writer.WriteLine(array[i]);
            }
        }
    }

    private static void GenUnsortedFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            int linesSize = rnd.Next(10, 20);
            for (int i = 0; i < linesSize; i++)
            {
                int length = rnd.Next(2,15);
                for (int j = 0; j < length; j++)
                {
                    str.Append(alphabet[rnd.Next(0, 26)]);
                }
                writer.WriteLine(str.ToString());
                str.Clear();
                writer.Flush();
            }
        }
    }
}

