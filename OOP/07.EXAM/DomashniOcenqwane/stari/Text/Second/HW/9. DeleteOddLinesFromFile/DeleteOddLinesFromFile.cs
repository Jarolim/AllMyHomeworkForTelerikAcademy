//Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.IO;
using System.Text.RegularExpressions;

class DeleteOddLinesFromFile
{
    static void Main()
    {

        StreamReader reader = new StreamReader("MyFile.txt");
        using (reader)
        {
            StreamWriter writer = new StreamWriter("Temp.txt");
            using (writer)
            {
                int counter = 1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if ((counter % 2) == 1)
                    {
                        writer.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    counter++;
                }
            }
        }

        File.Replace("Temp.txt", "MyFile.txt", "BackUp.txt");
        File.Delete("BackUp.txt");
    }
}