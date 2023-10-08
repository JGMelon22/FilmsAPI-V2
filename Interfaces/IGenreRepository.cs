using FilmsAPI_V2.DTOs.Genre;

namespace FilmsAPI_V2.Interfaces;

public interface IGenreRepository
{
    Task<ServiceResponse<List<GetGenreDto>>> GetAllGenres();
    Task<ServiceResponse<GetGenreDto>> GetGenreById(int id);
    Task AddGenre(AddGenreDto newGenre);
    Task AddGenres(AddGenreDto[] newGenres);
    Task<ServiceResponse<GetGenreDto>> UpdateGenre(UpdateGenreDto updatedGenre);
    Task RemoveGenre(int id);
}