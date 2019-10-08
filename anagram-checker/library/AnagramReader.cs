using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace library
{
    class AnagramReader
    {
        public static List<Anagram> ReadFromFile(string file)
        {
            try
            {
                using StreamReader r = new StreamReader(file);
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Anagram>>(json);
            }
            catch (System.Exception)
            {
                return new List<Anagram>();
            }
        }

        public static Dictionary<string, List<string>> ConvertToDictionary(List<Anagram> anagrams)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            foreach (Anagram anagram in anagrams)
            {
                var list = new List<string> { anagram.W1, anagram.W2 };

                dictionary.Add(string.Concat(anagram.W1.OrderBy(c => c)), list);
            }

            return dictionary;
        }
    }
}
