using System.Linq.Expressions;
using FilmsAPI_V2.Infrastructure.Data;
using FilmsAPI_V2.Interfaces;

namespace FilmsAPI_V2.Infrastructure.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly AppDbContext _dbContext;
    private DbSet<T> _dbSet;

    public RepositoryBase(AppDbContext dbContext, DbSet<T> dbSet)
    {
        _dbContext = dbContext;
        _dbSet = dbSet;
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
    {
        var query = _dbSet.AsQueryable();

        if (predicate != null)
            query = query
            .Where(predicate)
            .AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<T> GetById(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FindAsync(predicate);
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}