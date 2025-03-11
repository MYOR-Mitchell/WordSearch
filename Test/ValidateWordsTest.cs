using WordSearch.Core;

namespace Test
{
    public class ValidateWordsTest
    {
        private readonly ValidateWords _validate;
        private readonly WordListState _wordListState;
        public ValidateWordsTest()
        {
            _wordListState = new WordListState();
            _validate = new ValidateWords(_wordListState);
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
