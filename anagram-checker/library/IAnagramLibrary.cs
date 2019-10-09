using System.Collections.Generic;

namespace library
{
    public interface IAnagramLibrary
    {
        public IEnumerable<string> GetKnownAnagrams(string anagramName);

        public IEnumerable<string> GetPermutations(string name);
    }
}
