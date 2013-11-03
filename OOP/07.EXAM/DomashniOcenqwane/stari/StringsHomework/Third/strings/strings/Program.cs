using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace strings
{
    class Program
    {

        static string ReverseText(string str1)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str1.Length - 1; i >= 0; i--)
            {
                sb.Append(str1[i]);
            }
            return sb.ToString();
        }
        static string GetAllCapital(string str1)
        {
            StringBuilder sb = new StringBuilder();
            char[] let = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for (int i = 0; i < str1.Length; i++)
            {
                foreach (char letter in let)
                {
                    if (letter == str1[i])
                    {
                        sb.Append(str1[i]);
                        break;
                    }
                }
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            //string abc = "asdq";
            //string cba = abc;
            //abc = abc + "1234";
            //Console.WriteLine(abc);
            //Console.WriteLine(cba);

            //string a = "C#";
            //string b = "c#";
            //bool isEqual = a.Equals(b);
            //Console.WriteLine(isEqual);
            //Console.WriteLine(a.Equals(b));
            //Console.WriteLine(a.Equals("C#"));
            //string book = "Introduction to programing with C#.";
            //int index = book.IndexOf("C#");
            //Console.WriteLine(index);
            //index = book.IndexOf("intro");
            //Console.WriteLine(index);
            //index = book.IndexOf("Intro");
            //Console.WriteLine(index);
            //index = book.IndexOf("pro");
            //Console.WriteLine(index);
            //index = book.IndexOf("pro", 15);
            //Console.WriteLine(index);
            //index = book.IndexOf("pro", 16);
            //Console.WriteLine(index);
            //index = book.IndexOf("pro", 17);
            //Console.WriteLine(index);

            //// tyrsene na wsichki powtoreniq na daden niz
            //string quote = "The main intent of the \"Intro C#\"" +
            //" book is to introduce the C# programming to newbies.";
            //index = quote.IndexOf("C#");

            //while (index != -1)
            //{
            //    Console.WriteLine(index);
            //    index = quote.IndexOf("C#", index + 1);
            //}

            //string sub = quote.Substring(4, 2);
            //Console.WriteLine(sub);
            //string listOfBeers = "ariana, kamenitza, shumensko, beks";
            //char[] split = new char[] { ' ', '.' };
            //string[] beers = listOfBeers.Split(split);
            //foreach (string beer in beers)
            //{
            //    if (beer != "")
            //    {
            //        Console.Write(beer);
            //    }
            //}
            //Console.WriteLine();
            //string[] beersWithoutEmptySp = listOfBeers.Split(split, StringSplitOptions.RemoveEmptyEntries);
            //foreach (string beer in beersWithoutEmptySp)
            //{
            //    Console.Write(beer);
            //}
            //Console.WriteLine();


            //string ber = "";
            //ber = listOfBeers.Replace("kamenitza", "bira");
            //Console.WriteLine(ber);

            //string fileData = "    \n abe kwo stawa   \t";
            //string reduced = fileData.Trim();
            //Console.Write(reduced);
            //Console.WriteLine(reduced);

            //string fileData2 = "  \n 1111$$$ ### abe kwi sa tiq gluposti <>";
            //char[] trimChars = new char[] {'\n',' ', '1', '$', '#', '>', '<' };
            //string reduced2 = fileData2.Trim(trimChars);
            //Console.WriteLine(reduced2);
            //fileData = fileData.Trim();
            //Console.WriteLine(fileData);
            //Console.WriteLine(new string('-',35));
            //Console.WriteLine("Starting to use stringbuilder");
            //Console.WriteLine(new string('-', 35));
            //string abc = "Hello this is gonna be reversed";
            //string reversed = ReverseText(abc);
            //StringBuilder sb = new StringBuilder();
            //string str1 = "I am nOt so gOod At proGramMinG";
            //Console.WriteLine(GetAllCapital(str1));
          
            //29.1.13

            //string number = Console.ReadLine();
            //int a = int.Parse(number);
            //Console.WriteLine(a);

            //string boolean = "false";
            //bool flag = bool.Parse(boolean);
            //Console.WriteLine(flag);
            string text = "abe kwi sa tiq gluposti";

            foreach (string word in text.Split())
            {
                Console.Write(word);
            }

          

           }
    }
}