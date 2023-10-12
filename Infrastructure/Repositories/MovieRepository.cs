using FilmsAPI_V2.DTOs.Movie;
using FilmsAPI_V2.Infrastructure.Data;
using FilmsAPI_V2.Interfaces;
using Mapster;

namespace FilmsAPI_V2.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _dbContext;
    public MovieRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddMovie(AddMovieDto newMovie)
    {
        var movie = newMovie.Adapt<Movie>();

        // https://learn.microsoft.com/en-us/ef/ef6/saving/change-tracking/entity-state
        /* the entity is being tracked by the context and exists in the database,
        and its property values have not changed from the values in the database
        */
        if (movie.Genres != null)
        {
            foreach (var genre in movie.Genres)
            {
                _dbContext.Entry(genre).State = EntityState.Unchanged;
            }
        }

        // Increment actors order field based on received order
        // eg: Actor A was inserted, so it's order will be 1
        if (movie.MoviesActors != null)
        {
            for (int i = 0; i < movie.MoviesActors.Count; i++)
            {
                movie.MoviesActors[i].Order = i++;
            }
        }

        await _dbContext.Movies.AddAsync(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Movie>> GetAllMovies()
    {
        return await _dbContext.Movies
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<Movie> GetMovieById(int id)
    {
        throw new NotImplementedException();
    }
}