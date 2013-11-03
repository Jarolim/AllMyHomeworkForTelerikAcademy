//Write a program that concatenates two text files into another text file.
using System;
using System.IO;

class ConcatenateTwoTextFiles
{
    static void Main()
    {

        StreamReader readOne = new StreamReader("textFile1.txt");
        using (readOne)
        {
            StreamReader readTwo = new StreamReader("textFile2.txt");
            using (readTwo)
            {
                StreamWriter write = new StreamWriter("NewTextFile.txt");
                using (write)
                {
                    string content = readOne.ReadToEnd();
                    write.WriteLine(content);
                    content = readTwo.ReadToEnd();
                    write.WriteLine(content);
                }
            }
        }
    }
}