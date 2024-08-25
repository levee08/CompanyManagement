using CompanyManagement.Models;
namespace CompanyManagement.Logic.Interfaces
{
    public interface ICompanyLogic
    {
        Task CreateAsync(Company item);
        Task<Company> ReadAsync(int id);
        Task<bool> UpdateAsync(Company item);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Company>> GetAllCompaniesAsync();


    }
}
