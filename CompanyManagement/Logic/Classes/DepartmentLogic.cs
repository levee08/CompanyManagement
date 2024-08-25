using CompanyManagement.Models;
using CompanyManagement.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DepartmentLogic : IDepartmentLogic
{
    private readonly IRepository<Department> _departmentRepository;

    public DepartmentLogic(IRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task CreateAsync(Department item)
    {
        await _departmentRepository.CreateAsync(item);
    }

    public async Task<Department> ReadAsync(int id)
    {
        return await _departmentRepository.ReadIncludingAsync(id, d => d.Employees);
    }

    public async Task<bool> UpdateAsync(Department item)
    {
        var entity = await _departmentRepository.ReadAsync(item.Id);
        if (entity == null)
        {
            return false;
        }

        await _departmentRepository.UpdateAsync(item);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _departmentRepository.ReadAsync(id);
        if (entity == null)
        {
            return false;
        }

        await _departmentRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
    {
        return await _departmentRepository.ReadAllIncludingAsync(d => d.Employees);
    }
}
