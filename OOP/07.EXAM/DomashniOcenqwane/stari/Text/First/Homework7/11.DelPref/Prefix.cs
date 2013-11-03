using System;
using System.IO;
using System.Text.RegularExpressions;


    class Prefix
    {
        static void Main()
        {
            string read = @"..\..\..\Text files are here\11. Prefix.txt";
            StreamReader reader = new StreamReader(read);

            using (reader)
            {
                string write = @"..\..\..\Text files are here\11. Output Prefix.txt";
                StreamWriter writer = new StreamWriter(write);
                using (writer)
                {
                    for (string line; (line = reader.ReadLine()) != null; )
                        writer.WriteLine(Regex.Replace(line, @"\btest\w*\b", String.Empty));
                }
                Console.WriteLine("Your file is ready.");
            }
        }
    }

