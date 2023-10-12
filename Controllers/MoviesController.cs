using FilmsAPI_V2.DTOs.Movie;
using FilmsAPI_V2.Interfaces;

namespace FilmsAPI_V2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _repository;
    public MoviesController(IMovieRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddMovieDto newMovie)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.AddMovie(newMovie);
        return Ok("New Movie added!");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var movies = await _repository.GetAllMovies();
        return movies != null
            ? Ok(movies)
            : NoContent();
    }
}