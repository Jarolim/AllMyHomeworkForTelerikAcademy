using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Catalogue
{
    public class TraverseDirectories
    {
        public static void TraverseDir()
        {
            string folderLocation = "../../";
            string outpitFile = "../../directory.xml";
            DirectoryInfo dir = new DirectoryInfo(folderLocation);
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(outpitFile, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");
                CreateXML(writer, dir);
                writer.WriteEndDocument();
            }
            Console.WriteLine("Document {0} created.", outpitFile);

            Console.Read();
        }

        private static void CreateXML(XmlTextWriter writer, DirectoryInfo dir)
        {

            foreach (var file in dir.GetFiles())
            {
                string xml = new XElement("file", new XAttribute("name", file.Name)).ToString();
                XmlReader reader = XmlReader.Create(new StringReader(xml));
                writer.WriteNode(reader, true);
            }

            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);
            foreach (var subDir in subdirectories)
            {
                CreateSubdirectoryXML(writer, subDir);
            }
        }

        private static void CreateSubdirectoryXML(XmlTextWriter writer, DirectoryInfo dir)
        {
            string xml = new XElement("dir", new XAttribute("name", dir.Name)).ToString();
            XmlReader reader = XmlReader.Create(new StringReader(xml));
            writer.WriteNode(reader, true);

            foreach (var file in dir.GetFiles())
            {
                xml = new XElement("file", new XAttribute("name", file.Name)).ToString();
                reader = XmlReader.Create(new StringReader(xml));
                writer.WriteNode(reader, true);
            }

            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);
            foreach (var subDir in subdirectories)
            {
                CreateSubdirectoryXML(writer, subDir);
            }
        }

        public static void Traverse()
        {
            string folderLocation = "../../";
            DirectoryInfo dir = new DirectoryInfo(folderLocation);
            var doc = new XDocument(CreateXML(dir));

            Console.WriteLine(doc.ToString());
        }

        private static XElement CreateXML(DirectoryInfo dir)
        {
            var xmlInfo = new XElement("MyDirectories");

            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);

            foreach (var subDir in subdirectories)
            {
                xmlInfo.Add(CreateSubdirectoryXML(subDir));
            }

            return xmlInfo;
        }

        private static XElement CreateSubdirectoryXML(DirectoryInfo dir)
        {
            var xmlInfo = new XElement("dir", new XAttribute("name", dir.Name));

            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);
            foreach (var subDir in subdirectories)
            {
                xmlInfo.Add(CreateSubdirectoryXML(subDir));
            }

            return xmlInfo;
        }
    }
}
