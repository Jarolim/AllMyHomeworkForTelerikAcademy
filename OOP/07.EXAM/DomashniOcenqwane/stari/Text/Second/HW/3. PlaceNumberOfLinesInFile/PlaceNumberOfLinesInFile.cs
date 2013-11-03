//Write a program that reads a text file and inserts line numbers in front of each of its lines.
//The result should be written to another text file.

using System;
using System.IO;

class PlaceNumberOfLinesInFile
{
    static void Main()
    {
        string file = @"..\..\PlaceNumberOfLinesInFile.cs";
        Console.WriteLine("The contents of the file {0} is:", file);

        StreamReader streamReader = new StreamReader(file);

        using (streamReader)
        {
            string fileContents = streamReader.ReadToEnd();
            Console.WriteLine(fileContents);
        }

        StreamReader reader = new StreamReader(file);
        using (reader)
        {
            StreamWriter writer = new StreamWriter("MyFile.txt");
            using (writer)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    writer.WriteLine("Line {0}: {1}", lineNumber, line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}