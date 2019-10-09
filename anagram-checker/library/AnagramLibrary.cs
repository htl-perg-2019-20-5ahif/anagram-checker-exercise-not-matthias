using System;
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
        public IEnumerable<string> GetKnownAnagrams(string anagramName)
        {
            var sortedAnagramName = anagramName.SortAscending();

            var anagrams = anagramReader.ReadFromFile();
            if (anagrams == null)
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

        /// <summary>
        /// Generates the permutations of the given string.
        /// </summary>
        /// <param name="name">the string for which permutations should be made</param>
        /// <returns>a list of permutations</returns>
        public IEnumerable<string> GetPermutations(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return default;
            }

            if (name.Length == 1)
            {
                return new List<string> { name };
            }

            // Source: https://loekvandenouweland.com/content/Permutations-with-C-sharp-and-LINQ.html
            var permutations = from c in name
                               from p in GetPermutations(new string(name.Where(x => x != c).ToArray()))
                               select c + p;

            return permutations;
        }
    }
}
