namespace WordSearch.Core.Utility
{
    public class ValidateWord
    {
         public void ValidWord(string word)
        {
            word = word.ToUpper().Trim();

            if(string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Word cannot be empty.");
            }
            else if(word.Length < 3 || word.Length > 6)
            {
                throw new ArgumentException("Word must be between 3 and 6 characters long.");
            }
            else if(!word.All(char.IsLetter))
            {
                throw new ArgumentException("Word can only contain letters (A-Z).");
            }
        }
    }
}
