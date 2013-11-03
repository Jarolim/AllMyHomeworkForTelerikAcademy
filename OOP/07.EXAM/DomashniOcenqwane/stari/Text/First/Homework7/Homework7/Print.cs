using System;
using System.IO;
    class Print
    {
        static void Main()
        {
            string fileName = @"..\..\..\Text files are here\01. PrintOddLines.txt";
            Console.WriteLine("The odd lines of the file {0} are:", fileName);

            StreamReader streamReader = new StreamReader(fileName);

            using (streamReader)
            {
                {
                    int lineNumber = 1;
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (lineNumber % 2 != 0)
                        {
                            Console.WriteLine(line);
                        }
                        lineNumber++;
                        line = streamReader.ReadLine();
                    }
                }
            }
        }
    }

