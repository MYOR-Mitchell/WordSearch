namespace WordSearch.Core.Logic.Locations
{
    public class SetLocations
    {
        private readonly Random _random;
        private readonly AssignStartPoint _assignStartPoint;
        private readonly CheckBoundary _checkBoundary;
        private readonly AssignWordCoordinates _assignWordCoordinates;
        private readonly TryWordPlacement _tryWordPlacement;
        public SetLocations(Random random, AssignStartPoint assignStartPoint, CheckBoundary checkBoundary, AssignWordCoordinates assignWordCoordinates, TryWordPlacement tryWordPlacement)
        {
            _random = random;
            _assignStartPoint = assignStartPoint;
            _checkBoundary = checkBoundary;
            _assignWordCoordinates = assignWordCoordinates;
            _tryWordPlacement = tryWordPlacement;
        }

        public bool Locations(List<string> WordsList, List<char[]> Grid)
        {
            int gridSize = Grid.Count;

            for(int i = 0; i < WordsList.Count; i++)
            {
                int wordLength = WordsList[i].Length;

                List<(int, int)> Coordinates = new List<(int, int)>();

                //if(i == 0)
                //{
                //    var(yFirst, xFirst, dFirst) = PlaceFirstWord(gridSize);

                //    Coordinates = _assignWordCoordinates.AssignCoordinates(wordLength, yFirst, xFirst, dFirst);
                //    _tryWordPlacement.TryPlacement(Grid, Coordinates, WordsList[i]);
                //}
                //else if(i > 0)
                //{
                    //int attempts = 0;

                    do{
                        int direction = _random.Next(1, 6);
                        if(direction == 5)
                        {
                            direction = _random.Next(5, 9);
                        }

                        var (yLocation, xLocation) = _assignStartPoint.AssignStart(gridSize);

                        (yLocation, xLocation) = _checkBoundary.Check(wordLength, gridSize, yLocation, xLocation, direction);

                        Coordinates = _assignWordCoordinates.AssignCoordinates(wordLength, yLocation, xLocation, direction);

                        //attempts++;

                    } while(!_tryWordPlacement.TryPlacement(Grid, Coordinates, WordsList[i]));

                    //if(attempts == 5)
                    //{
                    //    return false;
                    //}

                    //attempts = 0;
                //}
            }

            return true;
        }

        //private (int, int, int) PlaceFirstWord(int gridSize)
        //{
        //    (int yFirstLocation, int xFirstLocation, int firstDirection)[] firstLocations = 
        //        { (0, 0, 3), (0, 0, 5), 
        //          (0, gridSize, 7), (0, gridSize, 5), 
        //          (gridSize, gridSize, 1), (gridSize, gridSize, 7), 
        //          (gridSize, 0, 3), (gridSize, 0, 1) };

        //    int x = _random.Next(0, firstLocations.Length);

        //    var (yFirst, xFirst, dFirst) = firstLocations[x];

        //    return (yFirst, xFirst, dFirst);
        //}
    }
}
