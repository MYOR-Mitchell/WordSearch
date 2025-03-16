
namespace WordSearch.Core.Logic
{
    public class SetLocations
    {
        private readonly Random _random;
        public SetLocations(Random random)
        {
            _random = random;
        }

        public List<List<(int, int)>> Locations(List<string> wordsList) //Holly molly, this is a mess.  I need to break this down.
        {
            List<List<(int, int)>> letterCoordinates = new List<List<(int, int)>>(); //return list coordinates.
            int gridSize = wordsList.Count; //Assign name for better visually unimpairness.

            for(int i = 0; i < wordsList.Count; i++)
            {
                int direction = 1;
                int diagnolDirection = 1;

                (int xLocation, int yLocation) = AssignStartPoint(gridSize);  //Set our starting point

                if(direction == 1)
                {
                    xLocation = AccountForBoundaryHorizontal(wordsList[i], gridSize, xLocation); //ensure we're inbounds
                    List<(int, int)> tempCoordinates = AssignLetterLocations(wordsList[i], direction, diagnolDirection, xLocation, yLocation); //assign the coordinates to each letter

                    if(letterCoordinates.Count > 0) //skip first word, nothing to overlap with
                    {
                        while(!CheckForOverlap(letterCoordinates)) //check for overlap
                        {
                            AdjustLocation(letterCoordinates, xLocation, yLocation); //adjust location if overlap
                        }
                    }

                    letterCoordinates.Add(tempCoordinates); //add the coordinates to the list
                    direction = 2; //rotate direction
                }
                else if(direction == 2)
                {
                    yLocation = AccountForBoundaryVertical(wordsList[i], gridSize, yLocation);
                    direction = 3;
                }
                else if(direction == 3 && diagnolDirection == 1)
                {
                    (xLocation, yLocation) = AccountForBoundaryDiagnolRight(wordsList[i], gridSize, xLocation, yLocation);
                    direction = 1;
                    diagnolDirection = 2;
                }
                else if(direction == 3 && diagnolDirection == 2)
                {
                    (xLocation, yLocation) = AccountForBoundaryDiagnolLeft(wordsList[i], gridSize, xLocation, yLocation);
                    direction = 1;
                    diagnolDirection = 1;
                }

            }

            return letterCoordinates;
        }



        private (int, int) AssignStartPoint(int gridSize)
        {
            int xLocation = _random.Next(0, gridSize);
            int yLocation = _random.Next(0, gridSize);
            return (xLocation, yLocation);
        }

        private int AccountForBoundaryHorizontal(string word, int gridSize, int xLocation)
        {
            if(word.Length > (gridSize - xLocation))
            {
                xLocation = xLocation - word.Length;
            }

            return xLocation;
        }

        private int AccountForBoundaryVertical(string word, int gridSize, int yLocation)
        {
            if(word.Length > (gridSize - yLocation))
            {
                yLocation = yLocation - word.Length;
            }

            return yLocation;
        }

        private (int, int) AccountForBoundaryDiagnolRight(string word, int gridSize, int xLocation, int yLocation)   
        {
            if(word.Length > (gridSize - (xLocation / 2)) && word.Length > (gridSize - yLocation) && gridSize % 2 == 0)
            {
                xLocation = xLocation - (word.Length / 2);
                yLocation = yLocation - (word.Length / 2);
            }
            else if(word.Length > (gridSize - (xLocation / 2)) && gridSize % 2 != 0)
            {
                xLocation = xLocation - (word.Length / 2) - 1;
            }
            else if(word.Length > (gridSize - yLocation) && gridSize % 2 != 0) 
            {
                yLocation = yLocation - (word.Length / 2) - 1; 
            }

            return (xLocation, yLocation);
        }

        private (int, int) AccountForBoundaryDiagnolLeft(string word, int gridSize, int xLocation, int yLocation)
        {
            if(word.Length < (gridSize - xLocation) && word.Length < (gridSize - yLocation) && gridSize % 2 == 0)
            {
                xLocation = xLocation - (word.Length / 2);
                yLocation = yLocation - (word.Length / 2);
            }
            else if(word.Length < (gridSize - (xLocation / 2)) && gridSize % 2 != 0)
            {
                xLocation = xLocation + (word.Length / 2) + 1;
            }
            else if(word.Length < (gridSize - yLocation) && gridSize % 2 != 0)
            {
                yLocation = yLocation + (word.Length / 2) + 1;
            }

            return (xLocation, yLocation);
        }

        private List<(int, int)> AssignLetterLocations(string word, int direction, int diagnolDirection, int xLocation, int yLocation)
        {
            List<(int, int)> letterCoordinates = new List<(int, int)>();

            for(int i = 0; i < word.Length; i++)
            {
                if(direction == 1)
                {
                    letterCoordinates.Add((xLocation + i, yLocation));
                }
                else if(direction == 2)
                {
                    letterCoordinates.Add((xLocation, yLocation + i));
                }
                else if(direction == 3 && diagnolDirection == 1)
                {
                    letterCoordinates.Add((xLocation + i, yLocation + i));
                }
                else if(direction == 3 && diagnolDirection == 2)
                {
                    letterCoordinates.Add((xLocation - i, yLocation + i));
                }
            }

            return letterCoordinates;
        }

        private bool CheckForOverlap(List<List<(int, int)>> letterCoordinates)
        {
            for(int i = 0; i < letterCoordinates.Count; i++) //Stationary outer layer
            {
                for(int j = i + 1; j < letterCoordinates.Count; j++)  //Rotatating outer layer
                {
                    int overlapCount = 0;

                    foreach(var coord1 in letterCoordinates[i])  //Stationary inner layer
                    {
                        foreach(var coord2 in letterCoordinates[j])  //Rotating inner layer
                        {
                            if(coord1 == coord2)  
                            {
                                overlapCount++;
                            }
                        }
                    }

                    if(overlapCount > 2)  
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void AdjustLocation(List<List<(int, int)>> letterCoordinates, int xLocation, int yLocation)
        {
            //Use int a = 1 or something for adjustments.  makes it easier to adjust.   <--- wtf did I say?  o.0"

            //Somewhere in the adjustments I have to account for pushing the word out of bounds, horizontally--
                //if xLocation is 0, moving left is no longer an option.  Need to account for minDistance from either edge of the grid and trasition logic appropriately.

            //Horizontal adjustment thought: int i = 1; xLocation - [i] -> xLocation + [i], i++, repeat until no overlap or we reach the end of the grid.
                //In some cases having to adjust y position.
            //Extended thought: shifting y position would potentially be a faster fix--depending on overlap amount..
                //Do I not stop at overlapCount > 2?  get full overlap count, so if overlap is...say 4: My adjustments should start a minimal transition of 2 spaces.
        }

        //!Remember to add reverse words back in--This simulates the same effect of the excluded directions left and down!  
    }
}
