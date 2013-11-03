using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.parsingAnURL
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();
            string protocolEnd = "://";
            string serverEnd = "/";
            string protocol = "";
            string server = "";
            string resource = "";
            int protocolIndex = url.IndexOf(protocolEnd);
            int serverIndex = url.IndexOf(serverEnd, protocolIndex + 3);

            if (protocolIndex != -1)
            {
                for (int i = 0; i < protocolIndex; i++)
                {
                    protocol = protocol + url[i];
                }
            }
            else
            {
                Console.WriteLine("There isn't any protocol inputted");
            }

            if (serverIndex != -1)
            {
                for (int i = protocolIndex + 3; i < serverIndex; i++)
                {
                    server = server + url[i];
                }
            }
            else
            {
                Console.WriteLine("There isn't any server inputted");
            }

            if (serverIndex != (url.Length - 1))
            {
                for (int i = serverIndex; i < url.Length; i++)
                {
                    resource = resource + url[i];
                }
            }
            else
            {
                Console.WriteLine("There aren't any resources inputted");
            }
            Console.WriteLine("Protocol: " + protocol);
            Console.WriteLine(new string('-',35));
            Console.WriteLine("Server: " + server);
            Console.WriteLine(new string('-', 35));
            Console.WriteLine("Resource: " + resource);
        }
    }
}
