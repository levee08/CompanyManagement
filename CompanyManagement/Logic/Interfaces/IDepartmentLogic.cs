using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagement.Models;

namespace CompanyManagement.Logic.Interfaces
{
    public interface IDepartmentLogic
    {
        Task CreateAsync(Department department);
        Task<Department> ReadAsync(int id);
        Task<bool> UpdateAsync(Department department);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    }
}
