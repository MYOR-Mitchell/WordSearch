

using WordSearch.Core.Logic;

namespace Test
{
    public class SetLocationsTest
    {
        private readonly SetLocations _setLocations = new SetLocations(new Random());

        [Fact]  
        public void ShouldReturnLocations()
        {
            var locations = _setLocations.Locations(4, new List<char[]> { new char[] { 'c', 'a', 't' }, new char[] { 'd', 'u', 'c', 'k' } });
            Assert.Equal(2, locations.Item1.Count);
            Assert.Equal(2, locations.Item2.Count);
        }
    }
}
