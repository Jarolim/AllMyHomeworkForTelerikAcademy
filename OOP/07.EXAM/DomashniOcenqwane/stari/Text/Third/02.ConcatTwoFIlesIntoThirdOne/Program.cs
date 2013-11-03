using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
// avtomatichno sym generiral failovete za chetene, za ydobstvo na proverqvashtiqt, da ne se muchi da vkarva neshta po bezkrai
class Program
{
    private static readonly string firstFile = @"../../first.txt";
    private static readonly string secondFile = @"../../second.txt";
    private static readonly string finalFile = @"../../input.txt";
    static StringBuilder final = new StringBuilder();
    static void Main(string[] args)
    {
        try
        {
            MakeFileToRead(firstFile, false);
            MakeFileToRead(secondFile, false);
            ReadFromFile(firstFile);
            ReadFromFile(secondFile);
            MakeFileToRead(finalFile, true);
            final.Clear();
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
    private static void ReadFromFile(string file)
    {
        using (StreamReader input = new StreamReader(file))
        {
            string line;
            while ((line = input.ReadLine()) != null)
            {
                final.AppendLine(line);
            }
        }
    }
    private static void MakeFileToRead(String file,Boolean option)
    {
        using (StreamWriter write = new StreamWriter(file))
        {
            if (!option)
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        write.Write(j);
                    }
                    write.WriteLine(i);
                    write.Flush();
                }
            }
            else
            {
                for (int i = 0; i < final.Length; i++)
                {
                    if (final[i] == '\n') { write.WriteLine(); }
                    else write.Write(final[i]);
                    write.Flush();
                }
            }
        }
    }
}

