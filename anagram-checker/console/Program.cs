using System;
using System.Collections.Generic;
using library;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {

            }

            //AnagramChecker check listen silent

            switch (args[0])
            {
                case "check":
                    HandleCheckAnagram(args);
                    break;

                case "getKnown":
                    HandleGetKnown(args);
                    break;

                default:
                    HandleDefault();
                    break;
            }

            Console.WriteLine();
        }

        private static void HandleCheckAnagram(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Could not find any anagrams in the parameters.");
                return;
            }

            var isValid = new Anagram(args[1], args[2]).IsValid();
            Console.WriteLine($"\"{args[1]}\" and \"{args[2]}\" are {(isValid ? "anagrams" : "no anagrams")}");
        }

        private static void HandleGetKnown(string[] args)
        {

        }

        private static void HandleDefault()
        {
            Console.WriteLine("Command not found.");
        }
    }
}
