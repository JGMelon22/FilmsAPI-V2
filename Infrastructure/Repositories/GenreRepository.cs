using System.Data;
using Dapper;
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

        var getGenresQuery = @"SELECT genre_id AS GenreId, 
                                      genre_name AS GenreName
                               FROM genres;";

        _dbConnection.Open();

        var result = await _dbConnection.QueryAsync<GetGenreDto>(getGenresQuery);

        serviceResponse.Data = result.Adapt<List<GetGenreDto>>().ToList();

        _dbConnection.Close();

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetGenreDto>> GetGenreById(int id)
    {
        var serviceResponse = new ServiceResponse<GetGenreDto>();

        try
        {
            var genre = await _dbContext.Genres
                        .FindAsync(id);

            if (genre != null)
                serviceResponse.Data = genre.Adapt<GetGenreDto>();

            else
                throw new Exception("Actor not found!");
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