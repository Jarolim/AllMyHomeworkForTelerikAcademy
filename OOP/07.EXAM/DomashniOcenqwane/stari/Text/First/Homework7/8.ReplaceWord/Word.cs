using System;
using System.IO;
using System.Text.RegularExpressions;

    class Word
    {
        static void Main()
        {
            string fileName = @"..\..\..\Text files are here\08. Input File.txt";
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                string replaced = @"..\..\..\Text files are here\08. Output File.txt";
                StreamWriter writer = new StreamWriter(replaced);
                using (writer)
                {
                    fileName = reader.ReadToEnd();
                    string replaceWhat = @"\b(start)\b";
                    Regex replace = new Regex(replaceWhat);
                    string replaceWith = replace.Replace(fileName, "finish");
                    writer.WriteLine(replaceWith);
                }
            }    
        }
    }
