using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library
{
    public static class StringExtension
    {
        public static string SortAscending(this string word) => string.Concat(word.OrderBy(c => c));
    }
}
