namespace FilmsAPI_V2.Infrastructure.Configuration.Seeding;

public static class InitialSeeding
{
    public static void Seed(ModelBuilder builder)
    {
        // Actors
        Actor HeatherLangenkamp = new Actor()
        {
            ActorId = 1,
            ActorName = "Heather Langenkamp",
            BirthDate = new DateTime(1964, 7, 17),
            Salary = 1700
        };

        Actor HarrisonFord = new Actor()
        {
            ActorId = 2,
            ActorName = "Harrison Ford",
            BirthDate = new DateTime(1942, 7, 13),
            Salary = 18000
        };

        Actor MarkHamill = new Actor()
        {
            ActorId = 3,
            ActorName = "Mark Hamill",
            BirthDate = new DateTime(1951, 9, 25),
            Salary = 19000
        };

        Actor LouisGossettJr = new Actor()
        {
            ActorId = 4,
            ActorName = "Louis Gossett Jr",
            BirthDate = new DateTime(1936, 5, 27),
            Salary = 20000
        };

        // Movies
        Movie IndianaJones = new Movie()
        {
            MovieId = 1,
            Title = "Indiana Jones",
            IsInCinema = false,
            ReleaseDate = new DateTime(1981, 6, 12)
        };

        Movie ANightmareOnElmStreet = new Movie()
        {
            MovieId = 2,
            Title = "A Nightmare on Elm Street",
            IsInCinema = false,
            ReleaseDate = new DateTime(1981, 6, 12)
        };

        Movie StarWars = new Movie()
        {
            MovieId = 3,
            Title = "Star Wars",
            IsInCinema = false,
            ReleaseDate = new DateTime(1977, 5, 25)
        };

        Movie Jaws3D = new Movie()
        {
            MovieId = 4,
            Title = "Jaws 3D",
            IsInCinema = false,
            ReleaseDate = new DateTime(1981, 7, 22)
        };

        builder.Entity<Actor>().HasData(HeatherLangenkamp, HarrisonFord, MarkHamill, LouisGossettJr);
        builder.Entity<Movie>().HasData(ANightmareOnElmStreet, IndianaJones, StarWars, Jaws3D);
    }
}