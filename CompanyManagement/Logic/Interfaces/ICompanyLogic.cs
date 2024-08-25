using CompanyManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICompanyLogic
{
    Task<bool> CreateAsync(Company item);
    Task<Company> ReadAsync(int id);
    Task<bool> UpdateAsync(Company item);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Company>> GetAllCompaniesAsync();
}
