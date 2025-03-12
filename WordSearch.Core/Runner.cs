using WordSearch.Core.Data;
using WordSearch.Core.Logic;
using WordSearch.Core.Utility;

namespace WordSearch.Core
{
    class Runner
    {
        private readonly WordData _wordData;
        private readonly CreateGrid _createGrid;
        private readonly InsertWords _insertWords;
        private readonly ValidateWord _validateWord;
        public Runner(ValidateWord validateWord, WordData wordData, CreateGrid createGrid, InsertWords insertWords)
        {
            _wordData = wordData;
            _createGrid = createGrid;
            _insertWords = insertWords;
            _validateWord = validateWord;
        }

        public void RunPuzzle(int difficulty, string word)
        {
            _validateWord.ValidWord(word);
            _wordData.AddWord(word);

            if(_wordData.Words.Count == 6)
            {
                List<char[]> wordSearch = _createGrid.CreateRows(difficulty);
            }
            else if(_wordData.Words.Count > 6)
            {
                _wordData.Clear();
                throw new ArgumentException("Something went wrong, please try again.");
            }
        }
    }
}