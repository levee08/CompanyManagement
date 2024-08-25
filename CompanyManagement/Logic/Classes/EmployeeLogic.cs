using CompanyManagement.Models;
using CompanyManagement.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EmployeeLogic : IEmployeeLogic
{
    private readonly IRepository<Employee> _employeeRepository;

    public EmployeeLogic(IRepository<Employee> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task CreateAsync(Employee item)
    {
        await _employeeRepository.CreateAsync(item);
    }

    public async Task<Employee> ReadAsync(int id)
    {
        return await _employeeRepository.ReadAsync(id);
    }

    public async Task<bool> UpdateAsync(Employee item)
    {
        var entity = await _employeeRepository.ReadAsync(item.Id);
        if (entity == null)
        {
            return false;
        }

        await _employeeRepository.UpdateAsync(item);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _employeeRepository.ReadAsync(id);
        if (entity == null)
        {
            return false;
        }

        await _employeeRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _employeeRepository.ReadAllAsync();
    }
}
