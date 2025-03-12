
namespace WordSearch.Core.Data
{
    public class WordSearchData
    {
        private readonly List<char[]> _wordSearch = new List<char[]>();

        public List<char[]> wordSearch => _wordSearch;

        public void AddPuzzle(List<char[]> puzzle) => _wordSearch.AddRange(puzzle);

        public void Clear() => _wordSearch.Clear();
    }
}
