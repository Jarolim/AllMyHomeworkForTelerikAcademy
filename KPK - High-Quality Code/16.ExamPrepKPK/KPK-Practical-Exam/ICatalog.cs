using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CatalogOfFreeContent
{
    public interface ICatalog
    {
        /// <summary>
        /// Adds a content item to the catalog
        /// </summary>
        /// <param name="content"></param>
        void Add(IContent content);

        /// <summary>
        /// Finds all content items in the catalog hat match the specified title. Returns
        /// no more than numberOfContentElementsToList elements.
        /// The order of the returned elements is alphabetical regarding 
        /// theit ToString() representation
        /// </summary>
        /// <param name="title">the title of the elements we search</param>
        /// <param name="numberOfContentElementsToList">The maximal number of returned elements</param>
        /// <remarks>This method can return less than all matching elements in the catalog.
        /// For example 30 matching element but only 10 requested. And Vise versa.</remarks>
        /// <exception cref="...">...</exception>
        /// <returns></returns>
        IEnumerable<IContent> GetListContent(string title,  int numberOfContentElementsToList);

         int UpdateContent(string oldUrl, string newUrl);
    }
}
