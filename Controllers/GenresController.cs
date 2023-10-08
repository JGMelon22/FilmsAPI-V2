using FilmsAPI_V2.DTOs.Genre;
using FilmsAPI_V2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FilmsAPI_V2.Controllers;

[ApiController]
[Route("api/controller")]
public class GenresController : ControllerBase
{
    private readonly IGenreRepository _repository;
    public GenresController(IGenreRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddGenreDto newGenre)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.AddGenre(newGenre);
        return Ok("New Genre added!");
    }

    [HttpPost("multiple/")]
    public async Task<IActionResult> CreateMultiple(AddGenreDto[] newGenres)
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
    public async Task<IActionResult> Edit(UpdateGenreDto updatedGenre)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var genre = await _repository.UpdateGenre(updatedGenre);
        return genre.Data != null
            ? Ok(genre)
            : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.RemoveGenre(id);
        return NoContent();
    }
}