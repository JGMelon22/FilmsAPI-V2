using FilmsAPI_V2.DTOs.Genre;
using FilmsAPI_V2.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace FilmsAPI_V2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IGenreRepository _repository;
    private readonly IValidator<GenreInput> _genreInputValidator;

    public GenresController(IGenreRepository repository, IValidator<GenreInput> genreInputValidator)
    {
        _repository = repository;
        _genreInputValidator = genreInputValidator;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GenreInput newGenre)
    {
        ValidationResult validatorResult = await _genreInputValidator.ValidateAsync(newGenre);

        if (!validatorResult.IsValid)
            return BadRequest(string.Join(',', validatorResult.Errors));

        await _repository.AddGenre(newGenre);
        return Ok("New Genre added!");
    }

    [HttpPost("multiple/")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateMultiple(GenreInput[] newGenres)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.AddGenres(newGenres);
        return Ok("New Genres were added!");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var genres = await _repository.GetAllGenres();
        return genres.Data != null
            ? Ok(genres)
            : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var genre = await _repository.GetGenreById(id);
        return genre.Data != null
            ? Ok(genre)
            : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> Edit(int id, GenreInput updatedGenre)
    {
        ValidationResult validatorResult = await _genreInputValidator.ValidateAsync(updatedGenre);

        if (!validatorResult.IsValid)
            return BadRequest(string.Join(',', validatorResult.Errors));

        var genre = await _repository.UpdateGenre(id, updatedGenre);
        return genre.Data != null
            ? Ok(genre)
            : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.RemoveGenre(id);
        return NoContent();
    }
}