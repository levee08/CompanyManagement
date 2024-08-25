using CompanyManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class GenericRepo<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;

    public GenericRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T item)
    {
        await _context.Set<T>().AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await ReadAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public virtual async Task<IQueryable<T>> ReadAllAsync()
    {
        return await Task.FromResult(_context.Set<T>());
    }

    public virtual async Task<T> ReadAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task UpdateAsync(T item)
    {
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }



    public async Task<IQueryable<T>> ReadAllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        return await Task.FromResult(query);
    }

    
    public virtual async Task<T> ReadIncludingAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>();
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }
}
