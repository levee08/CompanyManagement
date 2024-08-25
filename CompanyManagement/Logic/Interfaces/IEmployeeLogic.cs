using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagement.Models;

namespace CompanyManagement.Logic.Interfaces
{
    public interface IEmployeeLogic
    {
        Task CreateAsync(Employee employee);
        Task<Employee> ReadAsync(int id);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
}
