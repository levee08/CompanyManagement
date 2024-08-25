using CompanyManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEmployeeLogic
{
    Task CreateAsync(Employee item);
    Task<Employee> ReadAsync(int id);
    Task<bool> UpdateAsync(Employee item);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}
