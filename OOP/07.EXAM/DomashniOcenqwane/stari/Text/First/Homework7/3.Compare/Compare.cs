using System;
using System.IO;
    class Compare
    {
        static void Main(string[] args)
        {
            string firstFile = @"..\..\..\Text files are here\04. First File.txt";
            StreamReader firstReader = new StreamReader(firstFile);
            string secondFile = @"..\..\..\Text files are here\04. Second File.txt";
            StreamReader secondReader = new StreamReader(secondFile);
            using (firstReader)
            {
                using (secondReader)
                {
                    int equal = 0;
                    int nonEqual = 0;
                    string line1 = firstReader.ReadLine();
                    string line2 = secondReader.ReadLine();
                    while (line1 != null && line2 != null)
                    {
                        if (line1 == line2)
                        {
                            equal++;
                        }

                        else
                        {
                            nonEqual++;
                        }

                        line1 = firstReader.ReadLine();
                        line2 = secondReader.ReadLine();
                    }
                    Console.WriteLine("Equal lines: {0}", equal);
                    Console.WriteLine("Nonequal lines: {0}", nonEqual);
                }
            }
        }
    }
