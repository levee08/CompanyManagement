using CompanyManagement.Data;

namespace CompanyManagement.Repository
{
    public abstract class GenericRepo<T> : IRepository<T> where T : class
    {

        protected readonly AppDbContext ctx;

        public GenericRepo(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task CreateAsync(T item)
        {
            await ctx.Set<T>().AddAsync(item);
            await ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await ReadAsync(id);
            if (entity != null)
            {
                ctx.Set<T>().Remove(entity);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<T>> ReadAllAsync()
        {
            return await Task.FromResult(ctx.Set<T>());
        }

        public abstract Task<T> ReadAsync(int id);

        public abstract Task UpdateAsync(T item);
    }
}
