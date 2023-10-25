using FilmsAPI_V2.DTOs.Movie;

namespace FilmsAPI_V2.Interfaces;

public interface IMovieRepository
{
    Task<ServiceResponse<List<GetMovieDto>>> GetAllMovies();
    Task<ServiceResponse<GetMovieDto>> GetMovieById(int id);
    Task AddMovie(AddMovieDto newMovie);
    Task<ServiceResponse<GetMovieDto>> UpdateMovie(UpdateMovieDto updatedMovie);
    Task RemoveMovie(int id);
}