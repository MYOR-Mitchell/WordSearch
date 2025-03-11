
namespace WordSearch.Core
{
    public class CreateGrid
    {
        char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        int easy = 10;

        Random random = new Random();

        public char GenerateLetter()
        {
            var letterIndex = random.Next(0, letters.Length);
            return letters[letterIndex];
        }

        public List<List<char>> CreateRows()
        {
            List<List<char>> Rows = new List<List<char>>();

            for(int i = 0; i < easy; i++)
            {
                List<char> row = new List<char>();

                for(int j = 0; j < easy; j++)
                {
                    row.Add(GenerateLetter());
                }
                Rows.Add(row);
            }
            return Rows;
        }

        void Test()
        {
            var Rows = CreateRows();
            foreach(var row in Rows)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            Console.ReadKey();
        }
    }
}


