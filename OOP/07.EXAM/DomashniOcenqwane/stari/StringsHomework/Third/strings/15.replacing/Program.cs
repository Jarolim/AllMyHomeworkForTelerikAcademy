using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace _15.replacing
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
            char[] symbols = new char[] {' ', 'h', 'r', 'e', 'f', '=','"'};
            //string replace1 = Regex.Replace(text, "(<a)[symbols]", "$1[URL");
            string replace2 = Regex.Replace(text, "(<p)[>]{1}", "$1av");
            Console.WriteLine(replace2);
        }
    }
}
