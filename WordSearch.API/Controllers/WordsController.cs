using Microsoft.AspNetCore.Mvc;
using WordSearch.Core.Model;
using WordSearch.Core.Interfaces;

namespace WordSearch.API.Controllers
{
    [ApiController]
    [Route("api/wordsearch")]
    public class WordsController : ControllerBase
    {
        private readonly ICreatePuzzle _createPuzzle;

        public WordsController(ICreatePuzzle createPuzzle)
        {
            _createPuzzle = createPuzzle;
        }

        [HttpPost]
        public IActionResult GenerateWordSearch([FromBody] WordSearchModel wordSearch)
        {
            if(wordSearch?.Words == null || !wordSearch.Words.Any() || wordSearch.GridSize < 3)
            {
                return BadRequest(new { message = "Invalid input. Please check your words and grid size." });
            }

            foreach(var word in wordSearch.Words)
            {
                if(word.Length > wordSearch.GridSize)
                {
                    return BadRequest(new { message = "Words cannot be larger than the grid size." });
                }
            }

            int gridCells = wordSearch.GridSize * wordSearch.GridSize;
            int wordCharacters = 0;

            foreach(var word in wordSearch.Words)
            {
                wordCharacters += word.Length;
            }

            if(wordCharacters > gridCells * 0.75)
                return BadRequest(new { message = "Total word character count exceeded." });

            var (success, puzzle) = _createPuzzle.Create(wordSearch);

            if(!success)
            {
                return BadRequest(new { message = "Unable to create puzzle, please try again." });
            }

            return Ok(puzzle);
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}
