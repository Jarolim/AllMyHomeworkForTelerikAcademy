using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


static class BookmarksImporter
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../bookmarks.xml");
        string xPathQuery = "/bookmarks/bookmark";

        XmlNodeList bookmarksList = xmlDoc.SelectNodes(xPathQuery);
        foreach (XmlNode bookmarkNode in bookmarksList)
        {
            string username = bookmarkNode.GetChildText("username");
            string title = bookmarkNode.GetChildText("title");
            string url = bookmarkNode.GetChildText("url");
            string allTags = bookmarkNode.GetChildText("tags");
            string notes = bookmarkNode.GetChildText("notes");

            //string[] tags = allTags.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] tags = { };
            if (allTags != null)
            {
                tags = allTags.Split(',');

                for (int i = 0; i < tags.Length; i++)
                {
                    tags[i] = tags[i].Trim();
                }
            }
            //Console.WriteLine(username);

            AddBookmark(username, title, url, tags, notes);


        }
    }

    private static string GetChildText(this XmlNode node, string tagname)
    {
        XmlNode childNode = node.SelectSingleNode(tagname);
        if (childNode == null)
        {
            return null;
        }
        return childNode.InnerText;
    }


    private static void AddBookmark(string username, string title, string url, string[] tags, string notes)
    {
        Console.WriteLine("{0} {1} {2} {3} {4}", username, title, url, string.Join(", ", tags), notes);
    }
}

