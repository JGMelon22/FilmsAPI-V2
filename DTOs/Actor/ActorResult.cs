namespace FilmsAPI_V2.DTOs.Actor;

public record GetActorDto(int ActorId, string ActorName, decimal Salary, DateTime BirthDate);