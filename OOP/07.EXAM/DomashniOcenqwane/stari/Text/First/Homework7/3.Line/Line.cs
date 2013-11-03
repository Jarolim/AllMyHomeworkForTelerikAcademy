using System;
using System.IO;

    class Line
    {
        static void Main()
        {
            string linesInput = @"..\..\..\Text files are here\03. Lines Input.txt";
            StreamReader text = new StreamReader(linesInput);
            StreamWriter output = new StreamWriter(@"..\..\..\Text files are here\03. Output.txt");

            using (text)
            {
                using (output)
                {
                    int lineNumber = 0;
                    string line = text.ReadLine();
                    while (line != null)
                    {
                        lineNumber++;
                        Console.WriteLine("Line {0}: {1}", lineNumber, line);
                        line = text.ReadLine();
                        output.WriteLine("{0} {1}", lineNumber, line);
                    }
                }
            }
            Console.WriteLine("Your file is ready. Its name is 03. Output and it's in the upper dirrectory");
        }
    }
