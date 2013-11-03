using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
// avtomatichno sym generiral failovete za chetene, za ydobstvo na proverqvashtiqt, da ne se muchi da vkarva neshta po bezkrai
class Program
{
    private static readonly string makeFile = @"../../readFrom.txt";
    private static readonly string writeToFile = @"../../WriteToFile.txt";
    static void Main(string[] args)
    {
        try
        {
            MakeFileToRead(makeFile, false, null);//suzdavam si testovi fail pulen s malkite latinski bukvi ot azbukata
            MakeFileToRead(writeToFile, true, makeFile); // pechatam v nov fail s nomeraciq. 
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

    private static void MakeFileToRead(String file, Boolean optional, String dest)
    {
        using (StreamWriter write = new StreamWriter(file))
        {
            if (!optional)
            {
                for (int i = 97; i < 123; i++)
                {
                    write.WriteLine((char)(i));
                    write.Flush();
                }
            }
            else
            {
                using (StreamReader reader = new StreamReader(dest))
                {
                    string line;
                    int br = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        write.WriteLine(br + ". " + line);
                        write.Flush();
                        br++;
                    }
                }
            }
        }
    }
}

