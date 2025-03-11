using WordSearch.Core;

namespace Test
{
    public class WordListStateTest
    {
        private readonly WordListState _wordListState = new WordListState();

        [Theory]
        [InlineData("duck")]
        [InlineData("  gOAt  ")]
        public void ShouldStoreWordAsCharArray(string word)
        {
            var wordCharArray = word.ToUpper().Trim().ToCharArray();

            _wordListState.AddWord(wordCharArray);

            Assert.Contains(wordCharArray.ToList(), _wordListState.Words);
        }
    }
}
