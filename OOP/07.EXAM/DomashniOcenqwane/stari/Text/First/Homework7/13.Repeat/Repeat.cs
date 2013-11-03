using System;
using System.IO;
using System.Text.RegularExpressions;

    class Repeat
    {
        static void Main()
        {
            try
            {
                string[] words = File.ReadAllLines(@"..\..\..\Text files are here\13. words.txt");
                int[] values = new int[words.Length];

                string read = @"..\..\..\Text files are here\13. input.txt";
                StreamReader reader = new StreamReader(read);
                using (reader)
                {
                    for (string line; (line = reader.ReadLine()) != null; )
                        for (int i = 0; i < words.Length; i++)
                            values[i] += Regex.Matches(line, @"\b" + words[i] + @"\b").Count;
                }
                Array.Sort(values, words);

                string write = @"..\..\..\Text files are here\13. output.txt";
                StreamWriter writer = new StreamWriter(write);
                using (writer)
                {
                    for (int i = words.Length - 1; i >= 0; i--)
                        writer.WriteLine("{0}: {1}", words[i], values[i]);
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("The file hasn't been found");
            }

            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("There is a problem with the dirrectory. Please try again.");
            }

            catch (IOException)
            {
                Console.WriteLine("There is a problem with the input or the output data.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Critical ERROR. Please restart and try again.");
            }
            finally
            {
                Console.WriteLine("Thenk you for using our product. Goodbye.");
            }
        }
    }

