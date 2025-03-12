using WordSearch.Core;

namespace Test
{
    public class WordListTest
    {
        private readonly WordList _wordList = new WordList();

        [Theory]
        [InlineData("duck")]
        [InlineData("  gOAt  ")]
        public void ShouldStoreWordAsCharArray(string word)
        {
            var wordCharArray = word.ToUpper().Trim().ToCharArray();

            _wordList.AddWord(wordCharArray);

            Assert.Contains(wordCharArray.ToList(), _wordList.Words);
        }
    }
}
