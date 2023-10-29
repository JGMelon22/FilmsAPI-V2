using FilmsAPI_V2.DTOs.Actor;
using FilmsAPI_V2.Interfaces;

namespace FilmsAPI_V2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorsController : ControllerBase
{
    private readonly IActorRepository _repository;
    public ActorsController(IActorRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var actors = await _repository.GetAllActors();
        return actors.Data != null
            ? Ok(actors)
            : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var actor = await _repository.GetActorById(id);
        return actor.Data != null
            ? Ok(actor)
            : NotFound(actor);
    }

    [HttpGet("name/{actorName}")]
    public async Task<IActionResult> GetActorByName(string actorName)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var actor = await _repository.GetActorByName(actorName);
        return actor.Data != null
            ? Ok(actor)
            : NotFound(actor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddActorDto newActor)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.AddActor(newActor);

        return Ok("New Actor added!");
    }

    [HttpPost("multiple/")]
    public async Task<IActionResult> CreateMultiple(AddActorDto[] newActors)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.AddActors(newActors);
        return Ok("New Actors were added!");
    }

    [HttpPut]
    public async Task<IActionResult> Edit(UpdateActorDto updateActor)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var actor = await _repository.UpdateActor(updateActor);
        return actor.Data != null
            ? Ok(actor)
            : NotFound(actor);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.RemoveActor(id);
        return NoContent();
    }
}