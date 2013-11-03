//Write a program that compares two text files line by line and prints the number 
//of lines that are the same and the number of lines that are different.
//Assume the files have equal number of lines.

using System;
using System.IO;

class CompareTextFilesLineByLine
{
    static void Main()
    {
        string file1 = @"textFile1.txt";
        string inFile2 = @"textFile2.txt";
        try
        {
            StreamReader stream1 = new StreamReader(file1);
            using (stream1)
            {
                StreamReader stream2 = new StreamReader(inFile2);
                using (stream2)
                {
                    int counterSame =
                        0;
                    int counterDifferent = 0;
                    string line1;
                    string line2;

                    while ((line1 = stream1.ReadLine()) != null && (line2 = stream2.ReadLine()) != null)
                    {
                        if (line1 == line2)
                        {
                            counterSame++;
                        }
                        else
                        {
                            counterDifferent++;
                        }
                    }
                    Console.WriteLine("Same lines number->{0}, diffrent lines number->{1}"
                        , counterSame, counterDifferent);
                }
            }

        }
        catch (FieldAccessException)
        {
            Console.WriteLine("file is locked");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("file is not found");
        }
        catch (FileLoadException)
        {
            Console.WriteLine("can not be load");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Invalid directory in the file path.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine(
                "Can not open the file due to I/O error.");
        }
    }
}
