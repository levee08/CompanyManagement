using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagement.Logic.Interfaces;
using CompanyManagement.Models;
using CompanyManagement.Repository;

namespace CompanyManagement.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeLogic(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _employeeRepository.CreateAsync(employee);
        }

        public async Task<Employee> ReadAsync(int id)
        {
            return await _employeeRepository.ReadAsync(id);
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.ReadAllAsync();
        }
    }
}
