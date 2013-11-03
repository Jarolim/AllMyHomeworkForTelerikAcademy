using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static List<string> l = new List<string>();
    private static readonly string fileName = @"../../test.txt";
    static void Main(string[] args)
    {
        try
        {
            MakeFileToRead();//Generate a file with all numbers from 0 to 19, after the compilation, the file should have not have odd lines like - 1,3,5,7,9...
            DeleteOddLines();
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

    private static void DeleteOddLines()
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            while (reader.Peek() >= 0)
            {
                l.Add(reader.ReadLine());
            }
        }
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < l.Count; i++)
            {
                if ((i & 1) == 1) continue;
                else writer.WriteLine(l[i]);
            }
        }
    }

    private static void MakeFileToRead()
    {
        using (StreamWriter write = new StreamWriter(fileName))
        {
            for (int i = 0; i < 20; i++)
            {
                write.WriteLine(i);
                write.Flush();
            }
        }
    }
}

