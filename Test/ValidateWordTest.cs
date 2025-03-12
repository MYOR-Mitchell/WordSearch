using WordSearch.Core.Utility;

namespace Test
{
    public class ValidateWordTest
    {
        private readonly ValidateWord _validateWord = new ValidateWord();

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("duck.")]
        [InlineData("superduck")] 
        public void ShouldThrowExceptionForInvalidWords(string word)
        {
            Assert.Throws<ArgumentException>(() => _validateWord.ValidWord(word));
        }
    }
}
