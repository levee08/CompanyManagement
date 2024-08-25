namespace CompanyManagement.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> ReadAllAsync();
        Task<T> ReadAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}
