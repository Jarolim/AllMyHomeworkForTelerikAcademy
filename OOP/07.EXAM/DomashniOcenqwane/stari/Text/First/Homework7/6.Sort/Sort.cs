using System;
using System.IO;

    class Sort
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\Text files are here\06. Input Names.txt"))
            {
                string[] names = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(names);
                using (StreamWriter writer = new StreamWriter(@"..\..\..\Text files are here\06. Sorted Names.txt"))
                {
                    foreach (string s in names)
                    {
                        writer.WriteLine(s);
                    }
                    Console.WriteLine("Your file with sorted names is ready.");
                }
            }    
        }
    }

