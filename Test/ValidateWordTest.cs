using WordSearch.Core.Utility;

namespace Test
{
    public class ValidateWordTest
    {
        private readonly ValidateWord validateWord = new ValidateWord();

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("duck.")]
        [InlineData("superduck")] 
        public void ShouldThrowExceptionForInvalidWords(string word)
        {
            Assert.Throws<ArgumentException>(() => validateWord.ValidWord(word));
        }
    }
}
