using System;
using System.Collections.Generic;
using System.Linq;

namespace library
{
    public static class AnagramLibrary
    {
        //public AnagramLibrary()
        //{
        //    //this.anagrams = AnagramReader.ConvertToDictionary(new AnagramReader().ReadFromFile())
        //}

        public static List<string> GetKnownAnagrams(string name)
        {
            List<string> knownAnagrams = new List<string>();

            return knownAnagrams.Where(anagram => anagram != name).ToList();
        }

        public static bool IsValidAnagram(Anagram anagram)
        {
            return string.Equals(string.Concat(anagram.W1.OrderBy(c => c)), string.Concat(anagram.W2.OrderBy(c => c)));
        }
    }
}
