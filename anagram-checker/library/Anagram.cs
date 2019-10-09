namespace library
{
    public class Anagram
    {
        public string W1 { get; set; }
        public string W2 { get; set; }

        public Anagram()
        {
                
        }

        public Anagram(string w1, string w2)
        {
            W1 = w1;
            W2 = w2;
        }

        /// <summary>
        /// Checks whether the anagram is valid.
        /// </summary>
        /// <returns>true if it is valid</returns>
        public bool IsValid() => string.Equals(W1.SortAscending(), W2.SortAscending());
    }
}
