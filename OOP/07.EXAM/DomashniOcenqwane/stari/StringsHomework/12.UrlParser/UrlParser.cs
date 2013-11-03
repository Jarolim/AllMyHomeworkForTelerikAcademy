using System;

public class UrlParser
{
    public static void Main()
    {
        Uri uri = new Uri("http://www.devbg.org/forum/index.php");

        Console.WriteLine("[protocol] = \"{0}\"", uri.Scheme);
        Console.WriteLine("[server] = \"{0}\"", uri.Host);
        Console.WriteLine("[resource] = \"{0}\"", uri.AbsolutePath);
    }
}