using CompanyManagement.Data;

namespace CompanyManagement.Repository
{
    public abstract class GenericRepo<T> : IRepository<T> where T : class
    {

        protected AppDbContext ctx;

        public GenericRepo(AppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }
        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }
        public abstract T Read(int id);

        public abstract void Update(T item);
    }
}
