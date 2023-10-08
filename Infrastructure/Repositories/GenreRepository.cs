using FilmsAPI_V2.DTOs.Genre;
using FilmsAPI_V2.Infrastructure.Data;
using FilmsAPI_V2.Interfaces;
using Mapster;

namespace FilmsAPI_V2.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly AppDbContext _dbContext;
    public GenreRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddGenre(AddGenreDto newGenre)
    {
        var genre = newGenre.Adapt<Genre>();

        await _dbContext.Genres.AddAsync(genre);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddGenres(AddGenreDto[] newGenres)
    {
        var genres = newGenres.Adapt<Genre[]>();

        await _dbContext.Genres.AddRangeAsync(genres);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ServiceResponse<List<GetGenreDto>>> GetAllGenres()
    {
        var serviceResponse = new ServiceResponse<List<GetGenreDto>>();

        var genres = await _dbContext.Genres
            .AsNoTracking()
            .ToListAsync();

        serviceResponse.Data = genres.Adapt<List<GetGenreDto>>();

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetGenreDto>> GetGenreById(int id)
    {
        var serviceResponse = new ServiceResponse<GetGenreDto>();

        var genre = await _dbContext.Genres
            .FindAsync(id);

        serviceResponse.Data = genre.Adapt<GetGenreDto>();

        return serviceResponse;
    }

    public async Task RemoveGenre(int id)
    {
        var serviceResponse = new ServiceResponse<Genre>();

        try
        {
            var genre = await _dbContext.Genres.FindAsync(id);

            if (genre == null)
                throw new Exception("Genre not found!");

            _dbContext.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
    }

    public async Task<ServiceResponse<GetGenreDto>> UpdateGenre(UpdateGenreDto updatedGenre)
    {
        var serviceResponse = new ServiceResponse<GetGenreDto>();
        try
        {
            var genre = await _dbContext.Genres.FindAsync(updatedGenre.GenreId);

            if (genre == null)
                throw new Exception("Genre not found!");

            genre.Adapt<UpdateGenreDto>();

            genre.GenreName = updatedGenre.GenreName;

            await _dbContext.SaveChangesAsync();

            serviceResponse.Data = genre.Adapt<GetGenreDto>();
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}