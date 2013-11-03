using System;
using System.IO;

public class TraverseThrougWindowsDirectory
{
    public static void ShowExeFiles(string directoryToSearch)
    {
        try
        {
            string[] exeFilesInCurrentDir = Directory.GetFiles(directoryToSearch, "*.exe");

            for (int i = 0; i < exeFilesInCurrentDir.Length; i++)
            {
                Console.WriteLine(exeFilesInCurrentDir[i]);
            }

            var currentDirectory = Directory.EnumerateDirectories(directoryToSearch);

            foreach (var folder in currentDirectory)
            {
                ShowExeFiles(folder);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Directory {0} cannot be accessed", directoryToSearch);
        }
    }

    public static void Main()
    {
        Console.WriteLine("--- *.exe files in C:\\Windows: ---");
        ShowExeFiles(@"C:\Program Files");
    }
}