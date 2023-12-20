using FilmsAPI_V2.DTOs.Actor;
using FilmsAPI_V2.Infrastructure.Validators;
using FilmsAPI_V2.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace FilmsAPI_V2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActorsController : ControllerBase
{
    private readonly IActorRepository _repository;
    private readonly IValidator<ActorInput> _actorInputValidator;
    public ActorsController(IActorRepository repository, IValidator<ActorInput> actorInputValidator)
    {
        _repository = repository;
        _actorInputValidator = actorInputValidator;
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ActorInput newActor)
    {
        ValidationResult validatorResult = await _actorInputValidator.ValidateAsync(newActor);

        if (!validatorResult.IsValid)
            return BadRequest(string.Join(',', validatorResult.Errors));


        await _repository.AddActor(newActor);

        return Ok("New Actor added!");
    }

    [HttpPost("multiple/")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateMultiple(ActorInput[] newActors)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await _repository.AddActors(newActors);
        return Ok("New Actors were added!");
    }

    [HttpPut]
    public async Task<IActionResult> Edit(int id, ActorInput updatedActor)
    {
        ValidationResult validatorResult = await _actorInputValidator.ValidateAsync(updatedActor);

        if (!validatorResult.IsValid)
            return BadRequest(string.Join(',', validatorResult.Errors));

        var actor = await _repository.UpdateActor(id, updatedActor);
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