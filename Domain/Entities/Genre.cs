namespace FilmsAPI_V2.Domain.Entities;

public class Genre
{
    public int GenreId { get; set; }
    public string GenreName { get; set; } = null!;

    // Many-To-Many with navigation properties
    public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
}