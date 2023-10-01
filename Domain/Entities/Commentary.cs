namespace FilmsAPI_V2.Domain.Entities;

public class Commentary
{
    public int CommentaryId { get; set; }
    public string? Content { get; set; } 
    public bool Recommend { get; set; }
    public int MovieId { get; set; } // One-To-Many
    public Movie Movie { get; set; }
}