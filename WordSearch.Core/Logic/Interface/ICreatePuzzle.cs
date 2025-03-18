using WordSearch.Core.Model;

namespace WordSearch.Core.Logic.Interface
{
    public interface ICreatePuzzle
    {
        (bool, List<char[]>) Create(WordSearchModel wordSearch);
    }
}