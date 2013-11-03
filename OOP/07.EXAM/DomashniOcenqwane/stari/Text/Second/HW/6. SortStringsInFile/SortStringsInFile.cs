//Write a program that reads a text file containing a list of strings,
//sorts them and saves them to another text file. 

using System;
using System.Collections.Generic;
using System.IO;

class SortStringsInFile
{
    static void Main()
    {
        List<string> fileContent = new List<string>();
        StreamReader reader = new StreamReader("FileToSort.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {

                fileContent.Add(line);
                line = reader.ReadLine();
            }
        }
        fileContent.Sort();

        StreamWriter writer = new StreamWriter("SortedFile.txt");
        using (writer)
        {
            foreach (var item in fileContent)
            {
                writer.WriteLine(item);
            }
        }
    }
}