using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
// avtomatichno sym generiral failovete za chetene, za ydobstvo na proverqvashtiqt, da ne se muchi da vkarva neshta do bezkrai
class Program
{
    static Random rnd = new Random();
    static int counter = 0;
    static int alllinescounter = 0;
    private static readonly String firstFileName = @"../../firstfile.txt";
    private static readonly String secondFileName = @"../../secondfile.txt";
    static void Main(string[] args)
    {
        try
        {
            MakeAlmostIndenticalTxTFiles(firstFileName);
            MakeAlmostIndenticalTxTFiles(secondFileName);
            ComparesEachLine(firstFileName, secondFileName);
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
        finally { Console.WriteLine("Equals {0}, lines that are not equal {1} ", counter, alllinescounter - counter); }
        
    }

    private static void ComparesEachLine(string first, string second)
    {
        using(StreamReader readerOne = new StreamReader(first))
        using (StreamReader readerTwo = new StreamReader(second))
        {
            string firstl,secondl;
            while ((firstl = readerOne.ReadLine()) != null && (secondl = readerTwo.ReadLine()) != null)
            {
                if (firstl==secondl) counter++;
                alllinescounter++;
            }
        }
    }

    private static void MakeAlmostIndenticalTxTFiles(string first)
    {
        using (StreamWriter writer = new StreamWriter(first))
        {
            for (int i = 0; i < 20; i++)
            {
                if (i % 3 == 0) writer.WriteLine(i);
                else writer.WriteLine(rnd.Next(20, 100));
                writer.Flush();
            }
        }
    }
}

