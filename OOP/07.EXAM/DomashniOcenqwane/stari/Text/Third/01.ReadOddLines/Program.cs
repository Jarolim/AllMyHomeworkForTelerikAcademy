using System;
using System.Linq;
using System.IO;
// avtomatichno sym generiral failovete za chetene, za ydobstvo na proverqvashtiqt, da ne se muchi da vkarva neshta po bezkrai
class Program
{
    private static readonly string fileName = @"../../test.txt";
    static void Main(string[] args)
    {
        try
        {
            MakeFileToRead();
            ReadOddLines();
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

    private static void ReadOddLines()
    {
        using (StreamReader input = new StreamReader(fileName))
        {
            int br = 0;
            string line;
            while ((line = input.ReadLine()) != null)
            {
                if ((br & 1) == 1) Console.WriteLine(line);
                br++;
          
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

