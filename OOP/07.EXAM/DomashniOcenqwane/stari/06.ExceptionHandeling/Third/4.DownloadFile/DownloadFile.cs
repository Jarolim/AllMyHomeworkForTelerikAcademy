using System;
using System.Linq;
using System.Net;


class DownloadFile
{
    static void Main()
    {
        Console.Write("Enter URL address: ");
        string path = Console.ReadLine();

        Console.Write("Enter file name: ");
        string name = Console.ReadLine();

        using (WebClient webClient = new WebClient())
        {
            try
            {
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile(path, name);
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The path is zero-length/ one or more invalid chars!");
            }
            catch (WebException)
            {
                Console.WriteLine("Invalid address/ filename-null reference(empty)/ error while downloading!");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("You do not have the required permission to write to local file!");
            } 
        }
    }
}

