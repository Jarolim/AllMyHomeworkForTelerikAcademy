using System;
using System.Linq;
using System.Net;

namespace FileDownload
{
    class FileDownload
    {
        static void Main(string[] args)
        {
            using (WebClient picture = new WebClient())
            {
                try
                {
                    Console.WriteLine("This program will download the logo of BARS to your desktop.");
                    string path = Environment.ExpandEnvironmentVariables(@"%UserProfile%\Desktop\logo-basd.jpg");
                    picture.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", path);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("You entered an empty address.");
                }
                catch (WebException we)
                {
                    Console.WriteLine(we.Message);
                }
                catch (NotSupportedException nse)
                {
                    Console.WriteLine(nse.Message);
                }
            }
        }
    }
}
