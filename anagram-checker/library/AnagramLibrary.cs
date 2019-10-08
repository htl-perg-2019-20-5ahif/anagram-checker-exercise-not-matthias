using System;
using System.Collections.Generic;
using System.Linq;

namespace library
{
    public static class AnagramLibrary
    {
        private static readonly Dictionary<string, List<string>>  anagrams = AnagramReader.ConvertToDictionary(AnagramReader.ReadFromFile("anagrams.json"));

        public static List<string> GetKnownAnagrams(string name)
        {
            List<string> knownAnagrams = new List<string>();

            // TODO: Read it into a dictionary once and then look it up
            foreach (Anagram anagram in anagrams)
            {
                //
                // Compare with the first word
                //
                if (IsValidAnagram(new Anagram { W1 = anagram.W1, W2 = name})) {
                    knownAnagrams.Add(anagram.W1);
                }

                //
                // Compare with the second word
                //
                if (IsValidAnagram(new Anagram { W1 = name, W2 = anagram.W2 }))
                {
                    knownAnagrams.Add(anagram.W2);
                }
            }

            return knownAnagrams.Where(anagram => anagram != name).ToList();
        }

        public static bool IsValidAnagram(Anagram anagram)
        {
            return string.Equals(string.Concat(anagram.W1.OrderBy(c => c)), string.Concat(anagram.W2.OrderBy(c => c)));
        }
    }
}
