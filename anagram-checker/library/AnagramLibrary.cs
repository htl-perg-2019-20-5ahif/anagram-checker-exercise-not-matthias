using System.Collections.Generic;
using System.Linq;

namespace library
{
    public class AnagramLibrary
    {
        //public AnagramLibrary()
        //{
        //    //this.anagrams = AnagramReader.ConvertToDictionary(new AnagramReader().ReadFromFile())
        //}

        public List<string> GetKnownAnagrams(string name)
        {
            List<string> knownAnagrams = new List<string>();

            return knownAnagrams.Where(anagram => anagram != name).ToList();
        }
    }
}
