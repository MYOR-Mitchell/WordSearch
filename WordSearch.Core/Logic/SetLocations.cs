
namespace WordSearch.Core.Logic
{
    public class SetLocations
    {
        private readonly Random _random;
        public SetLocations(Random random)
        {
            _random = random;
        }

        public (List<int>, List<int>) Locations(int gridSize, List<char[]> words)
        {
            List<int> xLocations = new List<int>();
            List<int> yLocations = new List<int>();

            for(int i = 0; i < words.Count; i++)
            {
                int xLocation = _random.Next(0, gridSize);
                int yLocation = _random.Next(0, gridSize);

                char[] word = new char[words[i].Length];
                Array.Copy(words[i], word, words[i].Length);

                if(word.Length > (gridSize - xLocation) && word.Length > (gridSize - yLocation)) //accounts for diagonal - up and right
                {
                    Array.Reverse(word);
                    xLocation = xLocation - word.Length;
                    yLocation = yLocation - word.Length;
                }
                else if(word.Length > (gridSize - xLocation)) //Accounts for right
                {
                    Array.Reverse(word);
                    xLocation = xLocation - word.Length;
                }
                else if(word.Length > (gridSize - yLocation)) //Accounts for up
                {
                    Array.Reverse(word);
                    yLocation = yLocation - word.Length;
                }

                xLocations.Add(xLocation);
                yLocations.Add(yLocation);
            }
            return (xLocations, yLocations); 
        }
    }
}