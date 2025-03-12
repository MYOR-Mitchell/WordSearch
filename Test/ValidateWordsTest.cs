using WordSearch.Core;

namespace Test
{
    public class ValidateWordsTest
    {
        private readonly ValidateWord _validate;
        private readonly WordList _wordList;
        public ValidateWordsTest()
        {
            _wordList = new WordList();
            _validate = new ValidateWord(_wordList);
        }

        [Theory]
        [InlineData("duck")]
        [InlineData("  gOAt  ")]
        public void ShouldPassIfWordIsValid(string word)
        {
            _validate.ValidWord(word);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("goat.")]
        [InlineData("penguin")] 
        public void ShouldThrowExceptionForInvalidWords(string word)
        {
            Assert.Throws<ArgumentException>(() => _validate.ValidWord(word));
        }
    }
}
