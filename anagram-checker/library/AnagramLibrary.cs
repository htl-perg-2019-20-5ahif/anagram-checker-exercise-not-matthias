using System;
using System.Collections.Generic;
using System.Linq;

namespace library
{
    public static class AnagramLibrary
    {
        public static List<string> GetKnownAnagrams(string name)
        {
            var anagrams = AnagramReader.ReadFromFile("anagrams.json");

            IEnumerable<string> knownAnagrams = new List<string>();

            var sortedAnagram = string.Concat(name.OrderBy(c => c));
            var filteredAnagrams = anagrams.Where(match => string.Equals(string.Concat(match.W1.OrderBy(c => c)), sortedAnagram));

            //knownAnagrams.AddRange(filteredAnagrams);

            foreach (Anagram anagram in anagrams)
            {
                Console.WriteLine(anagram.W1);
            }

            return new List<string>();
        }

        public static bool IsValidAnagram(Anagram anagram)
        {
            return true;
        }
    }
}
