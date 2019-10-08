using System.Collections.Generic;

namespace library
{
    public interface IAnagramReader
    {
        public IEnumerable<Anagram> ReadFromFile();
    }
}
