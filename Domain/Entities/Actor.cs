namespace FilmsAPI_V2.Domain.Entities;

public class Actor
{
    public int ActorId { get; set; }
    public string ActorName { get; set; } = null!;
    public decimal Salary { get; set; }
    public DateTime BirthDate { get; set; }
    public List<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}