namespace FilmsAPI_V2.Domain.Entities;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; } = null!;
    public bool IsInCinema { get; set; }
    public DateTime ReleaseDate { get; set; }
    public HashSet<Commentary> Commentaries { get; set; } = new HashSet<Commentary>(); // One-to-Many
}