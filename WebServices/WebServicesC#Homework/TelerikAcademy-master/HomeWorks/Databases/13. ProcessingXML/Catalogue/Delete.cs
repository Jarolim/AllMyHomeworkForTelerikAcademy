using System;
using System.Linq;
using System.Xml;
using System.Globalization;

namespace Catalogue
{
    public class Delete
    {
        public static void DeleteByPrice(decimal searchedPrice)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;
            int removed = 0; 

            var enumerator = rootNode.ChildNodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var node = (XmlNode)enumerator.Current;
                string priceStr = node["price"].InnerText;
                decimal price = Decimal.Parse(priceStr, CultureInfo.InvariantCulture);

                if (price > searchedPrice)
                {
                    node.ParentNode.RemoveChild(node);
                    enumerator = rootNode.ChildNodes.GetEnumerator();

                    removed++;
                }
            }

            Console.WriteLine("{0} albums were removed", removed);

        }
    }
}
