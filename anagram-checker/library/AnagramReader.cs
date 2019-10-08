using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace library
{
    class AnagramReader
    {
        private readonly IConfiguration config;

        public AnagramReader(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// Reads the anagrams from the json file.
        /// </summary>
        /// <returns>the collection of anagrams</returns>
        public IEnumerable<Anagram> ReadFromFile()
        {
            try
            {
                using StreamReader r = new StreamReader(config["dictionaryFileName"]);
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
        public static Dictionary<string, List<string>> ConvertToDictionary(IEnumerable<Anagram> anagrams)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            foreach (Anagram anagram in anagrams)
            {
                var sortedKey = string.Concat(anagram.W1.OrderBy(c => c));

                if (!dictionary.ContainsKey(sortedKey))
                {
                    dictionary.Add(sortedKey, new List<string> { anagram.W1, anagram.W2 });
                }
                else
                {
                    dictionary[sortedKey].AddRange(new List<string> { anagram.W1, anagram.W2 });
                }
            }

            return dictionary;
        }
    }
}
