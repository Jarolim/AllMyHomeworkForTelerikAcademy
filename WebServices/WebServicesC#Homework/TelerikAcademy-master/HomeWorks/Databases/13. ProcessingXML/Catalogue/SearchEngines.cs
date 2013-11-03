using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Catalogue
{
    public class SearchEngines
    {
        public static void ExtractAuthors()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;
            Dictionary<string, int> artists = new Dictionary<string, int>();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                string artist = node["artist"].InnerText;
                if (artists.ContainsKey(artist))
                {
                    artists[artist] += 1;
                }
                else
                {
                    artists.Add(artist, 1);
                }

            }

            foreach (var artist in artists)
            {
                Console.WriteLine("{0} have {1} albums", artist.Key, artist.Value);
            }
        }

        public static void ExtractAuthorsXPath()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../catalogue.xml");
            string xPathQuery = "/catalogue/album";
            XmlNodeList albumList = xmlDoc.SelectNodes(xPathQuery);
            Dictionary<string, int> artists = new Dictionary<string, int>();
            foreach (XmlNode albumNode in albumList)
            {
                string artistName = albumNode.SelectSingleNode("artist").InnerText;
                if (artists.ContainsKey(artistName))
                {
                    artists[artistName] += 1;
                }
                else
                {
                    artists.Add(artistName, 1);
                }
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("{0} have {1} albums", artist.Key, artist.Value);
            }
        }

        public static void ExtractSong()
        {
            using (XmlReader reader = XmlReader.Create("../../catalogue.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }

        public static void SearchWithLinq()
        {
            XDocument xmlDoc = XDocument.Load("../../catalogue.xml");
            var songs =
                from song in xmlDoc.Descendants("song")
                select song.Element("title");

            foreach (var song in songs)
            {
                Console.WriteLine(song.Value);
            }
        }
    }
}
