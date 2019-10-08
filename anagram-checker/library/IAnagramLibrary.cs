using System.Collections.Generic;

namespace library
{
    public interface IAnagramLibrary
    {
        public List<string> GetKnownAnagrams(string anagramName);
    }
}
