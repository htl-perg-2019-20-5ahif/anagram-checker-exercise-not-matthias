using System;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var knownAnagrams = AnagramLibrary.GetKnownAnagrams("listen");
            Console.WriteLine();
        }
    }
}
