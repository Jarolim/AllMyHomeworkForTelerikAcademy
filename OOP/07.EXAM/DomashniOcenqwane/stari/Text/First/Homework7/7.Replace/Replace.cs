using System;
using System.IO;

    class Replace
    {
        static void Main()
        {
            string fileName = @"..\..\..\Text files are here\07. Read start substring.txt";
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                string replaced = @"..\..\..\Text files are here\07. Substring Changed.txt";
                StreamWriter writer = new StreamWriter(replaced);
                using (writer)
                {
                    fileName = reader.ReadToEnd();
                    string replace = fileName.Replace("start", "finish");
                    writer.WriteLine(replace);
                }
                Console.WriteLine("Your file is ready.");
            }    
        }
    }

