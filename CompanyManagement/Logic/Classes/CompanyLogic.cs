using CompanyManagement.Models;
using CompanyManagement.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CompanyLogic : ICompanyLogic
{
    private readonly IRepository<Company> _companyRepository;

    public CompanyLogic(IRepository<Company> companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task CreateAsync(Company item)
    {
        await _companyRepository.CreateAsync(item);
    }

    public async Task<Company> ReadAsync(int id)
    {
        return await _companyRepository.ReadAsync(id);
    }

    public async Task<bool> UpdateAsync(Company item)
    {
        var entity = await _companyRepository.ReadAsync(item.Id);
        if (entity == null)
        {
            return false;
        }

        await _companyRepository.UpdateAsync(item);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _companyRepository.ReadAsync(id);
        if (entity == null)
        {
            return false;
        }

        await _companyRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
    {
        return await _companyRepository.ReadAllAsync();
    }
}
