using FilmsAPI_V2.DTOs.Actor;

namespace FilmsAPI_V2.Interfaces;

public interface IActorRepository
{
    Task<ServiceResponse<List<GetActorDto>>> GetAllActors();
    Task<ServiceResponse<GetActorDto>> GetActorById(int id);
    Task AddActor(AddActorDto newActor);
    Task AddActors(AddActorDto[] newActors);
    Task<ServiceResponse<GetActorDto>> UpdateActor(UpdateActorDto updateActor);
    Task RemoveActor(int id);
}