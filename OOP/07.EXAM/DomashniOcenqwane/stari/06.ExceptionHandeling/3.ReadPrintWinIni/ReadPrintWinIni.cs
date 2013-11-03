using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReadPrintWinIni
{
    static void Main()
    {
        
        Console.Write("Enter full file path: ");

        try
        {
            string path = Console.ReadLine();
            //string path = @"C:\WINDOWS\win.ini";
            string[] lines = System.IO.File.ReadAllLines(path);
            System.Console.WriteLine("Contents of the selected file = ");
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path is zero-length/ one or more invalid chars!");
        }
        catch (System.IO.PathTooLongException)
        {
            Console.WriteLine("The path is longer than 248 chars/ file name is longer than 260 chars!");
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("Invalid path!");
        }
        catch (System.IO.IOException)
        {
            Console.WriteLine("Input/ Output error!");
        }
        catch (System.UnauthorizedAccessException)
        {
            Console.WriteLine("The path is read-only/ operation not supported/ it's a directory/ you do not have the required permission! ");
        }
        catch (System.NotSupportedException)
        {
            Console.WriteLine("Invalid path format!");
        }
        catch (System.Security.SecurityException)
        {
            Console.WriteLine("You do not have the required permission!");
        }
        
    }
}

