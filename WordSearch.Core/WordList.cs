

namespace WordSearch.Core
{
    public class WordList
    {
        private List<List<char>> _words = new List<List<char>>();

        public List<List<char>> Words => _words;


        public void AddWord(char[] word) => _words.Add(word.ToList());

        public void ClearWords() => _words.Clear();
    }
}