using WordSearch.Core;

namespace Test
{
    public class CreateGridTest
    {
        private readonly CreateGrid _createGrid = new CreateGrid();

        [Fact]
        public void ShouldReturnTenByTenGrid()
        {
            var Rows = _createGrid.CreateRows();

            Assert.Equal(10, Rows.Count);

            foreach(var row in Rows)
            {
                Assert.Equal(10, row.Count);
            }
        }
    }
}