using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace Catalogue
{
    public class ReadParse
    {
        public static void ReadTxtSaveXml()
        {
            string fileLocation = @"..\..\person.xml";
            string[] lines = File.ReadAllLines(@"..\..\Person.txt");
            string name = lines[0];
            string address = lines[1];
            string phoneNumber = lines[2];

            XElement personInfo = new XElement("Person",
                        new XElement("name", name),
                        new XElement("address", address),
                        new XElement("phoneNumber", phoneNumber));
            personInfo.Save(fileLocation);
        }

        public static void WriteAlbum()
        {
            string fileName = "../../album.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            XmlTextWriter writer = new XmlTextWriter(fileName, encoding);
            using (writer)
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("albums");

                string name = string.Empty;
                using (XmlReader reader = XmlReader.Create("../../catalogue.xml"))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "name"))
                        {
                            name = reader.ReadElementString();
                        }
                        else if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "artist"))
                        {
                            string artist = reader.ReadElementString();
                            WriteAlbum(writer, name, artist);
                        }
                    }
                }
                writer.WriteEndDocument();
                Console.WriteLine("Document {0} was created.", fileName);
            }
        }

        private static void WriteAlbum(XmlWriter writer, string name, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }

        public static void ExtractAlbumsByPrice()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../catalogue.xml");

            string xPathQuery = "/catalogue/album[year<2008]";
            XmlNodeList priceList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode priceNode in priceList)
            {
                string albumName = priceNode.SelectSingleNode("name").InnerText;
                string price = priceNode.SelectSingleNode("price").InnerText;
                Console.WriteLine("Price of {0}-> {1}.00 USD", albumName, price);
            }
        }

        public static void ExtractPriceLinq()
        {
            XDocument xmlDoc = XDocument.Load("../../catalogue.xml");

            var albums =
        from album in xmlDoc.Descendants("album")
        where int.Parse(album.Element("year").Value) < 2008
        select new
        {
            Title = album.Element("name").Value,
            Price = album.Element("price").Value
        };
            Console.WriteLine("Found {0} albums:", albums.Count());
            foreach (var album in albums)
            {
                Console.WriteLine(" Album Name {0}-> Price {1}.00 USD", album.Title, album.Price);
            }
        }
    }
}
