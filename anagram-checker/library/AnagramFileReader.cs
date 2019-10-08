using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace library
{
    public class AnagramFileReader : IAnagramReader
    {
        private readonly IConfiguration config;

        public AnagramFileReader(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// Reads the anagrams from the json file.
        /// </summary>
        /// <returns>the collection of anagrams</returns>
        public IEnumerable<Anagram> ReadFromFile()
        {
            var fileName = config["dictionaryFileName"];
            if(string.IsNullOrEmpty(fileName))
            {
                return default;
            }

            try
            {
                using StreamReader r = new StreamReader(fileName);
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Anagram>>(json);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Converts the collection of anagrams into a dictionary.
        /// </summary>
        /// <param name="anagrams">the list of anagrams</param>
        /// <returns>the dictionary with the anagrams (key = sorted anagram, value = list of anagrams)</returns>
        public static IDictionary<string, HashSet<string>> ConvertToDictionary(IEnumerable<Anagram> anagrams)
        {
            if(anagrams == null)
            {
                return default;
            }

            var dictionary = new Dictionary<string, HashSet<string>>();

            foreach (Anagram anagram in anagrams)
            {
                var sortedKey = anagram.W1.SortAscending();

                if (!dictionary.ContainsKey(sortedKey))
                {
                    dictionary.Add(sortedKey, new HashSet<string> { anagram.W1, anagram.W2 });
                }
                else
                {
                    dictionary[sortedKey].Add(anagram.W1);
                    dictionary[sortedKey].Add(anagram.W2);
                }
            }

            return dictionary;
        }
    }
}
