using WordSearch.Core.Logic;

namespace Test
{
    public class CreateGridTest
    {
        private readonly CreateGrid createGrid = new CreateGrid();

        [Theory]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(14)]
        public void ShouldReturnRequestedGridSize(int x)
        {
            var Rows = createGrid.CreateRows(x);

            Assert.Equal(x, Rows.Count);

            foreach(var row in Rows)
            {
                Assert.Equal(x, row.Length);
            }
        }
    }
}