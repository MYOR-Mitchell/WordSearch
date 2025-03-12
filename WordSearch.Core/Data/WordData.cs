namespace WordSearch.Core.Data
{
    public class WordData
    {
        private readonly List<char[]> _words = new List<char[]>();

        public List<char[]> Words => _words;

        public void AddWord(string word) => _words.Add(word.ToCharArray());

        public void Clear() => _words.Clear();
    }
}