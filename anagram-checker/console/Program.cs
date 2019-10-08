using System;
using System.Linq;
using library;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid arguments.");
            }

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
                Console.WriteLine("Invalid arguments.");
                return;
            }

            var isValid = new Anagram(args[1], args[2]).IsValid();
            Console.WriteLine($"\"{args[1]}\" and \"{args[2]}\" are {(isValid ? "anagrams" : "no anagrams")}");
        }

        private static void HandleGetKnown(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments.");
                return;
            }

            var anagramLibrary = new AnagramLibrary(GetConfiguration().Build());
            var knownAnagrams = anagramLibrary.GetKnownAnagrams(args[1]);
            if (knownAnagrams.Count == 0)
            {
                Console.WriteLine("No known anagrams found.");
                return;
            }

            knownAnagrams.ForEach(Console.WriteLine);
        }

        private static void HandleDefault()
        {
            Console.WriteLine("Command not found.");
        }

        private static IConfigurationBuilder GetConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();
        }
    }
}
