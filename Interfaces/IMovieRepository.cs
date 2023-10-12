using FilmsAPI_V2.DTOs.Movie;

namespace FilmsAPI_V2.Interfaces;

public interface IMovieRepository
{
    Task<List<Movie>> GetAllMovies();
    Task<Movie> GetMovieById(int id);
    Task AddMovie(AddMovieDto newMovie);
}