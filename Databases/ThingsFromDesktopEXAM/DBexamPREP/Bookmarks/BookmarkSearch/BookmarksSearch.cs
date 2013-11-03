using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookmarks.Data;

static class BookmarksSearch
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../simple-query.xml");
        string username = xmlDoc.GetChildText("/query/username");
        string tag = xmlDoc.GetChildText("/query/tag");
        //Console.WriteLine(username);
        //Console.WriteLine(tag);
        var bookmarks = BookmarksDAL.FindBookmarksByUsernameAndTag(username, tag);
        if (bookmarks.Count > 0)
        {
            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine(bookmark.URL);
            }
        }
        else 
        { 
            Console.WriteLine("Nothing Found"); 
        }
        

        //XmlNodeList bookmarksList = xmlDoc.SelectNodes(xPathQuery);
        //foreach (XmlNode bookmarkNode in bookmarksList)
        //{
        //    string username = bookmarkNode.GetChildText("username");
        //}
    }

    private static string GetChildText(this XmlNode node, string xpath)
    {
        XmlNode childNode = node.SelectSingleNode(xpath);
        if (childNode == null)
        {
            return null;
        }
        return childNode.InnerText.Trim();
    }
}

