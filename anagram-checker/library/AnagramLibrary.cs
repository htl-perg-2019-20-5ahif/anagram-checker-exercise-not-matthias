using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace library
{
    public class AnagramLibrary
    {
        private readonly IConfiguration config;

        public AnagramLibrary(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// Finds all known anagrams and returns them.
        /// </summary>
        /// <param name="anagramName">the given string</param>
        /// <returns>a list of anagrams of the given parameter</returns>
        public List<string> GetKnownAnagrams(string anagramName)
        {
            var sortedAnagramName = anagramName.SortAscending();

            var anagramReader = new AnagramReader(config);
            var anagrams = anagramReader.ReadFromFile();
            var dictionary = AnagramReader.ConvertToDictionary(anagrams);

            if(!dictionary.ContainsKey(sortedAnagramName))
            {
                return default;
            }

            return dictionary[sortedAnagramName].Where(anagram => anagram != anagramName).ToList();
        }
    }
}
