using System.Collections.Generic;
using System.Linq;

namespace library
{
    public class AnagramLibrary : IAnagramLibrary
    {
        private readonly IAnagramReader anagramReader;

        public AnagramLibrary(IAnagramReader anagramReader)
        {
            this.anagramReader = anagramReader;
        }

        /// <summary>
        /// Finds all known anagrams and returns them.
        /// </summary>
        /// <param name="anagramName">the given string</param>
        /// <returns>a list of anagrams of the given parameter</returns>
        public List<string> GetKnownAnagrams(string anagramName)
        {
            var sortedAnagramName = anagramName.SortAscending();

            var anagrams = anagramReader.ReadFromFile();
            if(anagrams == null)
            {
                return default;
            }

            var dictionary = AnagramFileReader.ConvertToDictionary(anagrams);
            if (anagrams == null)
            {
                return default;
            }

            if (!dictionary.ContainsKey(sortedAnagramName))
            {
                return default;
            }

            return dictionary[sortedAnagramName].Where(anagram => anagram != anagramName).ToList();
        }
    }
}
