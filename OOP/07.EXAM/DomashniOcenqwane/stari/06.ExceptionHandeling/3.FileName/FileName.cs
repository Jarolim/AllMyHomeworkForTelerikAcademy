using System;
using System.IO;
class FileName
{
    static void Main()
    {
        Console.Write("please enter valid path: ");
        string fullPath = Console.ReadLine();
        try
        {
            Console.WriteLine(System.IO.File.ReadAllText(fullPath));
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("path is in invalid format!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("file \"{0}\" is not found", fullPath);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("the directory {0} is not found!", fullPath);
        }
        catch (System.UnauthorizedAccessException)
        {
            Console.WriteLine("security error. forbidden access");
        }
        catch (IOException)
        {
            Console.WriteLine("IO error while reaching file");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("atleast on of arguments is not valid!");
        }
        Console.ReadLine();
    }
}

