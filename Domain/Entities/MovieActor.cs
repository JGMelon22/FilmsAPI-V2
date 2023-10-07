namespace FilmsAPI_V2.Domain.Entities;

public class MovieActor
{
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
    public int ActorId { get; set; }
    public Actor Actor { get; set; } = null!;
    public string Character { get; set; } = null!;
    public int Order { get; set; } // Eg: side actor, leading actor
}