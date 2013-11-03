using System;
using System.IO;
using System.Collections.Generic;


    class Del
    {
        static void Main()
        {
            string fileName = @"..\..\..\Text files are here\09. Lyrics.txt";
            StreamReader reader = new StreamReader(fileName);
            string line = reader.ReadLine();
            int counter = 0;
            List<string> lines = new List<string>();
            while (line != null)
            {
                if (counter % 2 == 0)
                {
                    lines.Add(line);
                }
                line = reader.ReadLine();
                counter++;
            }
            reader.Close();

            StreamWriter writer = new StreamWriter(fileName, false);
            for (int i = 0; i < lines.Count; i++)
            {
                writer.WriteLine(lines[i]);
            }
            writer.Close();
        }
    }

