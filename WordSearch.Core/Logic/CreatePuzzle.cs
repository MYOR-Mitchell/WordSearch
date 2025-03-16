using WordSearch.Core.Logic.Interface;
using WordSearch.Core.Model;

namespace WordSearch.Core.Logic
{
    public class CreatePuzzle : ICreateCustomPuzzle
    {
        private readonly SetLocations _setLocations;
        private readonly CreateGrid _createGrid;
        public CreatePuzzle(SetLocations setLocations, CreateGrid createGrid)
        {
            _setLocations = setLocations;
            _createGrid = createGrid;
        }

        public List<char[]> Create(WordSearchModel wordSearch)
        {
            List<char[]> grid = _createGrid.Grid(wordSearch.GridSize);
            List<List<(int, int)>> coordinates = _setLocations.Locations(wordSearch.Words);

            return grid;
        }
    }
}


/*
 * To-do:
 * - Add the dto to the controller.
 * - Break down SetLocations class.  Whoops.
 * - Add logic to reverse a 3rd or something of the words--Simulate excluded directions left and down
 * - Implement update test after overhaul.
 *  
 * Less immediate to-do:
 * - Implement the db, and refactor accordingly.
 * - Predefined categories with list of related words
 * - Extend custom puzzle options back to full involvement... 
 */