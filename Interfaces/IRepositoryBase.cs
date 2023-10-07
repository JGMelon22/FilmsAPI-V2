using System.Linq.Expressions;

namespace FilmsAPI_V2.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);
    Task<T> GetById(Expression<Func<T, bool>> predicate);
    Task Add(T entity);
    Task Delete(T entity);
    Task Update(T entity);
}