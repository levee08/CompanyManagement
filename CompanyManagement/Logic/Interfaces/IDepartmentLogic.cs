using CompanyManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDepartmentLogic
{
    Task CreateAsync(Department item);
    Task<Department> ReadAsync(int id);
    Task<bool> UpdateAsync(Department item);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();
}
