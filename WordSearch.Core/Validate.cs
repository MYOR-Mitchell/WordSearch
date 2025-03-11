namespace WordSearch.Core
{
    public class Validate
    {
        private readonly WordListState _wordListState;
        public Validate(WordListState wordListState)
        {
            _wordListState = wordListState;
        }

        public void ValidWord(string word)
        {
            if(string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Word cannot be null or empty.");
            }
            else if(word.Length < 3 || word.Length > 6)
            {
                throw new ArgumentException("Word must be between 3 and 6 characters long.");
            }
            else
            {
                _wordListState.AddWord(word.ToCharArray());
            }
        }
    }
}
