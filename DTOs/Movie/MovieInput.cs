using FilmsAPI_V2.DTOs.MovieActor;

namespace FilmsAPI_V2.DTOs.Movie;

public record MovieInput()
{
    public string Title { get; init; } = null!;
    public bool IsInCinema { get; init; }
    public DateTime ReleaseDate { get; init; }
    public List<int> Genres { get; init; } = new List<int>();
    public List<MovieActorInput> MoviesActors { get; init; } = new List<MovieActorInput>();
}