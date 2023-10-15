namespace FilmsAPI_V2.DTOs.MovieActor;

public record GetMovieActorDto
(
    int MovieId, string MovieTitle, bool IsInCinema, DateTime ReleaseDate,
    int ActorId, string ActorName, decimal Salary, DateTime BirthDate,
    string Character
);