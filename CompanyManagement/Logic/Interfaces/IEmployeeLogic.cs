using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagement.Models;

namespace CompanyManagement.Logic.Interfaces
{
    public interface IEmployeeLogic
    {
        Task CreateAsync(Employee employee);
        Task<Employee> ReadAsync(int id);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
}
