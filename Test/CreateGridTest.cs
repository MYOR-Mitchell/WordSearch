using WordSearch.Core.Logic;

namespace Test
{
    public class CreateGridTest
    {
        private readonly CreateGrid _createGrid = new CreateGrid();

        [Theory]
        [InlineData(12)]
        [InlineData(14)]
        [InlineData(16)]
        public void ShouldReturnRequestedGridSize(int x)
        {
            var Rows = _createGrid.Grid(x);

            Assert.Equal(x, Rows.Count);

            foreach(var row in Rows)
            {
                Assert.Equal(x, row.Length);
            }
        }
    }
}