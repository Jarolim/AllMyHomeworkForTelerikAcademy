using System;
using System.IO;
using System.Text.RegularExpressions;


    class Remove
    {
        static void Main()
        {
            try
            {
                string exceptions = @"\b(" + String.Join("|", File.ReadAllLines(@"..\..\..\Text files are here\12. List of Words.txt")) + @")\b";
                string read = @"..\..\..\Text files are here\12. Input Text.txt";
                StreamReader reader = new StreamReader(read);
                using (reader)
                {
                    string write = @"..\..\..\Text files are here\12. Output Text.txt";
                    StreamWriter writer = new StreamWriter(write);
                    using (writer)
                    {
                        for (string line; (line = reader.ReadLine()) != null; )
                            writer.WriteLine(Regex.Replace(line, exceptions, String.Empty));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file hasn't been found");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Check if the directory is correct");
            }
            catch (IOException)
            {
                Console.WriteLine("There is a problem with the input or the output. Please try again.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Critical Error. Restart and try again");
            }
            finally
            {
                Console.WriteLine("Thank you for using our product. Goodbye.");
            }               
        }
    }

