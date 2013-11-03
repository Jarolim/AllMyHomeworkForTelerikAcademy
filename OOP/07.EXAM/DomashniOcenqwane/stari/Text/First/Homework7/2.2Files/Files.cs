using System;
using System.IO;
    class Files
    {
        static void Main()
        {
            StreamReader firstFile = new StreamReader(@"..\..\..\Text files are here\02. First Source.txt");
            using (firstFile)
            {
                StreamReader secondFile = new StreamReader(@"..\..\..\Text files are here\02. Second Source.txt");
                using (secondFile)
                {
                    StreamWriter outputFile = new StreamWriter(@"..\..\..\Text files are here\02. Combined.txt");
                    using (outputFile)
                    {
                        string line = firstFile.ReadLine();
                        while (line != null)
                        {
                            outputFile.WriteLine(line);
                            line = firstFile.ReadLine();
                        }

                        line = secondFile.ReadLine();
                        while (line != null)
                        {
                            outputFile.WriteLine(line);
                            line = secondFile.ReadLine();
                        }
                    }
                }
            }
        }
    }

