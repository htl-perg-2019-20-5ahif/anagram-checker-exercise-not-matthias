using System.Collections.Generic;
using System.Linq;

namespace library
{
    public static class StringExtension
    {
        public static string SortAscending(this string word) => string.Concat(word.OrderBy(c => c));

        public static IEnumerable<string> GetPermutations(this string source)
        {
            if (source.Length == 1)
            {
                return new List<string> { source };
            }

            // https://loekvandenouweland.com/content/Permutations-with-C-sharp-and-LINQ.html
            var permutations = from c in source
                               from p in GetPermutations(new string(source.Where(x => x != c).ToArray()))
                               select c + p;

            return permutations;
        }
    }
}
