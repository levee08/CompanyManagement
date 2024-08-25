using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T item);
    Task DeleteAsync(int id);
    Task<IQueryable<T>> ReadAllAsync();
    Task<T> ReadAsync(int id);
    Task UpdateAsync(T item);

    
    Task<IQueryable<T>> ReadAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
    Task<T> ReadIncludingAsync(int id, params Expression<Func<T, object>>[] includeProperties);
}
