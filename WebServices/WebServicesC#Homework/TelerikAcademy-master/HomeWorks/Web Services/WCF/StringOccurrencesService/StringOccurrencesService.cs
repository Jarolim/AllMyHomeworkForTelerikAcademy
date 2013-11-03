using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StringOccurrencesServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StringOccurrencesService : IStringOccurrencesService
    {
        public int GetOccurrences(string source, string target)
        {
            // logic comes here
            int occurrences = 0;
            int sourceIndex = target.IndexOf(source, 0);

            while (sourceIndex >= 0)
            {
                occurrences++;
                sourceIndex = target.IndexOf(source, sourceIndex + 1);
            }

            return occurrences;
        }
    }
}
