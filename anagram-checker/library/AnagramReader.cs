using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace library
{
    class AnagramReader
    {
        public static List<Anagram> ReadFromFile(string file)
        {
            using StreamReader r = new StreamReader(file);
            string json = r.ReadToEnd();

            return JsonConvert.DeserializeObject<List<Anagram>>(json);
        }
    }
}
