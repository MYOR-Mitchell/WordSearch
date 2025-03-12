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

        public List<char[]> CreateRows(int gridSize)
        {
            List<char[]> Rows = new List<char[]>();

            for(int i = 0; i < gridSize; i++)
            {
                char[] row = new char[gridSize];

                for(int j = 0; j < gridSize; j++)
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