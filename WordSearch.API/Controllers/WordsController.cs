using Microsoft.AspNetCore.Mvc;
using WordSearch.Core.Model;
using WordSearch.Core.Logic.Interface;

namespace WordSearch.API.Controllers
{
    [Route("api/wordsearch")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ICreateCustomPuzzle _customPuzzle;

        public WordsController(ICreateCustomPuzzle customPuzzle)
        {
            _customPuzzle = customPuzzle;
        }

        [HttpPost]
        public IActionResult GenerateWordSearch([FromBody] WordSearchModel wordSearch)
        {
            if(wordSearch == null || wordSearch.Words == null || wordSearch.Words.Count <= 0 || wordSearch.Words.Count > wordSearch.GridSize)
            {
                return BadRequest(new { message = "Invalid list, please try again." });
            }

            if(wordSearch.GridSize < 5 || wordSearch.GridSize > 15)
            {
                return BadRequest(new { message = "Invalid gridsize, please try again." });
            }

            foreach(var word in wordSearch.Words)
            {
                string tWord = word?.Trim();
                if(string.IsNullOrEmpty(tWord) || tWord.Length < 3 || tWord.Length > wordSearch.GridSize)
                {
                    return BadRequest(new { message = "Invalid list, please try again." });
                }
            }

            var puzzle = _customPuzzle.Create(wordSearch);

            return Ok(puzzle);
        }
    }
}
