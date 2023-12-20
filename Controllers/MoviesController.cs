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
    public async Task<IActionResult> Create(MovieInput newMovie)
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

    [HttpGet("{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var movie = await _repository.GetMovieById(id);
        return movie.Data != null
            ? Ok(movie)
            : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id, MovieInput updatedMovie)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var movie = await _repository.UpdateMovie(id, updatedMovie);
        return movie.Data != null
            ? Ok(movie)
            : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.RemoveMovie(id);
        return NoContent();
    }
}