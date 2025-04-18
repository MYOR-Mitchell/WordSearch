namespace WordSearch.Core.Logic.Locations
{
    public class AssignWordCoordinates
    {
        public List<(int, int)> AssignCoordinates(int wordLength, int yLocation, int xLocation, int direction)
        {
            List<(int, int)> Coordinates = new List<(int, int)>();

            for(int i = 0; i < wordLength; i++)
            {
                if(direction == 1) // Up
                {
                    Coordinates.Add((yLocation - i, xLocation));
                }
                else if(direction == 2) // Up, Right
                {
                    Coordinates.Add((yLocation - i, xLocation + i));
                }
                else if(direction == 3) // Right
                {
                    Coordinates.Add((yLocation, xLocation + i));
                }
                else if(direction == 4) // Down, Right
                {
                    Coordinates.Add((yLocation + i, xLocation + i));
                }
                else if(direction == 5) // Down
                {
                    Coordinates.Add((yLocation + i, xLocation));
                }
                else if(direction == 6) // Down, Left
                {
                    Coordinates.Add((yLocation + i, xLocation - i));
                }
                else if(direction == 7) // Left
                {
                    Coordinates.Add((yLocation, xLocation - i));
                }
                else if(direction == 8) // Up, Left
                {
                    Coordinates.Add((yLocation - i, xLocation - i));
                }
            }

            return Coordinates;
        }
    }
}

