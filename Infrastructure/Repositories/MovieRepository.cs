using System.Data;
using Dapper;
using FilmsAPI_V2.DTOs.Movie;
using FilmsAPI_V2.DTOs.MovieActor;
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

    public async Task<ServiceResponse<List<GetMovieDto>>> GetAllMovies()
    {
        var serviceResponse = new ServiceResponse<List<GetMovieDto>>();
        var movies = await _dbContext.Movies
            .AsNoTracking()
            .ToListAsync();

        serviceResponse.Data = movies.Adapt<List<GetMovieDto>>();

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetMovieDto>> GetMovieById(int id)
    {
        var serviceResponse = new ServiceResponse<GetMovieDto>();

        try
        {
            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie != null)
                serviceResponse.Data = movie.Adapt<GetMovieDto>();

            throw new Exception("Movie not found!");
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

}