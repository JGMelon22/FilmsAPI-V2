using FilmsAPI_V2.DTOs.Commentary;
using FilmsAPI_V2.Infrastructure.Data;
using FilmsAPI_V2.Interfaces;
using Mapster;

namespace FilmsAPI_V2.Infrastructure.Repositories;

public class CommentaryRepository : ICommentaryRepository
{
    private readonly AppDbContext _dbContext;
    public CommentaryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCommentary(int movieId, AddCommentaryDto newCommentary)
    {
        var commentary = newCommentary.Adapt<Commentary>();
        commentary.MovieId = movieId;

        await _dbContext.AddAsync(commentary);
        await _dbContext.SaveChangesAsync();
    }
}