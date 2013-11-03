using System;
using System.Xml;

namespace Bookstore.Data
{
	public static class XmlNodeExtensions
	{
		public static string GetChildText(this XmlNode node, string tagName)
		{
			XmlNode childNode = node.SelectSingleNode(tagName);
			if (childNode == null)
			{
				return null;
			}
			return childNode.InnerText.Trim();
		}
	}
}
