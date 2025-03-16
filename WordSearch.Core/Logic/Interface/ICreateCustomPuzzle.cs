using WordSearch.Core.Model;

namespace WordSearch.Core.Logic.Interface
{
    public interface ICreateCustomPuzzle
    {
        List<char[]> Create(WordSearchModel wordSearch);
    }
}