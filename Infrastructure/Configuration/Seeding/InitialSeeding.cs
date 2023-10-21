namespace FilmsAPI_V2.Infrastructure.Configuration.Seeding;

public static class InitialSeeding
{
    public static void Seed(ModelBuilder builder)
    {
        // Genres
        Genre adventure = new Genre()
        {
            GenreId = 1,
            GenreName = "Adventure"
        };


        Genre horror = new Genre()
        {
            GenreId = 2,
            GenreName = "Horror"
        };

        Genre sciFi = new Genre()
        {
            GenreId = 3,
            GenreName = "Sci Fi"
        };

        // Actors
        Actor heatherLangenkamp = new Actor()
        {
            ActorId = 1,
            ActorName = "Heather Langenkamp",
            BirthDate = new DateTime(1964, 7, 17),
            Salary = 1700
        };

        Actor harrisonFord = new Actor()
        {
            ActorId = 2,
            ActorName = "Harrison Ford",
            BirthDate = new DateTime(1942, 7, 13),
            Salary = 18000
        };

        Actor markHamill = new Actor()
        {
            ActorId = 3,
            ActorName = "Mark Hamill",
            BirthDate = new DateTime(1951, 9, 25),
            Salary = 19000
        };

        Actor louisGossettJr = new Actor()
        {
            ActorId = 4,
            ActorName = "Louis Gossett Jr",
            BirthDate = new DateTime(1936, 5, 27),
            Salary = 20000
        };

        // Movies
        Movie indianaJones = new Movie()
        {
            MovieId = 1,
            Title = "Indiana Jones",
            IsInCinema = false,
            ReleaseDate = new DateTime(1981, 6, 12)
        };

        Movie aNightmareOnElmStreet = new Movie()
        {
            MovieId = 2,
            Title = "A Nightmare on Elm Street",
            IsInCinema = false,
            ReleaseDate = new DateTime(1981, 6, 12)
        };

        Movie starWars = new Movie()
        {
            MovieId = 3,
            Title = "Star Wars",
            IsInCinema = false,
            ReleaseDate = new DateTime(1977, 5, 25)
        };

        Movie jawsThree = new Movie()
        {
            MovieId = 4,
            Title = "Jaws 3D",
            IsInCinema = false,
            ReleaseDate = new DateTime(1981, 7, 22)
        };

        // Commentaries
        Commentary firstCommentary = new Commentary()
        {
            CommentaryId = 1,
            Recommend = true,
            Content = "Superb!",
            MovieId = indianaJones.MovieId
        };

        Commentary secondCommentary = new Commentary()
        {
            CommentaryId = 2,
            Recommend = true,
            Content = "Wes Craven rocks!",
            MovieId = aNightmareOnElmStreet.MovieId
        };

        Commentary thirdCommentary = new Commentary()
        {
            CommentaryId = 3,
            Recommend = false,
            Content = "A heave decline on Jaws saga",
            MovieId = jawsThree.MovieId
        };

        Commentary fourthCommentary = new Commentary()
        {
            CommentaryId = 4,
            Recommend = true,
            Content = "Light Sabers are the future!",
            MovieId = starWars.MovieId
        };

        #region
        // Many-to-Many data insert (without intermediate entity)
        // GenreMovie
        string tableGenreMovie = "GenreMovie";
        string genresGenreIdProperty = "GenresGenreId";
        string moviesMovieIdProperty = "MoviesMovieId";
        int adventureGenre = 1;
        int horrorGenre = 2;
        int sciFiGenre = 3;

        builder.Entity(tableGenreMovie).HasData(
            new Dictionary<string, object>
            {
                [genresGenreIdProperty] = adventureGenre,
                [moviesMovieIdProperty] = indianaJones.MovieId
            },

            new Dictionary<string, object>
            {
                [genresGenreIdProperty] = horrorGenre,
                [moviesMovieIdProperty] = aNightmareOnElmStreet.MovieId
            },

             new Dictionary<string, object>
             {
                 [genresGenreIdProperty] = horrorGenre,
                 [moviesMovieIdProperty] = jawsThree.MovieId
             },

            new Dictionary<string, object>
            {
                [genresGenreIdProperty] = sciFiGenre,
                [moviesMovieIdProperty] = starWars.MovieId
            }
        );
        # endregion

        // Many-to-Many data insert (with intermediate entity)
        // MovieActor
        MovieActor heatherLangenkampAnightmareOnElmStreet = new MovieActor()
        {
            ActorId = heatherLangenkamp.ActorId,
            MovieId = aNightmareOnElmStreet.MovieId,
            Order = 1,
            Character = "Nancy Thompson"
        };

        MovieActor harrisonFordIndianaJones = new MovieActor()
        {
            ActorId = harrisonFord.ActorId,
            MovieId = indianaJones.MovieId,
            Order = 2,
            Character = "Indiana Jones"
        };

        MovieActor markHamillStarWars = new MovieActor()
        {
            ActorId = markHamill.ActorId,
            MovieId = starWars.MovieId,
            Order = 3,
            Character = "Luke SkyWalker"
        };

        MovieActor louisGossettJrJawsThree = new MovieActor()
        {
            ActorId = louisGossettJr.ActorId,
            MovieId = jawsThree.MovieId,
            Order = 4,
            Character = "Calvin Bouchard"
        };

        builder.Entity<Genre>().HasData(adventure, horror, sciFi);
        builder.Entity<Actor>().HasData(heatherLangenkamp, harrisonFord, markHamill, louisGossettJr);
        builder.Entity<Movie>().HasData(aNightmareOnElmStreet, indianaJones, starWars, jawsThree);
        builder.Entity<Commentary>().HasData(firstCommentary, secondCommentary, thirdCommentary, fourthCommentary);
        builder.Entity<MovieActor>().HasData(heatherLangenkampAnightmareOnElmStreet, harrisonFordIndianaJones, markHamillStarWars, louisGossettJrJawsThree);
    }
}