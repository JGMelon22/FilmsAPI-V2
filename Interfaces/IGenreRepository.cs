namespace FilmsAPI_V2.Interfaces;

public interface IGenreRepository
{
    Task<ServiceResponse<List<Genre>>> GetAllGenres();
    Task<ServiceResponse<Genre>> GetGenreById(int id);
    Task AddGenre(Genre genre);
    Task AddGenres(Genre[] genre);
    Task<ServiceResponse<Genre>> UpdateGenre(Genre genre);
    Task RemoveGenre(int id);
}