using System.Data;
// using Dapper;
using FilmsAPI_V2.DTOs.Genre;
using FilmsAPI_V2.Infrastructure.Data;
using FilmsAPI_V2.Interfaces;
using Mapster;

namespace FilmsAPI_V2.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IDbConnection _dbConnection;

    public GenreRepository(AppDbContext dbContext, IDbConnection dbConnection)
    {
        _dbContext = dbContext;
        _dbConnection = dbConnection;

    }

    public async Task AddGenre(GenreInput newGenre)
    {
        var genre = newGenre.Adapt<Genre>();

        await _dbContext.Genres.AddAsync(genre);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddGenres(GenreInput[] newGenres)
    {
        var genres = newGenres.Adapt<Genre[]>();

        await _dbContext.Genres.AddRangeAsync(genres);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<ServiceResponse<List<GenreResult>>> GetAllGenres()
    {
        var serviceResponse = new ServiceResponse<List<GenreResult>>();

        try
        {
            var genres = await _dbContext.Database.SqlQueryRaw<GenreResult>(
            """
            SELECT genre_id AS GenreId, 
                   genre_name AS GenreName
            FROM genres;
            """
                   ).ToListAsync();

            serviceResponse.Data = genres.Adapt<List<GenreResult>>();
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GenreResult>> GetGenreById(int id)
    {
        var serviceResponse = new ServiceResponse<GenreResult>();

        try
        {
            var genre = await _dbContext.Genres
                        .FindAsync(id);

            if (genre != null)
                serviceResponse.Data = genre.Adapt<GenreResult>();

            else
                throw new Exception("Genre not found!");
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

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

    public async Task<ServiceResponse<GenreResult>> UpdateGenre(int id, GenreInput updatedGenre)
    {
        var serviceResponse = new ServiceResponse<GenreResult>();
        try
        {
            var genre = await _dbContext.Genres.FindAsync(id);

            if (genre == null)
                throw new Exception("Genre not found!");

            genre.GenreName = updatedGenre.GenreName;

            await _dbContext.SaveChangesAsync();

            serviceResponse.Data = genre.Adapt<GenreResult>();
        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}