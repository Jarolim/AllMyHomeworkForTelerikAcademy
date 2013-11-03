using System;
using System.Net;
class DownloadFile
{
    static void Main()
    {
        Console.WriteLine("downloading file \"Logo-BASD.jpg\", and store in \"D:\\Logo-BASD.jpg\"");
        try
        {
            WebClient WebClient = new System.Net.WebClient();
            WebClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", @"D:\Logo-BASD.jpg");
            Console.WriteLine("download complete!");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("argument has null value");
        }
        catch (WebException)
        {
            Console.WriteLine("error while accesing network through pluggable protocol");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("invoked metod is not supported");
        }
        finally
        {
            Console.WriteLine("this is always executing!");
        }
        Console.ReadLine();
    }
}

