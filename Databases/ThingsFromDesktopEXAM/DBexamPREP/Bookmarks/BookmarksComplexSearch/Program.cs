using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

static class BookmarksComplexSearch
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../complex-query.xml");
        foreach (XmlNode query in xmlDoc.SelectNodes("/queries/query"))
        {
            string username = query.GetChildText("username");

            int maxResults = 10;
            var maxResultsAttrib = query.Attributes["max-results"];
            if (maxResultsAttrib != null)
            {
                maxResults = int.Parse(maxResultsAttrib.Value);
            }

            List<string> tags = new List<string>();
            foreach (XmlNode tag in query.SelectNodes("tag"))
            {
                tags.Add(tag.InnerText.Trim());
            }

            var bookmarks = BookmarksDAL.FindBookmarks(username, tags, maxResults);
            foreach (var bookmark in bookmarks)
            {
                Console.WriteLine(bookmark.Title);
            }
        }
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

