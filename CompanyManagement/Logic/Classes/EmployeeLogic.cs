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

        public async Task<bool> UpdateAsync(Employee employee)
        {
            var entity = await _employeeRepository.ReadAsync(employee.Id);
            if(entity==null)
            {
                return false;
            }
            await _employeeRepository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = _employeeRepository.ReadAsync(id);
            if(entity==null)
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
}
