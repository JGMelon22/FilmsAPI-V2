using FilmsAPI_V2.DTOs.Actor;

namespace FilmsAPI_V2.Interfaces;

public interface IActorRepository
{
    Task<ServiceResponse<List<ActorResult>>> GetAllActors();
    Task<ServiceResponse<ActorResult>> GetActorById(int id);
    Task<ServiceResponse<ActorResult>> GetActorByName(string actorName);
    Task AddActor(ActorInput newActor);
    Task AddActors(ActorInput[] newActors);
    Task<ServiceResponse<ActorResult>> UpdateActor(UpdateActorDto updateActor);
    Task RemoveActor(int id);
}