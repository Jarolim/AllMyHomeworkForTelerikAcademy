using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


    class Remove
    {
        static void Main()
        {
            string read = @"..\..\..\Text files are here\10. Tags.xml";
            StreamReader reader = new StreamReader(read); 
            StringBuilder output = new StringBuilder();
            using (reader)
            {
                string text = reader.ReadLine();
                while (text != null)
                {
                    text = Regex.Replace(text, @"<[^>]*>", string.Empty);
                    if (!String.IsNullOrWhiteSpace(text))
                    {
                        output.Append(text + "\r\n");
                    }
                    text = reader.ReadLine();
                }
            }
            string write = @"..\..\..\Text files are here\10. Tags.txt";
            StreamWriter writer = new StreamWriter(write);
            using (writer)
            {
                writer.WriteLine(output);
            }
            
            Console.WriteLine("Your file must be ready.");
            }          
        }


