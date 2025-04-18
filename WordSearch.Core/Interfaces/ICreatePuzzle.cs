using WordSearch.Core.Model;

namespace WordSearch.Core.Interfaces
{
    public interface ICreatePuzzle
    {
        (bool, List<char[]>) Create(WordSearchModel wordSearch);
    }
}