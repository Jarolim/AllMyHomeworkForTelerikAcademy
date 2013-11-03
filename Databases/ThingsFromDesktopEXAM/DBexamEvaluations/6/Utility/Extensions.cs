using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Utility
{
    public static class Extensions
    {
        public static string GetText(this XmlNode node)
        {
            string text = null;

            if (node != null)
            {
                text = node.InnerText.Trim();
            }

            return text;
        }
    }
}
