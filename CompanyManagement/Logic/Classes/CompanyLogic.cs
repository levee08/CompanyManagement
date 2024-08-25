using CompanyManagement.Logic.Interfaces;
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

    public async Task UpdateAsync(Company item)
    {
        await _companyRepository.UpdateAsync(item);
    }

    public async Task DeleteAsync(int id)
    {
        await _companyRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
    {
        return await _companyRepository.ReadAllAsync();
    }
}
