using FilmsAPI_V2.DTOs.Genre;

namespace FilmsAPI_V2.Interfaces;

public interface IGenreRepository
{
    Task<ServiceResponse<List<GenreResult>>> GetAllGenres();
    Task<ServiceResponse<GenreResult>> GetGenreById(int id);
    Task AddGenre(GenreInput newGenre);
    Task AddGenres(GenreInput[] newGenres);
    Task<ServiceResponse<GenreResult>> UpdateGenre(UpdateGenreDto updatedGenre);
    Task RemoveGenre(int id);
}