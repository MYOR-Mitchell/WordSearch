namespace WordSearch.Core.Logic
{
    public class CreateGrid
    {
        private readonly char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly Random random;

        public CreateGrid()
        {
            random = new Random();
        }

        public List<char[]> CreateRows(int difficulty)
        {
            List<char[]> Rows = new List<char[]>();

            for(int i = 0; i < difficulty; i++)
            {
                char[] row = new char[difficulty];

                for(int j = 0; j < difficulty; j++)
                {
                    row[j] = GenerateLetter();
                }
                Rows.Add(row);
            }
            return Rows;
        }

        private char GenerateLetter()
        {
            var letterIndex = random.Next(0, letters.Length);
            return letters[letterIndex];
        }
    }
}