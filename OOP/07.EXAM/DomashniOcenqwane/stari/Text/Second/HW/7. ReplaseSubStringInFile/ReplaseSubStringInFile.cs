//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file.
//Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;

class ReplaseSubStringInFile
{
    static void Main()
    {
        string start = "start";
        string end = " end ";

        StreamReader reader = new StreamReader("MyFile.txt");
        using (reader)
        {
            StreamWriter writer = new StreamWriter("Temp.txt");
            using (writer)
            {
                string line = reader.ReadLine();
                while (line != null)
                {                    
                    line=line.Replace(start, end);
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }

        File.Replace("Temp.txt", "MyFile.txt", "BackUp.txt");
        File.Delete("BackUp.txt");
    }
}