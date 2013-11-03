//Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaseWholeWordInFile
{
    static void Main()
    {
        string start = @"\bstart\b";
        string finish = " finish ";

        StreamReader reader = new StreamReader("MyFile.txt");
        using (reader)
        {
            StreamWriter writer = new StreamWriter("Temp.txt");
            using (writer)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = Regex.Replace(line, start, finish);
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }

        File.Replace("Temp.txt", "MyFile.txt", "BackUp.txt");
        File.Delete("BackUp.txt");
    }
}