using FilmsAPI_V2.DTOs.Movie;

namespace FilmsAPI_V2.Interfaces;

public interface IMovieRepository
{
    Task<ServiceResponse<List<MovieResult>>> GetAllMovies();
    Task<ServiceResponse<MovieResult>> GetMovieById(int id);
    Task AddMovie(MovieInput newMovie);
    Task<ServiceResponse<MovieResult>> UpdateMovie(UpdateMovieDto updatedMovie);
    Task RemoveMovie(int id);
}