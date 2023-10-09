namespace FilmsAPI_V2.DTOs.Actor;

public record UpdateActorDto(int ActorId, string ActorName, decimal Salary, DateTime BirthDate);