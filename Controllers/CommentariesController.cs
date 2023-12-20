using FilmsAPI_V2.DTOs.Commentary;
using FilmsAPI_V2.Interfaces;

namespace FilmsAPI_V2.Controllers;

[ApiController]
[Route("api/movies/{movieId}:int/[Controller]")]
public class CommentariesController : ControllerBase
{
    private readonly ICommentaryRepository _repository;
    public CommentariesController(ICommentaryRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(int movieId, CommentaryInput newCommentary)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.AddCommentary(movieId, newCommentary);
        return Ok("Commentary Added!");
    }
}