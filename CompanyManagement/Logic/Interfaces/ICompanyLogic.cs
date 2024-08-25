using CompanyManagement.Models;
namespace CompanyManagement.Logic.Interfaces
{
    public interface ICompanyLogic
    {
        Task CreateAsync(Company item);
        Task<Company> ReadAsync(int id);
        Task UpdateAsync(Company item);
        Task DeleteAsync(int id);
        Task<IEnumerable<Company>> GetAllCompaniesAsync();


    }
}
